using System;
using UnityEngine;

public class MikicStageIntroAnimation : MonoBehaviour, IBossStage
{
    public Action OnFinished { get; set; }

    float startHeight = 4f;
    float endHeight = -2.5f;
    float speed = 2;
    Vector2 targetPosition;
    public void SetActive(bool active)
    {
        enabled = active;
        if (active) OnAwake();
        gameObject.GetComponent<MikicBossLogic>().IsDamageable = false;
    }

    public void OnAwake()
    {
        var playfieldBounds = GameHelper.PlayfieldBounds;
        var topOfScreen = new Vector2((playfieldBounds.x + playfieldBounds.z)/2, playfieldBounds.y);
        transform.position = topOfScreen + new Vector2(0, startHeight);
        targetPosition = topOfScreen + new Vector2(0, endHeight);
    }

    public void Update()
    {
        Debug.Log(transform.position);
        transform.position = GameHelper.MoveTowards(transform.position, targetPosition, speed);
        if(transform.position == (Vector3)targetPosition)
        {
            gameObject.GetComponent<MikicBossLogic>().SetStage(MikicStages.Basic);
        }
        
    }
}

