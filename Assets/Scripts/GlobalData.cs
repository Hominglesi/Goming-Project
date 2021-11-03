using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{
    [SerializeField]
    RectTransform PlayfieldTransform;

    public Vector4 CalculatePlayfieldBounds()
    {
        Vector3[] bounds = new Vector3[4];
        PlayfieldTransform.GetWorldCorners(bounds);
        return new Vector4(bounds[0].x, bounds[1].y, bounds[2].x, bounds[3].y);
    }
}
