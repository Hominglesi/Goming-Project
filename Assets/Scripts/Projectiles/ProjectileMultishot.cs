using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProjectileMultiShot : IProjectilePattern
{
    GameObject Prefab;
    public ProjectileMultiShot(){}
    public ProjectileMultiShot(IProjectileArgs args) { Spawn(args); }

    public void Spawn(IProjectileArgs iArgs)
    {
        var args = (ProjectileMultiShotArgs)iArgs;

        var angle = GameHelper.RotationFromDirection(args.Direction);
        var wholeAngle = args.AngleSpacing * args.ShotCount;
        var angleStart = angle - (wholeAngle / 2);

        for (int i = 0; i < args.ShotCount; i++)
        {
            var shotAngle = angleStart + (i * args.AngleSpacing);
            var basicArgs = new ProjectileSingleArgs()
            {
                Position = args.Position,
                IsPlayer = args.IsPlayer,
                Speed = args.Speed,
                Direction = GameHelper.DirectionFromRotation(shotAngle)
            };
            new ProjectileSingle(basicArgs);
        }
    }
}

public class ProjectileMultiShotArgs : ProjectileSingleArgs
{
    public override Type ProjectileType { get; set; } = typeof(ProjectileMultiShot);
    public float AngleSpacing { get; set; } = 1;
    public float ShotCount { get; set; } = 3;
}
