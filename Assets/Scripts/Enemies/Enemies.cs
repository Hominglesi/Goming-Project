using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Enemies
{
    private static Dictionary<EnemyType, IEnemyArgs[]> EnemyDictionary = new Dictionary<EnemyType, IEnemyArgs[]>();

    public static IEnemyArgs GetEnemy(EnemyType enemy, Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
            case Difficulty.Normal: return EnemyDictionary[enemy][0].Clone();
            case Difficulty.Hard: return EnemyDictionary[enemy][1].Clone();
            case Difficulty.Insane: return EnemyDictionary[enemy][2].Clone();
            default: return EnemyDictionary[enemy][0].Clone();
        }
    }

    static Enemies()
    {
        LoadRombusEnemy();
    }

    private static void LoadRombusEnemy()
    {
        var normalArgs = new EnemyPatrollerArgs()
        {
            Positions = Paths.RombusPath,
            MovementSpeed = 2,
            StartPosition = 0,
            MainProjectile = Projectiles.GetProjectile(ProjectileType.RombusSpread, Difficulty.Normal),
            Health = 35
        };

        var hardArgs = (EnemyPatrollerArgs)normalArgs.Clone();
        hardArgs.MovementSpeed = 3;
        hardArgs.MainProjectile = Projectiles.GetProjectile(ProjectileType.RombusSpread, Difficulty.Hard);
        hardArgs.Health = 55;
        var insaneArgs = (EnemyPatrollerArgs)hardArgs.Clone();
        insaneArgs.MovementSpeed = 4;
        insaneArgs.MainProjectile = Projectiles.GetProjectile(ProjectileType.RombusSpread, Difficulty.Insane);
        insaneArgs.Health = 75;
        EnemyDictionary.Add(EnemyType.Rombus, new IEnemyArgs[] { normalArgs, hardArgs, insaneArgs });
    }
}


public enum EnemyType
{
    Rombus
}
