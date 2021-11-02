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

    ProjectileSpawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        if (hideArea) playArea.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        spawner = GetComponent<ProjectileSpawner>();
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

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("aa");
            spawner.Spawn(new PBasicProjectile());
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
}
