using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SpawnerInvader
{
    public SpawnerInvader(Vector2 position, float speed)
    {
        var prefab = Resources.Load<GameObject>("Prefabs/EnemyInvader");
        var obj = GameObject.Instantiate(prefab);
        var logic = obj.GetComponent<EnemyInvader>();
        obj.transform.position = position;
        logic.Speed = speed;
    }
}

