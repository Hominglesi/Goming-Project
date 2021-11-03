using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            var enemy = Resources.Load<GameObject>("Prefabs/BasicEnemy");
            Instantiate(enemy);
        }
            
    }
}
