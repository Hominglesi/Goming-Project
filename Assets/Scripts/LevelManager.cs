using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    LevelState currentState;

    float introTime = 3f;
    float introTimer;
    bool enemiesSpawned = false;
    float exitTime = 3f;
    float exitTimer;

    UILogic uiLogic;
    // Start is called before the first frame update
    void Start()
    {
        currentState = LevelState.Intro;
        uiLogic = GameHelper.GetUILogic();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentState == LevelState.Intro)
        {
            uiLogic.BackgroundScrollSpeed = GameHelper.MapValue(introTimer, 0, introTime, 20f, 2.5f);
            introTimer += Time.deltaTime;
            if(introTimer >= introTime)
            {
                uiLogic.BackgroundScrollSpeed = 2.5f;
                currentState = LevelState.Playing;
            }
        }
        else if (currentState == LevelState.Playing)
        {
            if (enemiesSpawned == false)
            {
                var mikicPrefab = Resources.Load<GameObject>("Prefabs/Enemies/Bosses/MikicBoss");
                var mikic = Instantiate(mikicPrefab);
                var mikicLogic = mikic.GetComponent<MikicBossLogic>();
                mikicLogic.OnDefeated += OnEnemyDefeated;
                enemiesSpawned = true;
            }

        }
        else if (currentState == LevelState.Outro)
        {
            uiLogic.BackgroundScrollSpeed = GameHelper.MapValue(exitTimer, 0, exitTime, 2.5f, 20f);
            exitTimer += Time.deltaTime;
            if (exitTimer >= exitTime)
            {
                SceneManager.LoadScene("LevelSelectScene");
            }
        }
    }

    private void OnEnemyDefeated()
    {
        currentState = LevelState.Outro;
    }
}

enum LevelState
{
    Intro,
    Playing,
    Outro
}
