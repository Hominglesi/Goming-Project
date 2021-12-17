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
        if (Input.GetKeyDown(KeyCode.R))
        {
            //SceneManager.LoadScene("LevelSelectScene");
            ParticleFactory.Create(ParticleType.Explosion, new Vector2(1,1));
        }
    }
}
