using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{
    [SerializeField]
    RectTransform PlayfieldTransform;

    [HideInInspector]
    public Vector4 PlayfieldBounds;


    // Start is called before the first frame update
    void Start()
    {
        CalculatePlayfieldBounds();
    }

    void CalculatePlayfieldBounds()
    {
        Vector3[] bounds = new Vector3[4];
        PlayfieldTransform.GetWorldCorners(bounds);
        PlayfieldBounds = new Vector4(bounds[0].x, bounds[1].y, bounds[2].x, bounds[3].y);
    }
}
