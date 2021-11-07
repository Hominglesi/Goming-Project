using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ProjectileBouncing : IProjectilePattern
{

    public ProjectileBouncing(){ }
    public ProjectileBouncing(IProjectileArgs args) { Spawn(args); }

    public void Spawn(IProjectileArgs iArgs)
    {
        var args = (ProjectileBouncingArgs)iArgs;
        var prefab = Resources.Load<GameObject>("Prefabs/BouncingProjectilePrefab");
        var projectile = GameObject.Instantiate(prefab);
        projectile.transform.position = args.Position;
        projectile.tag = args.IsPlayer ? "PlayerProjectile" : "EnemyProjectile";
        var projectileLogic = projectile.GetComponent<BouncingProjectileLogic>();
        projectileLogic.Direction = args.Direction;
        projectileLogic.SetRotation(GameHelper.RotationFromDirection(args.Direction));
        projectileLogic.Speed = args.Speed;
        GameHelper.GetUILogic().Projectiles++;
    }
}

public class ProjectileBouncingArgs : IProjectileArgs
{
    public virtual Type ProjectileType { get; set; } = typeof(ProjectileBouncing);

    public Vector2 Direction { get; set; } = Vector2.up;
    public float Speed { get; set; } = 10f;
    public Vector2 Position { get; set; }
    public bool IsPlayer { get; set; }
    public int Cycle { get; set; }

    public virtual IProjectileArgs Clone() 
    {
        var clone = new ProjectileBouncingArgs
        {
            Direction = Direction,
            Speed = Speed,
            Position = Position,
            IsPlayer = IsPlayer,
            Cycle = Cycle
        };
        return clone;
    }
}

