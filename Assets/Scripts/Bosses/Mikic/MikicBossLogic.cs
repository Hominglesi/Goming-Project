using System.Collections.Generic;
using UnityEngine;

public class MikicBossLogic : MonoBehaviour
{
    public bool IsDamageable { get; set; }
    private MikicStages CurrentStage { get; set; }
    private Dictionary<MikicStages, IBossStage> StageComponents = new Dictionary<MikicStages, IBossStage>();

    private void Start()
    {
        StageComponents.Add(MikicStages.IntroAnimation, GetComponent<MikicStageIntroAnimation>());
        StageComponents.Add(MikicStages.Basic, GetComponent<MikicStageBasic>());

        SetStage(MikicStages.IntroAnimation);
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