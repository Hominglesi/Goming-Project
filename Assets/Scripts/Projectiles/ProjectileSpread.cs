using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpread : IProjectilePattern
{
    public ProjectileSpread(){ }
    public ProjectileSpread(IProjectileArgs args) { Spawn(args); }

    public void Spawn(IProjectileArgs iArgs)
    {
        var args = (ProjectileSpreadArgs)iArgs;
        var spacing = 360f / args.ShotCount;
        var angle = GameHelper.RotationFromDirection(args.Direction);

        for (int i = 0; i < args.ShotCount; i++)
        {
            float shotAngle = angle + (i * spacing);

            args.Direction = GameHelper.DirectionFromRotation(shotAngle);
            new ProjectileSingle(args);
        }
    }
}

public class ProjectileSpreadArgs : ProjectileSingleArgs
{
    public override Type ProjectileType { get; set; } = typeof(ProjectileSpread);
    public int ShotCount { get; set; } = 8;
    public override IProjectileArgs Clone()
    {
        var clone = new ProjectileSpreadArgs
        {
            Direction = Direction,
            Speed = Speed,
            Position = Position,
            IsPlayer = IsPlayer,
            Cycle = Cycle,
            ShotCount = ShotCount
        };
        return clone;
    }
}