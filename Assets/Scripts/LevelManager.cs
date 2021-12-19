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

    float maxSpeed = 40;
    float minSpeed = 5;

    LevelVisualsManager visualsManager;
    // Start is called before the first frame update
    void Start()
    {
        currentState = LevelState.Intro;
        visualsManager = GetComponent<LevelVisualsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentState == LevelState.Intro)
        {
            visualsManager.BackgroundScrollSpeed = GameHelper.MapValue(introTimer, 0, introTime, maxSpeed, minSpeed);
            introTimer += Time.deltaTime;
            if(introTimer >= introTime)
            {
                visualsManager.BackgroundScrollSpeed = 2.5f;
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
            visualsManager.BackgroundScrollSpeed = GameHelper.MapValue(exitTimer, 0, exitTime, minSpeed, maxSpeed);
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
