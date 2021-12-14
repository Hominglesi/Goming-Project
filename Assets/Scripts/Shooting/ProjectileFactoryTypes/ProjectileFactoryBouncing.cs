using UnityEngine;

public static partial class ProjectileFactory
{
    private static string bouncingPrefabPath = "Prefabs/Projectiles/ProjectileBouncing";
    private static GameObject bouncingPrefab;
    private static GameObject CreateBouncing(ProjectileArgs args)
    {
        if (bouncingPrefab == null) bouncingPrefab = Resources.Load<GameObject>(bouncingPrefabPath);

        var obj = GameObject.Instantiate(bouncingPrefab);
        obj.GetComponent<ProjectileBouncingLogic>().Initialize(args);
        return obj;
    }
}
