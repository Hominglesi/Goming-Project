using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PTripleProjectile : IProjectilePattern
{
    GameObject Prefab;
    public PTripleProjectile()
    {
        Prefab = Resources.Load<GameObject>("Prefabs/ProjectilePrefab");
    }
    public void Spawn(Vector2 position)
    {

        var projectile1 = GameObject.Instantiate(Prefab);
        var projectile2 = GameObject.Instantiate(Prefab);
        var projectile3 = GameObject.Instantiate(Prefab);
        projectile1.transform.position = position;
        projectile2.transform.position = position;
        projectile3.transform.position = position;
        var projectileLogic1 = projectile1.GetComponent<ProjectileLogic>();
        var projectileLogic2 = projectile2.GetComponent<ProjectileLogic>();
        var projectileLogic3 = projectile3.GetComponent<ProjectileLogic>();
        projectileLogic1.Direction = GameHelper.DirectionFromRotation(90);
        projectileLogic1.Speed = 10f;
        projectileLogic2.Direction = GameHelper.DirectionFromRotation(80);
        projectileLogic2.Speed = 10f;
        projectileLogic3.Direction = GameHelper.DirectionFromRotation(100);
        projectileLogic3.Speed = 10f;
    }
}
