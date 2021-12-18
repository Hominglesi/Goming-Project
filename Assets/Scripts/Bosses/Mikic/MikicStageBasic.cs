using UnityEngine;
public class MikicStageBasic : BossStageBase, IBossStage
{
    PatternBase mainPattern;
    PatternBase nerfedMainPattern;
    ProjectileArgs mainProjectile;

    PatternBase hairPattern;
    ProjectileArgs hairProjectile;

    MovementDvdLogo dvdMovement;
    MovementRotateTowards rotationMovement;

    int maxHealth = 100;
    int health;
    float rotationSpeed = 1;

    private void Awake()
    {
        dvdMovement = GetComponent<MovementDvdLogo>();
        rotationMovement = GetComponent<MovementRotateTowards>();
    }

    public override void OnDisabled()
    {
        dvdMovement.enabled = false;
        rotationMovement.enabled = false;
        gameObject.GetComponent<MikicBossLogic>().OnDamaged -= OnDamaged;
    }

    public override void OnAwake()
    {
        IsDamagable = true;
        gameObject.GetComponent<MikicBossLogic>().OnDamaged += OnDamaged;

        //Setup Dvd Movement
        dvdMovement.enabled = true;
        dvdMovement.Speed = 1f;
        var dvdOffset = 1.5f;
        var bounds = GameHelper.PlayfieldBounds;
        var horizontalMid = (bounds.y + bounds.w) / 2;
        dvdMovement.Bounds = new Vector4(bounds.x + dvdOffset, bounds.y - dvdOffset, bounds.z - dvdOffset, horizontalMid + dvdOffset);

        //Setup Rotation Movement
        rotationMovement.enabled = true;
        rotationMovement.RotationSpeed = rotationSpeed;
        rotationMovement.TargetRotation = 0;

        health = maxHealth;

        mainPattern = PatternFactory.AttachComponent(gameObject, new PatternArgs()
        {
            Type = PatternTypes.Spread,
            ShotCount = 24,
            StageCount = 2,
            FireRate = 16f
        });

        nerfedMainPattern = PatternFactory.AttachComponent(gameObject, new PatternArgs()
        {
            Type = PatternTypes.Spread,
            ShotCount = 12,
            StageCount = 2,
            FireRate = 12f
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

        hairPattern = PatternFactory.AttachComponent(gameObject, new PatternArgs()
        {
            Type = PatternTypes.MikicHair,
            FireRate = 35f
        });

        hairProjectile = new ProjectileArgs()
        {
            Type = ProjectileTypes.Straight,
            Speed = 4f,
            StartPositionOffset = 1.5f,
            SpritePath = "Sprites/mijatovicHairProjectile",
            CustomCollider = true,
            ColliderSize = new Vector2(0.6f,0.3f),
            ColliderOffset = new Vector2(0, 0.07f)
        };

        hairAttackCooldown = 0;
        hairAttackTimer = 0;
    }

    public void Update()
    {
        if (health > maxHealth * 0.66f)
        {
            if(dvdMovement.enabled == false) dvdMovement.enabled = true;
            mainPattern.Shoot(mainProjectile);
        }
        else
        {
            if (hairAttackCooldown <= 0)
            {
                if (dvdMovement.enabled == true) dvdMovement.enabled = false;
                if (rotationMovement.TargetRotation != 180) rotationMovement.TargetRotation = 180;

                nerfedMainPattern.Shoot(mainProjectile);
                if(transform.rotation.eulerAngles.z == 180)
                {
                    ProcessHairAttack();
                }
            }
            else
            {
                rotationMovement.TargetRotation = 0;
                if (dvdMovement.enabled == false) dvdMovement.enabled = true;
                mainPattern.Shoot(mainProjectile);
                hairAttackCooldown -= Time.deltaTime;
            }
        }
    }

    float hairAttackCooldown = 0;
    float hairAttackRate = 5f;
    float hairAttackTimer;
    float hairAttackDuration = 3f;
    private void ProcessHairAttack()
    {
        if(hairAttackTimer < hairAttackDuration)
        {
            hairPattern.Shoot(hairProjectile);
            hairAttackTimer += Time.deltaTime;
        }
        else
        {
            hairAttackTimer = 0;
            hairAttackCooldown = hairAttackRate;
        }
        
    }

    public void OnDamaged()
    {
        health--;
        if(health <= 0)
        {
            gameObject.GetComponent<MikicBossLogic>().SetStage(MikicStages.Sleeping);
        }
    }
}

