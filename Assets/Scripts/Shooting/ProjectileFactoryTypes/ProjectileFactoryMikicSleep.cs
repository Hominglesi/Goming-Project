using UnityEngine;

public static partial class ProjectileFactory
{
    private static string mikicSleepPrefabPath = "Prefabs/Projectiles/ProjectileMikicSleep";
    private static GameObject mikicSleepPrefab;
    private static GameObject CreateMikicSleep(ProjectileArgs args)
    {
        if (mikicSleepPrefab == null) mikicSleepPrefab = Resources.Load<GameObject>(mikicSleepPrefabPath);

        var obj = GameObject.Instantiate(mikicSleepPrefab);
        obj.GetComponent<ProjectileMikicSleepLogic>().Initialize(args);

        return obj;
    }
}

