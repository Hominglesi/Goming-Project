using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PBasicProjectile : IProjectilePattern
{
    GameObject Prefab;
    public PBasicProjectile()
    {
        Prefab = Resources.Load<GameObject>("Prefabs/ProjectilePrefab");
    }
    public void Spawn(Vector2 position)
    {
        var projectile = GameObject.Instantiate(Prefab);
        projectile.transform.position = position;
        var projectileLogic = projectile.GetComponent<ProjectileLogic>();
        projectileLogic.Direction = new Vector3(0, 1, 0.5f);
        projectileLogic.Speed = 10f;
    }
}

