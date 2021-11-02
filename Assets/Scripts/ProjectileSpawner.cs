using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public float Cooldown = 1f;
    bool CanShoot = true;
    public float Recharge = 0;

    private void Start()
    {
        Recharge = Cooldown;
    }

    private void Update()
    {
        if(CanShoot == false)
        {
            Recharge += Time.deltaTime * 10;
            if (Recharge >= Cooldown) CanShoot = true;
        }
    }

    public void Spawn(IProjectilePattern pattern)
    {
        if (CanShoot)
        {
            pattern.Spawn(transform.position);
            CanShoot = false;
            Recharge = 0;
        }
    }
}
