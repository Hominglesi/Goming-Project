using UnityEngine;
public class MikicStageBasic : MonoBehaviour, IBossStage
{
    PatternBase mainPattern;
    ProjectileArgs mainProjectile;

    public void SetActive(bool active)
    {
        enabled = active;
        if (active) OnAwake();
        gameObject.GetComponent<MikicBossLogic>().IsDamageable = true;
    }

    public void OnAwake()
    {
        mainPattern = PatternFactory.AttachComponent(gameObject, new PatternArgs()
        {
            Type = PatternTypes.Spread,
            ShotCount = 42,
            Direction = Vector2.down,
            FireRate = 8f
        });

        mainProjectile = new ProjectileArgs()
        {
            Type = ProjectileTypes.Bouncing,
            BounceAmount = 1,
            Speed = 5f,
            StartPositionOffset = 1.5f
        };
    }

    public void Update()
    {
        mainPattern.Shoot(mainProjectile);
    }
}

