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
        var spacing = 360 / args.ShotCount;

        for (int i = 0; i < args.ShotCount; i++)
        {
            float angle = i * spacing;
            var basicArgs = new ProjectileSingleArgs()
            {
                Position = args.Position,
                IsPlayer = args.IsPlayer,
                Speed = args.Speed,
                Direction = GameHelper.DirectionFromRotation(angle)
            };
            new ProjectileSingle(basicArgs);
        }
    }
}

public class ProjectileSpreadArgs : ProjectileSingleArgs
{
    public override Type ProjectileType { get; set; } = typeof(ProjectileSpread);
    public int ShotCount { get; set; } = 8;
}