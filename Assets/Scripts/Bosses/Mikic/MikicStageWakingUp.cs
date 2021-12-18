using System;
using UnityEngine;

public class MikicStageWakingUp : BossStageBase, IBossStage
{
    PatternMikicSleep sleepPattern;
    ProjectileArgs sleepProjectile;

    StageTimer stageTimer;

    private void Awake()
    {
        stageTimer = GetComponent<StageTimer>();
    }

    public override void OnDisabled()
    {
        stageTimer.Reset();
    }

    public override void OnAwake()
    {
        IsDamagable = false;

        stageTimer.AddStage("Firing", 2f);
        stageTimer.AddStage("Waiting", 1f);
        stageTimer.AddStage("Firing", 2f);
        stageTimer.AddStage("Waiting", 1f);
        stageTimer.AddStage("Firing", 2f);
        stageTimer.AddStage("Waiting", 1f);
        stageTimer.AddStage("Done", 10f);

        sleepPattern = (PatternMikicSleep)PatternFactory.AttachComponent(gameObject, new PatternArgs()
        {
            Type = PatternTypes.MikicSleep,
            FireRate = 6f,
            StageCount = 3
        });

        sleepProjectile = new ProjectileArgs()
        {
            Type = ProjectileTypes.MikicSleep,
            Speed = 8,
            StartPositionOffset = 1.5f,
            Speed2 = 8,
            OffsetRange = 2f,
            WaitTime = 1f
        };
    }

    public void Update()
    {
        if(stageTimer.CurrentStage == "Firing")
            sleepPattern.Shoot(sleepProjectile);
        
        if(stageTimer.CurrentStage == "Done")
            gameObject.GetComponent<MikicBossLogic>().SetStage(MikicStages.Enraged);
    }
}