using UnityEngine;

public class PatternMikicHair : PatternBase
{
    int minShots = 2;
    int maxShots = 3;
    float shotRange = 2.3f;
    float minimumDistance = 0.8f;
    public override void Initialize(PatternArgs args)
    {
        FireRate = args.FireRate;
    }

    public override GameObject[] OnShoot(ProjectileArgs args)
    {
        var shotCount = Random.Range(minShots, maxShots+1);
        var points = GeneratePoints(shotCount);
        var output = new GameObject[shotCount];
        for (int i = 0; i < shotCount; i++)
        {
            args.StartPosition = transform.position + new Vector3(points[i], 0);
            args.Direction = Vector2.down;
            var projectile = ProjectileFactory.Create(args);
            output[i] = projectile;
        }

        return output;
    }


    private float[] GeneratePoints(int count)
    {
        var points = new float[count];
        int done = 0;
        int remaining = count;
        while (remaining > 0)
        {
            var point = Random.Range(-shotRange, shotRange);
            var possible = true;
            for (int i = 0; i < done; i++)
            {
                if (Mathf.Abs(point - points[i]) < minimumDistance) possible = false;
            }
            if (possible == false) continue;
            points[done] = point;
            remaining--;
            done++;
        }
        return points;

    }
}
