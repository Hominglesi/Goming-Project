using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ProjectileBasic : IProjectilePattern
{
    GameObject Prefab;
    public ProjectileBasic()
    {
        Prefab = Resources.Load<GameObject>("Prefabs/ProjectilePrefab");
    }
    public void Spawn(Vector2 position, bool isPlayer)
    {
        var projectile = GameObject.Instantiate(Prefab);
        projectile.transform.position = position;
        projectile.tag = isPlayer ? "PlayerProjectile" : "EnemyProjectile";
        var projectileLogic = projectile.GetComponent<ProjectileLogic>();
        projectileLogic.Direction = new Vector3(0, 1, 0.5f);
        projectileLogic.Speed = 10f;
    }
}

