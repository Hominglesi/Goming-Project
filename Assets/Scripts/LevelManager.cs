using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var currentLevel = GlobalData.CurrentLevel;
        /* OLD LOGIC
        var spawner = GetComponent<EnemySpawner>();
        if(currentLevel.Difficulty == Difficulty.Easy)
        {
            spawner.SpawnPattern(new PatternInvader(10, 4));
        }
        else
        {
            spawner.SpawnPattern(new PatternRombus());
        }*/
        
        Debug.Log(GlobalData.CurrentLevel.Difficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
