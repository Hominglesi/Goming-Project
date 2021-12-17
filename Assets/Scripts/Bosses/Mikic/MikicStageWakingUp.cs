using System;
using UnityEngine;

public class MikicStageWakingUp : MonoBehaviour, IBossStage
{
    PatternMikicSleep sleepPattern;
    ProjectileArgs sleepProjectile;

    public void SetActive(bool active)
    {
        enabled = active;
        if (active) OnAwake();
    }

    public void OnAwake()
    {
        gameObject.GetComponent<MikicBossLogic>().IsDamageable = false;

        sleepPattern = (PatternMikicSleep)PatternFactory.AttachComponent(gameObject, new PatternArgs()
        {
            Type = PatternTypes.MikicSleep,
            FireRate = 5f,
            ShotCount = 40,
            StageCount = 3
        });

        sleepProjectile = new ProjectileArgs()
        {
            Type = ProjectileTypes.MikicSleep,
            Speed = 6,
            StartPositionOffset = 1.5f,
        };
    }

    public void Update()
    {
        sleepPattern.Shoot(sleepProjectile);
        if(sleepPattern.IsDone == true)
            gameObject.GetComponent<MikicBossLogic>().SetStage(MikicStages.EndAnimation);
    }
}