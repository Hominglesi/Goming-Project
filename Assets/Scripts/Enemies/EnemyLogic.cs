using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public Queue<Vector2> Destinations = new Queue<Vector2>();
    public float MovementSpeed = 10f;
    IProjectileArgs _projectiles;
    public IProjectileArgs Projectiles { get
        {
            return _projectiles;
        }
        set
        {
            _projectiles = value;
            Debug.Log(((ProjectileStaggeredSpreadArgs)_projectiles).Speed);
        }
    }
    public ProjectileSpawner spawner;

    float Health = 250;

    private void Start()
    {
        spawner = GetComponent<ProjectileSpawner>();
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            Destroy(collision.gameObject);

            --Health;
            if (Health == 0)
            {
                GameHelper.GetUILogic().EnemiesDefeated++;
                Destroy(gameObject);
            }
        }
        
    }

    private void Update()
    {
        spawner.Spawn(Projectiles);

        if (Destinations.Count == 0) return;
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var angle = GameHelper.GetAngleBetweenPoints(transform.position, Destinations.Peek());
        transform.position += GameHelper.DirectionFromRotation(angle) * MovementSpeed * Time.deltaTime;
        if (Vector2.Distance(transform.position, Destinations.Peek()) < MovementSpeed * Time.deltaTime)
        {
            Destinations.Dequeue();
        }
    }
}

