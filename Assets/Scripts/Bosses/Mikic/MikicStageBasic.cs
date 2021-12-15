using UnityEngine;
public class MikicStageBasic : MonoBehaviour, IBossStage
{
    PatternBase mainPattern;
    ProjectileArgs mainProjectile;

    int health;

    private void Awake()
    {
        gameObject.GetComponent<MikicBossLogic>().OnDamaged += OnDamaged;
    }

    public void SetActive(bool active)
    {
        enabled = active;
        if (active) OnAwake();
    }

    public void OnAwake()
    {
        gameObject.GetComponent<MikicBossLogic>().IsDamageable = true;

        health = 10;
        mainPattern = PatternFactory.AttachComponent(gameObject, new PatternArgs()
        {
            Type = PatternTypes.Spread,
            ShotCount = 32,
            Direction = GameHelper.DirectionFromRotation(45),
            FireRate = 12f
        });

        mainProjectile = new ProjectileArgs()
        {
            Type = ProjectileTypes.Straight,
            Speed = 5f,
            StartPositionOffset = 1.5f
        };
    }

    public void Update()
    {
        mainPattern.Shoot(mainProjectile);
    }

    public void OnDamaged()
    {
        health--;
        if(health <= 0)
        {
            gameObject.GetComponent<MikicBossLogic>().SetStage(MikicStages.IntroAnimation);
        }
    }
}

