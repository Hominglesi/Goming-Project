using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILogic : MonoBehaviour
{
    [SerializeField]
    Text HitsTakenDisplay;
    int _hitsTaken;
    public int HitsTaken { get {
            return _hitsTaken;
        }
        set
        {
            _hitsTaken = value;
            HitsTakenDisplay.text = _hitsTaken.ToString();
        }
    }

    [SerializeField]
    Text EnemiesDefeatedDisplay;
    int _enemiesDefeated;
    public int EnemiesDefeated
    {
        get
        {
            return _enemiesDefeated;
        }
        set
        {
            _enemiesDefeated = value;
            EnemiesDefeatedDisplay.text = _enemiesDefeated.ToString();
        }
    }

    [SerializeField]
    Text ProjectilesDisplay;
    int _projectiles;
    public int Projectiles
    {
        get
        {
            return _projectiles;
        }
        set
        {
            _projectiles = value;
            if(ProjectilesDisplay != null)
                ProjectilesDisplay.text = _projectiles.ToString();
        }
    }

    [SerializeField]
    Text FPSDisplay;

    [SerializeField]
    Text DifficultyDisplay;

    public RectTransform PlayfieldTransform;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayOof()
    {
        audioSource.Play(0);
    }
    private void Update()
    {
        FPSDisplay.text = ((int)(1f / Time.unscaledDeltaTime)).ToString();
        //TODO: uncomment this
        //DifficultyDisplay.text = GlobalData.CurrentLevel.Difficulty.ToString();
    }

}
