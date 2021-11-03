using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpread : IProjectilePattern
{
    GameObject Prefab;
    public ProjectileSpread()
    {
        Prefab = Resources.Load<GameObject>("Prefabs/ProjectilePrefab");
    }
    public void Spawn(Vector2 position, bool isPlayer)
    {
        SpreadProjectile(30,10f,position, isPlayer);
    }
    public void SpreadProjectile(int Bullets,float speed, Vector2 position, bool isPlayer)
    {
        for (int i = 0; i < Bullets; i++)
        {
            float range= i*(360 / Bullets);
            if (range >= 360) range=range - 360;
            var projectile = GameObject.Instantiate(Prefab);
            projectile.transform.position = position;
            projectile.tag = isPlayer ? "PlayerProjectile" : "EnemyProjectile";
            var projectileLogic = projectile.GetComponent<ProjectileLogic>();
            projectileLogic.Direction = GameHelper.DirectionFromRotation(range);
            projectileLogic.Speed = speed;
        }
    }
}
