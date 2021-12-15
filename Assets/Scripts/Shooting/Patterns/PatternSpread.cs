using UnityEngine;

public class PatternSpread : PatternBase
{
    public Vector2 direction;
    private int shotCount;

    public void Initialize(PatternArgs args)
    {
        FireRate = args.FireRate;
        direction = args.Direction;
        shotCount = args.ShotCount;
    }

    public override void OnShoot(ProjectileArgs args)
    {
        var spacing = 360f / shotCount;
        var angle = GameHelper.RotationFromDirection(direction);

        for (int i = 0; i < shotCount; i++)
        {
            float shotAngle = angle + (i * spacing);

            args.Direction = GameHelper.DirectionFromRotation(shotAngle);
            args.StartPosition = transform.position;

            ProjectileFactory.Create(args);
        }
        
    }
}

