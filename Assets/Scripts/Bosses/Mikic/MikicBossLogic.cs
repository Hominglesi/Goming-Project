using System;
using System.Collections.Generic;
using UnityEngine;

public class MikicBossLogic : MonoBehaviour
{
    public Action OnDamaged;
    public bool IsDamageable { get; set; }
    private MikicStages CurrentStage { get; set; }
    private Dictionary<MikicStages, IBossStage> StageComponents = new Dictionary<MikicStages, IBossStage>();

    private void Start()
    {
        StageComponents.Add(MikicStages.IntroAnimation, GetComponent<MikicStageIntroAnimation>());
        StageComponents.Add(MikicStages.Basic, GetComponent<MikicStageBasic>());
        StageComponents.Add(MikicStages.Sleeping, GetComponent<MikicStageSleeping>());
        StageComponents.Add(MikicStages.WakingUp, GetComponent<MikicStageWakingUp>());
        StageComponents.Add(MikicStages.Enraged, GetComponent<MikicStageEnraged>());
        StageComponents.Add(MikicStages.EndAnimation, GetComponent<MikicStageEndAnimation>());

        SetStage(MikicStages.IntroAnimation);
        gameObject.GetComponent<BulletListener>().OnHit += OnHit;
    }

    public void SetStage(MikicStages stage)
    {
        foreach (var stageComponent in StageComponents)
        {
            SetStageActive(stageComponent.Value, stageComponent.Key == stage);
        }
    }

    private void SetStageActive(IBossStage stage, bool active = true)
    {
        stage.SetActive(active);
    }

    private void OnHit()
    {
        if (IsDamageable == false) return;
        OnDamaged?.Invoke();
    }

}

public enum MikicStages
{
    IntroAnimation,
    Basic,
    Sleeping,
    WakingUp,
    Enraged,
    EndAnimation
}