using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IProjectileArgs
{
    public Type ProjectileType { get; set; }
    public Vector2 Position { get; set; }
    public bool IsPlayer { get; set; }
}

