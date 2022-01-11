using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILogic : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI HitsTakenDisplay;
    int _hitsTaken;
    public int HitsTaken { get {
            return _hitsTaken;
        }
        set
        {
            _hitsTaken = value;
            if(HitsTakenDisplay != null)
                HitsTakenDisplay.text = _hitsTaken.ToString();
        }
    }

    [SerializeField]
    TextMeshProUGUI EnemiesDefeatedDisplay;
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
            if(EnemiesDefeatedDisplay != null)
                EnemiesDefeatedDisplay.text = _enemiesDefeated.ToString();
        }
    }

    [SerializeField]
    TextMeshProUGUI ProjectilesDisplay;
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
    TextMeshProUGUI FPSDisplay;

    [SerializeField]
    TextMeshProUGUI DifficultyDisplay;

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
        if(FPSDisplay != null)
            FPSDisplay.text = ((int)(1f / Time.unscaledDeltaTime)).ToString();
        if(DifficultyDisplay != null)
            DifficultyDisplay.text = GlobalData.CurrentLevel.Difficulty.ToString();
    }
}
