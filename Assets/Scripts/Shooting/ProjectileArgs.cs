using UnityEngine;

public class ProjectileArgs
{
    public ProjectileTypes Type { get; set; }
    public float Speed { get; set; } = 10f;
    public int BounceAmount { get; set; } = 1;
    public Vector2 StartPosition { get; set; }
    public float StartPositionOffset { get; set; }
    public Vector2 Direction { get; set; }
    public float HomingStrenght { get; set; }
    public bool IsPlayerOrigin { get; set; } = false;

    public ProjectileArgs Clone()
    {
        return new ProjectileArgs()
        {
            Type = Type,
            Speed = Speed,
            BounceAmount = BounceAmount,
            StartPosition = StartPosition,
            StartPositionOffset = StartPositionOffset,
            Direction = Direction,
            HomingStrenght = HomingStrenght,
            IsPlayerOrigin = IsPlayerOrigin
        };
    }
}

public enum ProjectileTypes
{
    Straight,
    Bouncing,
    Homing
}
