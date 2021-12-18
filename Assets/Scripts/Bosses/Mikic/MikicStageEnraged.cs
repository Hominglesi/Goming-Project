using System;
using UnityEngine;

public class MikicStageEnraged : BossStageBase, IBossStage
{
    MovementDvdLogo dvdMovement;
    StageTimer stageTimer;

    PatternBase mainPattern;
    PatternBase enragedPattern;
    ProjectileArgs mainProjectile;

    float maxHealth = 50f;
    float health;

    private void Awake()
    {
        
        dvdMovement = GetComponent<MovementDvdLogo>();
        stageTimer = GetComponent<StageTimer>();
    }

    public override void OnDisabled()
    {
        dvdMovement.enabled = false;
        stageTimer.Reset();
        gameObject.GetComponent<MikicBossLogic>().OnDamaged -= OnDamaged;
    }

    public override void OnAwake()
    {
        IsDamagable = true;
        health = maxHealth;
        gameObject.GetComponent<MikicBossLogic>().OnDamaged += OnDamaged;

        //Setup Dvd Movement
        dvdMovement.enabled = true;
        dvdMovement.Speed = 1f;
        var dvdOffset = 1.5f;
        var bounds = GameHelper.PlayfieldBounds;
        var horizontalMid = (bounds.y + bounds.w) / 2;
        dvdMovement.Bounds = new Vector4(bounds.x + dvdOffset, bounds.y - dvdOffset, bounds.z - dvdOffset, horizontalMid + dvdOffset);

        //Setup Stage Timer
        stageTimer.AddStage("Moving", 1f);
        stageTimer.AddStage("Shooting", 1f);

        //Setup projectiles
        mainPattern = PatternFactory.AttachComponent(gameObject, new PatternArgs()
        {
            Type = PatternTypes.Spread,
            ShotCount = 24,
            StageCount = 2,
            FireRate = 16f
        });

        enragedPattern = PatternFactory.AttachComponent(gameObject, new PatternArgs()
        {
            Type = PatternTypes.Spread,
            ShotCount = 48,
            StageCount = 2,
            FireRate = 16f
        });

        mainProjectile = new ProjectileArgs()
        {
            Type = ProjectileTypes.Straight,
            Speed = 4f,
            StartPositionOffset = 1.5f,
            SpritePath = "Sprites/mijatovicProjectileBasic",
            CustomCollider = true,
            ColliderSize = new Vector2(0.14f, 0.14f),
        };


    }

    public void Update()
    {
        if(stageTimer.CurrentStage == "Moving")
        {
            if (dvdMovement.enabled == false) dvdMovement.enabled = true;
            mainPattern.Shoot(mainProjectile);
        }
        else if(stageTimer.CurrentStage == "Shooting")
        {
            if (dvdMovement.enabled == true) dvdMovement.enabled = false;
            enragedPattern.Shoot(mainProjectile);
        }
    }

    private void OnDamaged()
    {
        health--;
        if (health <= 0)
        {
            gameObject.GetComponent<MikicBossLogic>().SetStage(MikicStages.EndAnimation);
        }
    }
}