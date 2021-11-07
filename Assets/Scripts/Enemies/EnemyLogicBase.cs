using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyLogicBase : MonoBehaviour
{
    public float Health;
    IProjectileArgs _mainProjectile;

    public static GameObject Spawn(IEnemyArgs args)
    {
        return null;
    }

    public IProjectileArgs MainProjectile { get
        {
            return _mainProjectile;
        }
        set
        {
            _mainProjectile = value;
        }
    }

    public ProjectileSpawner spawner;

    public virtual void Start()
    {
        spawner = GetComponent<ProjectileSpawner>();
    }

    public virtual void LoadArgs(IEnemyArgs args)
    {
        Health = args.Health;
        MainProjectile = args.MainProjectile;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            Destroy(collision.gameObject);

            --Health;
            if (Health <= 0)
            {
                GameHelper.GetUILogic().EnemiesDefeated++;
                Destroy(gameObject);
                Health = 1000;
            }
        }
        
    }

    public virtual void Update()
    {
        spawner.Spawn(MainProjectile);
    }
}
public interface IEnemyArgs
{
    public float Health { get; set; }
    public IProjectileArgs MainProjectile { get; set; }
    public IEnemyArgs Clone();
}

public class EnemyArgs : IEnemyArgs
{
    public float Health { get; set; } = 25;
    public IProjectileArgs MainProjectile { get; set; }

    public virtual IEnemyArgs Clone()
    {
        var clone = new EnemyArgs
        {
            Health = Health,
            MainProjectile = MainProjectile
        };
        return clone;
    }
}



