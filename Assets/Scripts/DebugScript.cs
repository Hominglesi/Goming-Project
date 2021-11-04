using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    // Update is called once per frame
    void Start()
    {
        var spawner = GetComponent<EnemySpawner>();
        spawner.SpawnPattern(new PatternInvader(30, 7));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            var spawner = GetComponent<EnemySpawner>();
            spawner.PatternQueue.Clear();
        }
    }
}
