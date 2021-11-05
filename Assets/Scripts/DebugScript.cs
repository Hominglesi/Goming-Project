using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugScript : MonoBehaviour
{
    // Update is called once per frame
    void Start()
    {
        var spawner = GetComponent<EnemySpawner>();
        spawner.SpawnPattern(new PatternRombus());
    }

    private void Update()
    {
        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
