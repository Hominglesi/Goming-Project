using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class PatternMikicSleep : PatternBase
{
    Vector4 sleepBounds;
    Vector4 bossBounds;
    float padding = 0.3f;
    float bossSize = 2f;
    public void Initialize(PatternArgs args)
    {
        FireRate = args.FireRate;
        var pField = GameHelper.PlayfieldBounds;
        var verticalMiddle = (pField.y + pField.w) / 2;
        sleepBounds = new Vector4(pField.x + padding, pField.y - padding, pField.z - padding, verticalMiddle);
        var pos = transform.position;
        bossBounds = new Vector4(pos.x - bossSize, pos.y + bossSize, pos.x + bossSize, pos.y - bossSize);
    }

    public override GameObject[] OnShoot(ProjectileArgs args)
    {
        args.StartPosition = transform.position;
        args.TargetDestination = GenerateValidPosition();


        return new GameObject[] { ProjectileFactory.Create(args) };
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