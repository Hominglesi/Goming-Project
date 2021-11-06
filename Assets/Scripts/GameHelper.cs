using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameHelper
{
    public static GameObject GetPlayer()
        => GameObject.FindGameObjectWithTag("Player");
    public static GameObject GetGlobalObject()
        => GameObject.FindGameObjectWithTag("Global");
    public static UILogic GetUILogic()
        => GetGlobalObject().GetComponent<UILogic>();

    public static Vector4 __playfieldBounds;

    public static Vector4 PlayfieldBounds
    {
        get
        {
            if (__playfieldBounds != Vector4.zero) return __playfieldBounds;
            else
            {
                __playfieldBounds = CalculateRectBounds(GetUILogic().PlayfieldTransform);
                return __playfieldBounds;
            }
        }
        set
        {
            __playfieldBounds = value;
        }
    }

    public static Vector3 NormalizeVector3(Vector3 input)
    {
        return new Vector3(input.x, input.y, 0);
    }

    //TODO: Check if we can just change return type to Vector2
    public static Vector3 DirectionFromRotation(float angle) 
    {
        var radians = angle * (Mathf.PI / 180);
        return new Vector3(Mathf.Cos(radians), Mathf.Sin(radians),0);
    }
    public static float RotationFromDirection(Vector3 direction)
    {
        var radians = Mathf.Atan2(direction.y, direction.x);
        return radians / (Mathf.PI / 180);
    }

    public static float GetAngleBetweenPoints(Vector2 start, Vector2 end)
    {
        return Mathf.Atan2(end.y - start.y, end.x - start.x) * (180 / Mathf.PI);
    }

    public static Vector4 CalculateRectBounds(RectTransform rect)
    {
        Vector3[] bounds = new Vector3[4];
        rect.GetWorldCorners(bounds);
        return new Vector4(bounds[0].x, bounds[1].y, bounds[2].x, bounds[3].y);
    }

    public static Vector2 MoveTowards(Vector2 start, Vector2 end, float speed)
    {
        var angle = GetAngleBetweenPoints(start, end);
        return start + (Vector2)(DirectionFromRotation(angle) * speed * Time.deltaTime);
    }
}
