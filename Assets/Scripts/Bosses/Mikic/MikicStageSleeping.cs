using System;
using UnityEngine;

public class MikicStageSleeping : MonoBehaviour, IBossStage
{
    Vector2 sleepingPosition;
    float sleepHeight = -2.5f;
    float speed = 1.8f;
    float rotationSpeed = 1f;
    float targetRotation = 270;

    MovementRotateTowards rotationMovement;
    MovementMoveTowards towardsMovement;

    public void SetActive(bool active)
    {
        if (active == false && enabled == true) OnDisabled();
        enabled = active;
        if (active) OnAwake();
    }

    public void OnDisabled()
    {
        if (rotationMovement != null) Destroy(rotationMovement);
        if (towardsMovement != null) Destroy(towardsMovement);
    }

    public void OnAwake()
    {
        //Setup rotation movement
        rotationMovement = gameObject.AddComponent<MovementRotateTowards>();
        rotationMovement.RotationSpeed = rotationSpeed;
        rotationMovement.TargetRotation = targetRotation;

        //Setup towards movement
        towardsMovement = gameObject.AddComponent<MovementMoveTowards>();
        towardsMovement.MovementSpeed = speed;
        var playfieldBounds = GameHelper.PlayfieldBounds;
        var topOfScreen = new Vector2((playfieldBounds.x + playfieldBounds.z) / 2, playfieldBounds.y);
        sleepingPosition = topOfScreen + new Vector2(0, sleepHeight);
        towardsMovement.TargetDestination = sleepingPosition;

        gameObject.GetComponent<MikicBossLogic>().IsDamageable = false;
    }

    public void Update()
    {
        var isPositionCorrect = (Vector2)transform.position == sleepingPosition;
        var isRotationCorrect = GameHelper.NormalizeRotation(transform.rotation.eulerAngles.z) == targetRotation;

        if (isPositionCorrect && isRotationCorrect)
        {
            gameObject.GetComponent<MikicBossLogic>().SetStage(MikicStages.WakingUp);
        }
    }
}