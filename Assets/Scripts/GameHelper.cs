using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameHelper
{
    public static GameObject GetPlayer()
    {
        return GameObject.FindGameObjectWithTag("Player");
    }

    public static Vector3 NormalizeVector3(Vector3 input)
    {
        return new Vector3(input.x, input.y, 0);
    }
}
