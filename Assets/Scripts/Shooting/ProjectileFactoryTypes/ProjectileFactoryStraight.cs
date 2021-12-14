using UnityEngine;

public static partial class ProjectileFactory
{
    private static string straightPrefabPath = "Prefabs/Projectiles/ProjectileStraight";
    private static GameObject straightPrefab;
    private static GameObject CreateStraight(ProjectileArgs args)
    {
        if (straightPrefab == null) straightPrefab = Resources.Load<GameObject>(bouncingPrefabPath);

        var obj = GameObject.Instantiate(straightPrefab);
        obj.GetComponent<ProjectileStraightLogic>().Initialize(args);
        return obj;
    }
}

