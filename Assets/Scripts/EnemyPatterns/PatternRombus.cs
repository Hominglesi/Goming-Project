using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PatternRombus : IEnemyPattern
{
    public bool IsCompleted { get; set; }
    public Vector2[] Points;
    public Vector4 PlayfieldBounds;

    float width;
    float height;
    float topPadding;

    public PatternRombus()
    {
        PlayfieldBounds = GameHelper.PlayfieldBounds;
        var playfieldWidth = Vector2.Distance(new Vector2(PlayfieldBounds.x, 0), new Vector2(PlayfieldBounds.z, 0));
        var playfieldHeight = Vector2.Distance(new Vector2(0,PlayfieldBounds.y), new Vector2(0, PlayfieldBounds.w));
        width = playfieldWidth * 0.8f;
        height = playfieldHeight * 0.3f;
        topPadding = playfieldHeight * 0.1f; 

        Points = new Vector2[] {
            new Vector2((PlayfieldBounds.x + PlayfieldBounds.z) / 2 , PlayfieldBounds.y - topPadding),
            new Vector2(((PlayfieldBounds.x + PlayfieldBounds.z) / 2) - (width/2), PlayfieldBounds.y - topPadding - (height/2)),
            new Vector2((PlayfieldBounds.x + PlayfieldBounds.z) / 2, PlayfieldBounds.y - topPadding - height),
            new Vector2(((PlayfieldBounds.x + PlayfieldBounds.z) / 2) + (width/2), PlayfieldBounds.y - topPadding - (height/2))
        };

        var projectile = new ProjectileStaggeredSpreadArgs()
        {
            StaggerCount = 2,
            ShotCount = 24,
            Speed = 5
        };

        var args = new EnemyPatrollerArgs()
        {
            MovementSpeed = 2,
            Positions = Points,
            MainProjectile = projectile,
            StartPosition = 1,
            Health = 50
        };

        EnemyPatroller.Spawn(args);
        args.StartPosition = 3;
        EnemyPatroller.Spawn(args);

        IsCompleted = true;
    }

    public void Update(){ }
}