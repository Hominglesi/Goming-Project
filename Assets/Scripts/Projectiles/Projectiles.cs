using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Projectiles
{
    private static Dictionary<ProjectileType, IProjectileArgs[]> ProjectileDictionary = new Dictionary<ProjectileType, IProjectileArgs[]>();

    public static IProjectileArgs GetProjectile(ProjectileType projectile, Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
            case Difficulty.Normal: return ProjectileDictionary[projectile][0].Clone();
            case Difficulty.Hard: return ProjectileDictionary[projectile][1].Clone();
            case Difficulty.Insane: return ProjectileDictionary[projectile][2].Clone();
            default: return ProjectileDictionary[projectile][0].Clone();
        }
    }

    static Projectiles()
    {
        LoadRombusProjectile();
    }

    private static void LoadRombusProjectile()
    {
        var normalArgs = new ProjectileStaggeredSpreadArgs()
        {
            StaggerCount = 2,
            ShotCount = 24,
            Speed = 4
        };
        var hardArgs = (ProjectileStaggeredSpreadArgs)normalArgs.Clone();
        hardArgs.ShotCount = 48;
        var insaneArgs = (ProjectileStaggeredSpreadArgs)hardArgs.Clone();
        insaneArgs.ShotCount = 72;
        ProjectileDictionary.Add(ProjectileType.RombusSpread, new IProjectileArgs[] { normalArgs, hardArgs, insaneArgs });
    }
}

public enum ProjectileType
{
    RombusSpread
}

