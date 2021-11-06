using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectLogic : MonoBehaviour
{
    public Button EasyButton;
    public Button NormalButton;
    public Button HardButton;
    public Button InsaneButton;
    // Start is called before the first frame update
    void Start()
    {
        EasyButton.onClick.AddListener(Easy);
        NormalButton.onClick.AddListener(Normal);
        HardButton.onClick.AddListener(Hard);
        InsaneButton.onClick.AddListener(Insane);
    }

    void Easy()
    {
        GlobalData.CurrentLevel = new Level("Hidden Valley", Difficulty.Easy);
        SceneManager.LoadScene("GameScene");
    }
    void Normal()
    {
        GlobalData.CurrentLevel = new Level("Hidden Valley", Difficulty.Normal);
        SceneManager.LoadScene("GameScene");
    }
    void Hard()
    {
        GlobalData.CurrentLevel = new Level("Hidden Valley", Difficulty.Hard);
        SceneManager.LoadScene("GameScene");
    }
    void Insane()
    {
        GlobalData.CurrentLevel = new Level("Hidden Valley", Difficulty.Insane);
        SceneManager.LoadScene("GameScene");
    }
}
