using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ProjectileStaggeredSpread : IProjectilePattern
{
    public ProjectileStaggeredSpread() { }
    public ProjectileStaggeredSpread(IProjectileArgs args) { Spawn(args); }

    public void Spawn(IProjectileArgs iArgs)
    {
        var args = (ProjectileStaggeredSpreadArgs)iArgs;
        var angleSlice = (360f / args.ShotCount) / args.StaggerCount;
        var angle = GameHelper.RotationFromDirection(args.Direction);
        var stage = args.Cycle % args.StaggerCount;

        args.Direction = GameHelper.DirectionFromRotation(angle + (stage * angleSlice));
        new ProjectileSpread(args);
    }
}

public class ProjectileStaggeredSpreadArgs : ProjectileSpreadArgs
{
    public override Type ProjectileType { get; set; } = typeof(ProjectileStaggeredSpread);
    public float StaggerCount { get; set; }
}

