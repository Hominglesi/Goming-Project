public class ProjectileArgs
{
    public ProjectileTypes Type { get; set; }
    public float Speed { get; set; } = 10f;
    public int BounceAmount { get; set; } = 1;
}

public enum ProjectileTypes
{
    Straight,
    Bouncing
}
