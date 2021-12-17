using System;
using UnityEngine;

public static partial class ProjectileFactory
{
    public static GameObject Create(ProjectileArgs args)
    {
        GameHelper.GetUILogic().Projectiles++;
        switch (args.Type)
        {
            case ProjectileTypes.Straight: 
                return CreateStraight(args);
            case ProjectileTypes.Bouncing:
                return CreateBouncing(args);
            case ProjectileTypes.Homing:
                return CreateHoming(args);
            case ProjectileTypes.MikicSleep:
                return CreateMikicSleep(args);
            default:
                throw new NotImplementedException($"Projectile Factory for type '{args.Type}' is not implemented");
        }
    }

    public static void Destroy(GameObject projectile)
    {
        GameObject.Destroy(projectile);

        //We dont care if there is no UI because that means the game is closed
        try { GameHelper.GetUILogic().Projectiles--; }
        catch (NullReferenceException) { }
    }
}

