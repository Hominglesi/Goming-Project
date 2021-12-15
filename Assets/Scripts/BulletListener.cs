using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletListener : MonoBehaviour
{
    public Action OnHit { get; set; }

    private bool isPlayer = false;

    private void Start()
    {
        if (gameObject.tag == "Player") isPlayer = true;
        else if (gameObject.tag != "Enemy") throw new Exception("GameObject tag must be 'Player' or 'Enemy' for it to have a BulletListener");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (isPlayer) Debug.Log("a");
        if(isPlayer && col.tag == "EnemyProjectile" || isPlayer == false && col.tag == "PlayerProjectile")
        {
            ProjectileFactory.Destroy(col.gameObject);
            OnHit?.Invoke();
        }
    }
}
