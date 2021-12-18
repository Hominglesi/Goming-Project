using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    PatternBase mainPattern;
    ProjectileArgs mainProjectile;

    Vector4 playfieldBounds;

    // Start is called before the first frame update
    void Start()
    {
        playfieldBounds = GameHelper.PlayfieldBounds;
        gameObject.GetComponent<BulletListener>().OnHit += OnHit;

        mainPattern = PatternFactory.AttachComponent(gameObject, new PatternArgs()
        {
            Type = PatternTypes.Single,
            ShotCount = 6,
            Direction = Vector2.up,
            FireRate = 10f
        });

        mainProjectile = new ProjectileArgs()
        {
            Type = ProjectileTypes.Straight,
            Speed = 8f,
            IsPlayerOrigin = true
        };
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = GameHelper.NormalizeVector3(Input.mousePosition);
        var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        var clampedWorldPos = new Vector3(Mathf.Clamp(worldPos.x, playfieldBounds.x, playfieldBounds.z), Mathf.Clamp(worldPos.y, playfieldBounds.w, playfieldBounds.y));
        transform.position = clampedWorldPos;


        if (Input.GetMouseButton(0))
        {
            mainPattern.Shoot(mainProjectile);
        }
    }

    private void OnHit()
    {
        GameHelper.GetUILogic().PlayOof();
        GameHelper.GetUILogic().HitsTaken++;
    }
}
