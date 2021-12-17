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
    public int remainingProjectiles;
    public bool secondPhase;
    public bool done;

    Vector4 sleepBounds;
    Vector4 bossBounds;
    float padding = 0.3f;
    float bossSize = 2f;
    public void Initialize(PatternArgs args)
    {
        FireRate = args.FireRate;
        secondPhase = false;
        done = false;
        remainingProjectiles = args.ShotCount;
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
        if (secondPhase == false)
        {
            args.StartPosition = transform.position;
            args.TargetDestination = GenerateValidPosition();

            remainingProjectiles--;
            if (remainingProjectiles <= 0) secondPhase = true;

            var projectile = ProjectileFactory.Create(args);
            Projectiles.Add(projectile);

            return new GameObject[] { projectile };
        }
        else
        {
            if(Projectiles.Count > 0)
            {
                var randNum = Random.Range(0, Projectiles.Count);
                Projectiles[randNum].GetComponent<ProjectileMikicSleepLogic>().Activate();
                Projectiles.RemoveAt(randNum);

                if (Projectiles.Count <= 0) done = true;
            }
            else
            {
                Debug.Log("No more projectiles to be shot out");
            }
            return null;
        }
        
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

