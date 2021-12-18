using System;
using UnityEngine;

public class MikicStageWakingUp : BossStageBase, IBossStage
{
    PatternMikicSleep sleepPattern;
    ProjectileArgs sleepProjectile;

    public override void OnAwake()
    {
        IsDamagable = false;

        sleepPattern = (PatternMikicSleep)PatternFactory.AttachComponent(gameObject, new PatternArgs()
        {
            Type = PatternTypes.MikicSleep,
            FireRate = 6f,
            ShotCount = 50,
            StageCount = 3
        });

        sleepProjectile = new ProjectileArgs()
        {
            Type = ProjectileTypes.MikicSleep,
            Speed = 8,
            StartPositionOffset = 1.5f,
        };
    }

    public void Update()
    {
        sleepPattern.Shoot(sleepProjectile);
        if(sleepPattern.IsDone == true)
            gameObject.GetComponent<MikicBossLogic>().SetStage(MikicStages.Enraged);
    }
}