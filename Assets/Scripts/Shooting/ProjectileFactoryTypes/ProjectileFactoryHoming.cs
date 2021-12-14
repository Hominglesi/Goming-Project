using UnityEngine;

public static partial class ProjectileFactory
{
    private static string homingPrefabPath = "Prefabs/Projectiles/ProjectileHoming";
    private static GameObject homingPrefab;
    private static GameObject CreateHoming(ProjectileArgs args)
    {
        if (homingPrefab == null) homingPrefab = Resources.Load<GameObject>(homingPrefabPath);

        var obj = GameObject.Instantiate(homingPrefab);
        obj.GetComponent<ProjectileHomingLogic>().Initialize(args);

        return obj;
    }
}
