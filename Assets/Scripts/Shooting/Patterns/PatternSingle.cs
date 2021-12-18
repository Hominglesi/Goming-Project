using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PatternSingle : PatternBase
{
    public Vector2 direction;

    public override void Initialize(PatternArgs args)
    {
        FireRate = args.FireRate;
        direction = args.Direction;
    }

    public override GameObject[] OnShoot(ProjectileArgs args)
    {
        args.StartPosition = transform.position;
        args.Direction = direction;
        return new GameObject[] { ProjectileFactory.Create(args) };
    }
}

