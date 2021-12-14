using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject playArea;

    [SerializeField]
    bool hideArea = true;

    PatternBase mainPattern;
    ProjectileArgs mainProjectile;

    // Start is called before the first frame update
    void Start()
    {
        if (hideArea) playArea.GetComponent<Image>().color = new Color(0, 0, 0, 0);

        mainPattern = PatternFactory.AttachComponent(gameObject, new PatternArgs()
        {
            Type = PatternTypes.Single,
            Direction = Vector2.up,
            FireRate = 5f
        });

        mainProjectile = new ProjectileArgs()
        {
            Type = ProjectileTypes.Bouncing,
            Speed = 6f,
            BounceAmount = 10000
        };
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = GameHelper.NormalizeVector3(Input.mousePosition);
        if (IsMouseOverPlayArea(mousePos))
        {
            var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = GameHelper.NormalizeVector3(worldPos);
        }

        if (Input.GetMouseButton(0))
        {
            mainPattern.Shoot(mainProjectile);
        }
    }

    bool IsMouseOverPlayArea(Vector3 mousePos)
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current)
        {
            position = mousePos
        };
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        foreach (var item in results)
        {
            if(item.gameObject == playArea) return true;
        }
        return false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyProjectile")
        {
            Destroy(collision.gameObject);
            GameHelper.GetUILogic().PlayOof();
            GameHelper.GetUILogic().HitsTaken++;
        }
    }
}
