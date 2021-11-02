using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSpreadProjectile :IProjectilePattern
{
    GameObject Prefab;
    public PSpreadProjectile()
    {
        Prefab = Resources.Load<GameObject>("Prefabs/ProjectilePrefab");
    }
    public void Spawn(Vector2 position)
    {
        SpreadProjectile(30,10f,position);
    }
    public void SpreadProjectile(int Bullets,float speed, Vector2 position)
    {
        for (int i = 0; i < Bullets; i++)
        {
            float range= i*(360 / Bullets);
            if (range >= 360) range=range - 360;
            var projectile = GameObject.Instantiate(Prefab);
            projectile.transform.position = position;
            var projectileLogic = projectile.GetComponent<ProjectileLogic>();
            projectileLogic.Direction = GameHelper.DirectionFromRotation(range);
            projectileLogic.Speed = speed;
        }
    }
}
