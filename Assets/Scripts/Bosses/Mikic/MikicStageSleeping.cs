using System;
using UnityEngine;

public class MikicStageSleeping : MonoBehaviour, IBossStage
{
    Vector2 middlePosition;
    float sleepHeight = -2.5f;
    float speed = 1.8f;
    float rotationSpeed = 1f;
    float rotationT;
    float targetRotation = -90;
    float startRotation;

    public void SetActive(bool active)
    {
        enabled = active;
        if (active) OnAwake();
    }

    public void OnAwake()
    {
        gameObject.GetComponent<MikicBossLogic>().IsDamageable = false;
        var playfieldBounds = GameHelper.PlayfieldBounds;
        var topOfScreen = new Vector2((playfieldBounds.x + playfieldBounds.z) / 2, playfieldBounds.y);
        middlePosition = topOfScreen + new Vector2(0, sleepHeight);
        transform.rotation = Quaternion.identity;
        startRotation = transform.rotation.eulerAngles.z;
        rotationT = 0;
    }

    public void Update()
    {
        if((Vector2)transform.position != middlePosition)
        {
            transform.position = GameHelper.MoveTowards(transform.position, middlePosition, speed);
        }
        if(transform.rotation.eulerAngles.z != targetRotation)
        {
            float newAngle = Mathf.LerpAngle(startRotation, targetRotation, rotationT);
            transform.rotation = Quaternion.Euler(0, 0, newAngle);
            rotationT += rotationSpeed * Time.deltaTime;
        }

        if ((Vector2)transform.position == middlePosition && transform.rotation.eulerAngles.z == targetRotation + 360)
        {
            gameObject.GetComponent<MikicBossLogic>().SetStage(MikicStages.WakingUp);
        }
    }
}