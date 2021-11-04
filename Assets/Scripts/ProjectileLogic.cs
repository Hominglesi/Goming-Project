using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLogic : MonoBehaviour
{
    public ProjectileOrigin Origin;
    public float Speed;
    public Vector3 Direction;
    Vector4 PlayfieldBounds;


    private void Start()
    {
        PlayfieldBounds = GameHelper.PlayfieldBounds;
    }

    void Update()
    {
        transform.position += GameHelper.NormalizeVector3(Direction * Speed * Time.deltaTime);
        if (CheckOffScreen())
        {
            Destroy(gameObject);
        }
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

    private void OnDestroy()
    {
        //We dont care if there is no UI because that means the game is closed
        try{ GameHelper.GetUILogic().Projectiles--; }
        catch (NullReferenceException) { }
        
    }
}

public enum ProjectileOrigin
{
    Player,
    Enemy
}
