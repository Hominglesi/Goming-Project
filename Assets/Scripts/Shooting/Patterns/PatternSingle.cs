using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PatternSingle : PatternBase
{
    public Vector2 direction;

    public void Initialize(PatternArgs args)
    {
        FireRate = args.FireRate;
        direction = args.Direction;
    }

    public override void OnShoot(ProjectileArgs args)
    {
        args.StartPosition = transform.position;
        args.Direction = direction;
        ProjectileFactory.Create(args);
    }
}

