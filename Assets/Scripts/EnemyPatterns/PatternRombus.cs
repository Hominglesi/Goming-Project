using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PatternRombus : IEnemyPattern
{
    public bool IsCompleted { get; set; }
    public Vector2[] Points;
    public Vector4 PlayfieldBounds;

    float width;
    float height;
    float topPadding;

    public PatternRombus()
    {
        var enemyArgs = (EnemyPatrollerArgs)Enemies.GetEnemy(EnemyType.Rombus, GlobalData.CurrentLevel.Difficulty);

        enemyArgs.StartPosition = 1;
        Debug.Log(((ProjectileStaggeredSpreadArgs)enemyArgs.MainProjectile).ShotCount);
        EnemyPatroller.Spawn(enemyArgs);

        enemyArgs.StartPosition = 3;
        Debug.Log(((ProjectileStaggeredSpreadArgs)enemyArgs.MainProjectile).ShotCount);
        EnemyPatroller.Spawn(enemyArgs);

        IsCompleted = true;
    }

    public void Update(){ }
}