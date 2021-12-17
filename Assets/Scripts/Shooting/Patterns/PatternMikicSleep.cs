using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class PatternMikicSleep : PatternBase
{
    public List<GameObject> Projectiles;
    public int maxProjectiles;
    public int remainingProjectiles;
    public int remainingCycles;
    public float fireRateDiference = 0.5f;
    public bool IsDone;

    SleepPhase currentPhase;

    Vector4 sleepBounds;
    Vector4 bossBounds;
    float padding = 0.3f;
    float bossSize = 2f;
    public void Initialize(PatternArgs args)
    {
        FireRate = args.FireRate;
        currentPhase = SleepPhase.Creating;
        IsDone = false;
        maxProjectiles = args.ShotCount;
        remainingProjectiles = maxProjectiles;
        remainingCycles = args.StageCount;
        var pField = GameHelper.PlayfieldBounds;
        var verticalMiddle = (pField.y + pField.w) / 2;
        sleepBounds = new Vector4(pField.x + padding, pField.y - padding, pField.z - padding, verticalMiddle);
        var pos = transform.position;
        bossBounds = new Vector4(pos.x - bossSize, pos.y + bossSize, pos.x + bossSize, pos.y - bossSize);
        Projectiles = new List<GameObject>();
    }

    public override GameObject[] OnShoot(ProjectileArgs args)
    {
        if (args.Type != ProjectileTypes.MikicSleep) throw new Exception($"PatternMikicSleep only supports being used with projectile type MikicSleep");
        if (currentPhase == SleepPhase.Creating)
        {
            args.StartPosition = transform.position;
            args.TargetDestination = GenerateValidPosition();

            remainingProjectiles--;
            if (remainingProjectiles <= 0) 
            {
                currentPhase = SleepPhase.Shooting;
                FireRate /= fireRateDiference;
            } 

            var projectile = ProjectileFactory.Create(args);
            Projectiles.Add(projectile);

            return new GameObject[] { projectile };
        }
        else if(currentPhase == SleepPhase.Shooting)
        {
            if(Projectiles.Count > 0)
            {
                var randNum = Random.Range(0, Projectiles.Count);
                Projectiles[randNum].GetComponent<ProjectileMikicSleepLogic>().Activate();
                Projectiles.RemoveAt(randNum);

                if (Projectiles.Count <= 0)
                {
                    remainingCycles--;
                    if(remainingCycles <= 0)
                    {
                        IsDone = true;
                    }
                    else
                    {
                        remainingProjectiles = maxProjectiles;
                        currentPhase = SleepPhase.Creating;
                        FireRate *= fireRateDiference;
                    }
                }
                
            }
            else
            {
                Debug.Log("No more projectiles to be shot out");
            }
            return null;
        }
        return null;
    }

    public Vector2 GenerateValidPosition()
    {
        do
        {
            var randX = Random.Range(sleepBounds.x, sleepBounds.z);
            var randY = Random.Range(sleepBounds.w, sleepBounds.y);

            if (randX>bossBounds.x && randX<bossBounds.z)
                if (randY > bossBounds.w )// && randY < bossBounds.y) Include top
                    continue;

            return new Vector2(randX, randY);

        } while (true);
    }
}

enum SleepPhase
{
    Creating,
    Shooting
}