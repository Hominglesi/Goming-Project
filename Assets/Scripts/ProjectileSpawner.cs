using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{

    public void Spawn(IProjectilePattern pattern)
    {
        pattern.Spawn(transform.position);
    }
}
