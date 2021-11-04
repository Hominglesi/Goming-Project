using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ProjectileSingle : IProjectilePattern
{
    GameObject Prefab;
    Vector2 direction;
    public ProjectileSingle(Vector2 direction)
    {
        Prefab = Resources.Load<GameObject>("Prefabs/ProjectilePrefab");
        this.direction = direction;
    }
    public void Spawn(Vector2 position, bool isPlayer)
    {
        var projectile = GameObject.Instantiate(Prefab);
        projectile.transform.position = position;
        projectile.tag = isPlayer ? "PlayerProjectile" : "EnemyProjectile";
        var projectileLogic = projectile.GetComponent<ProjectileLogic>();
        projectileLogic.Direction = direction;
        projectileLogic.Speed = 10f;
        GameHelper.GetUILogic().Projectiles++;
    }
}

