using UnityEngine;
public class MikicStageBasic : MonoBehaviour, IBossStage
{
    PatternBase mainPattern;
    PatternBase nerfedMainPattern;
    ProjectileArgs mainProjectile;

    PatternBase hairPattern;
    ProjectileArgs hairProjectile;

    int maxHealth = 300;
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

        bobbingMiddle = transform.position.y;
        playfieldBounds = GameHelper.PlayfieldBounds;
        hairAttackCooldown = 0;
        hairAttachDone = false;
        hairAttackTimer = 0;
        isUpright = true;
        currentRotation = 0;
    }

    public void Update()
    {
        if (health > maxHealth * 0.66f)
        {
            ProcessMovement();
            mainPattern.Shoot(mainProjectile);
        }
        else
        {
            if (hairAttackCooldown <= 0)
            {
                if(hairAttachDone == false && isUpright || hairAttachDone && isUpright == false)
                {
                    ProcessRotation();
                    nerfedMainPattern.Shoot(mainProjectile);
                }
                else
                {
                    ProcessHairAttack();
                    nerfedMainPattern.Shoot(mainProjectile);
                }
            }
            else
            {
                ProcessMovement();
                mainPattern.Shoot(mainProjectile);
                hairAttackCooldown -= Time.deltaTime;
            }
        }
    }

    float hairAttackCooldown = 0;
    float hairAttackRate = 5f;
    bool hairAttachDone = false;
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
            hairAttachDone = true;
            hairAttackTimer = 0;
        }
        
    }

    bool isUpright = true;
    float currentRotation = 0;
    float rotationSpeed = 100f;
    private void ProcessRotation()
    {
        if (isUpright) currentRotation += rotationSpeed * Time.deltaTime;
        if (isUpright == false) currentRotation -= rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, currentRotation));

        if(isUpright && currentRotation >= 180)
        {
            isUpright = false;
            currentRotation = 180;
        }
        if(isUpright == false && currentRotation <= 0)
        {
            isUpright = true;
            currentRotation = 0;
            hairAttachDone = false;
            hairAttackCooldown = hairAttackRate;
        }
    }

    float horizontalDir = 1;
    float verticalDir = 1;
    float bobingAmplitude = 1f;
    float bobbingMiddle;
    float horizontalEdgeDistance = 2f;
    float speed = 1f;
    Vector4 playfieldBounds;
    private void ProcessMovement()
    {
        transform.position += new Vector3(horizontalDir * speed * Time.deltaTime, verticalDir * speed * Time.deltaTime);

        if (verticalDir == 1 && transform.position.y > bobbingMiddle + bobingAmplitude) verticalDir *= -1;
        else if (verticalDir == -1 && transform.position.y < bobbingMiddle - bobingAmplitude) verticalDir *= -1;
        if (horizontalDir == -1 &&  transform.position.x < playfieldBounds.x + horizontalEdgeDistance) horizontalDir *= -1;
        else if (horizontalDir == 1 && transform.position.x > playfieldBounds.z - horizontalEdgeDistance) horizontalDir *= -1;
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

