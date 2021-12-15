using UnityEngine;

public class PatternBase : MonoBehaviour
{
    public float FireRate { get; set; }
    private float cooldown;
    public int ShotNumber { get; set; } = 0;

    public void Shoot(ProjectileArgs args)
    {
        if(cooldown <= 0)
        {
            OnShoot(args.Clone());
            cooldown = FireRate;
            ShotNumber++;
        }
    }

    private void Update()
    {
        if (cooldown > 0) cooldown -= Time.deltaTime * 100;
    }

    public virtual void OnShoot(ProjectileArgs args) { }
}
