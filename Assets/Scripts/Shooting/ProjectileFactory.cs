using System;
using System.Collections.Generic;
using UnityEngine;

public static partial class ProjectileFactory
{
    public static GameObject Create(ProjectileArgs args)
    {
        GameHelper.GetUILogic().Projectiles++;

        var prefab = GetPrefab(args.Type.ToString());
        if(prefab is null) throw new NotImplementedException($"Could not find prefab {args.Type} in directory {projectilePrefabPath}");

        var obj = GameObject.Instantiate(prefab);
        obj.GetComponent<IProjectile>().Initialize(args);

        return obj;
    }

    private static Dictionary<string, GameObject> prefabDictionary = new Dictionary<string, GameObject>();
    private static string projectilePrefabPath = "Prefabs/Projectiles/Projectile";
    private static GameObject GetPrefab(string name)
    {
        if (prefabDictionary.ContainsKey(name)) return prefabDictionary[name];
        else
        {
            var prefabPath = projectilePrefabPath + name;
            var prefab = Resources.Load<GameObject>(prefabPath);
            prefabDictionary.Add(name, prefab);
            return prefab;
        }
            
    }

    public static void Destroy(GameObject projectile)
    {
        GameObject.Destroy(projectile);

        //We dont care if there is no UI because that means the game is closed
        try { GameHelper.GetUILogic().Projectiles--; }
        catch (NullReferenceException) { }
    }
}

