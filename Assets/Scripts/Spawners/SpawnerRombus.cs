using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SpawnerRombus
{
    public SpawnerRombus(IProjectileArgs Projectile, Vector2[] points, int startPoint)
    {
        var prefab = Resources.Load<GameObject>("Prefabs/EnemyRombus");
        var obj = GameObject.Instantiate(prefab);
        var logic = obj.GetComponent<EnemyLogic>();
        obj.transform.position = points[startPoint-1];
        for (int i = startPoint; i < 100; i++)
        {
            logic.Destinations.Enqueue(points[i%points.Length]);
        }
        logic.Projectiles = (ProjectileStaggeredSpreadArgs)Projectile;
    }
}

