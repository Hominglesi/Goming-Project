using UnityEngine;

public class PatternSpread : PatternBase
{
    public Vector2 direction;
    private int shotCount;
    private int stageCount;

    public void Initialize(PatternArgs args)
    {
        FireRate = args.FireRate;
        direction = args.Direction;
        shotCount = args.ShotCount;
        stageCount = args.StageCount;
    }

    public override GameObject[] OnShoot(ProjectileArgs args)
    {
        var spacing = 360f / shotCount;
        var directionOffset = (spacing / stageCount) * (ShotNumber % stageCount);
        var angle = GameHelper.RotationFromDirection(direction) + directionOffset;
        var output = new GameObject[shotCount];

        for (int i = 0; i < shotCount; i++)
        {
            float shotAngle = angle + (i * spacing);

            args.Direction = GameHelper.DirectionFromRotation(shotAngle);
            args.StartPosition = transform.position;

            var projectile = ProjectileFactory.Create(args);
            output[i] = projectile;
        }
        return output;
    }
}

