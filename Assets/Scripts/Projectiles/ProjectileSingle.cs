using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ProjectileSingle : IProjectilePattern
{
    public ProjectileSingle(){ }
    public ProjectileSingle(IProjectileArgs args) { Spawn(args); }

    public void Spawn(IProjectileArgs iArgs)
    {
        var args = (ProjectileSingleArgs)iArgs;
        var prefab = Resources.Load<GameObject>("Prefabs/ProjectilePrefab");
        var projectile = GameObject.Instantiate(prefab);
        projectile.transform.position = args.Position;
        projectile.tag = args.IsPlayer ? "PlayerProjectile" : "EnemyProjectile";
        var projectileLogic = projectile.GetComponent<ProjectileLogic>();
        projectileLogic.Direction = args.Direction;
        projectileLogic.Speed = args.Speed;
        GameHelper.GetUILogic().Projectiles++;
    }
}

public class ProjectileSingleArgs : IProjectileArgs
{
    public virtual Type ProjectileType { get; set; } = typeof(ProjectileSingle);

    public Vector2 Direction { get; set; } = Vector2.up;
    public float Speed { get; set; } = 10f;
    public Vector2 Position { get; set; }
    public bool IsPlayer { get; set; }
    public int Cycle { get; set; }
}

