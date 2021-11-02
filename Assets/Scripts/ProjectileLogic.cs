using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLogic : MonoBehaviour
{
    public float Speed;
    public Vector3 Direction;
    Vector4 PlayfieldBounds;

    private void Start()
    {
        //TODO: Jako cesto ce ovo biti callovano a kinda je resource intensive
        PlayfieldBounds = GameHelper.GetGlobalData().PlayfieldBounds;
    }
    
    void Update()
    {
        transform.position += GameHelper.NormalizeVector3(Direction * Speed * Time.deltaTime);
        if (CheckOffScreen()) Destroy(gameObject);
    }

    bool CheckOffScreen()
    {
        var pos = transform.position;
        float leeway = 0.5f;
        if (pos.x + leeway < PlayfieldBounds.x) return true;
        if (pos.y - leeway > PlayfieldBounds.y) return true;
        if (pos.x - leeway > PlayfieldBounds.z) return true;
        if (pos.y + leeway < PlayfieldBounds.w) return true;
        return false;
    }
}
