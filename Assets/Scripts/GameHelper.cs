using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameHelper
{
    public static GameObject GetPlayer()
    {
        return GameObject.FindGameObjectWithTag("Player");
    }

    public static GameObject GetGlobalObject()
    {
        return GameObject.FindGameObjectWithTag("Global");
    }

    public static Vector4 __playfieldBounds;

    public static Vector4 PlayfieldBounds
    {
        get
        {
            if (__playfieldBounds != Vector4.zero) return __playfieldBounds;
            else
            {
                var globalData = GetGlobalObject().GetComponent<GlobalData>();
                __playfieldBounds = globalData.CalculatePlayfieldBounds();
                return __playfieldBounds;
            }
        }
        set
        {
            value = __playfieldBounds;
        }
    }

    public static Vector3 NormalizeVector3(Vector3 input)
    {
        return new Vector3(input.x, input.y, 0);
    }

    public static Vector3 DirectionFromRotation(float angle) 
    { 
      return new Vector3(Mathf.Cos(angle*(Mathf.PI/180)), Mathf.Sin(angle * (Mathf.PI / 180)),0);
    }
    
}
