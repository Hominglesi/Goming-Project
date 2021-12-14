using System;
using UnityEngine;

public static partial class ProjectileFactory
{
    public static GameObject Create(ProjectileArgs args)
    {
        switch (args.Type)
        {
            case ProjectileTypes.Straight: 
                return CreateStraight(args);
            case ProjectileTypes.Bouncing:
                return CreateBouncing(args);
            case ProjectileTypes.Homing:
                return CreateHoming(args);
            default:
                throw new NotImplementedException($"Projectile Factory for type '{args.Type}' is not implemented");
        }
    }
}

