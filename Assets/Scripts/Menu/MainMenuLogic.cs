using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuLogic : MonoBehaviour
{
    public Button PlayButton;
    public Button QuitButton;
    // Start is called before the first frame update
    void Start()
    {
        PlayButton.onClick.AddListener(StartGame);
        QuitButton.onClick.AddListener(QuitGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene("LevelSelectScene");
    }
    
    void QuitGame()
    {
        Application.Quit();
    }
}
