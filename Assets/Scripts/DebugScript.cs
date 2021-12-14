using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugScript : MonoBehaviour
{
    // Update is called once per frame
    void Start()
    {
        
    }

    private void Update()
    {
        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (Input.GetKeyDown(KeyCode.R))
        {
            //SceneManager.LoadScene("LevelSelectScene");
            var args = new ProjectileArgs()
            {
                Type = ProjectileTypes.Bouncing,
                Speed = 6,
                BounceAmount = 25
            };
            ProjectileFactory.Create(args);
        }
    }
}
