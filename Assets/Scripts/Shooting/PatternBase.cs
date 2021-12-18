using UnityEngine;

public class PatternBase : MonoBehaviour
{
    public float FireRate { get; set; }
    private float cooldown;
    public int ShotNumber { get; set; } = 0;

    public virtual void Initialize(PatternArgs args) { }

    public GameObject[] Shoot(ProjectileArgs args)
    {
        if(cooldown <= 0)
        {
            cooldown = FireRate;
            ShotNumber++;
            return OnShoot(args.Clone());
        }
        else
        {
            return null;
        }
    }

    private void Update()
    {
        if (cooldown > 0) cooldown -= Time.deltaTime * 100;
    }

    public virtual GameObject[] OnShoot(ProjectileArgs args) { return null; }
}
