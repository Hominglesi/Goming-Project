using System;
using UnityEngine;

public class MikicStageSleeping : BossStageBase, IBossStage
{
    Vector2 sleepingPosition;
    float sleepHeight = -2.5f;
    float speed = 1.8f;
    float rotationSpeed = 1f;
    float targetRotation = 270;

    MovementRotateTowards rotationMovement;
    MovementMoveTowards towardsMovement;

    private void Awake()
    {
        rotationMovement = GetComponent<MovementRotateTowards>();
        towardsMovement = GetComponent<MovementMoveTowards>();
    }

    public override void OnDisabled()
    {
        rotationMovement.enabled = false;
        towardsMovement.enabled = true;
    }

    public override void OnAwake()
    {
        //Setup rotation movement
        rotationMovement.enabled = true;
        rotationMovement.RotationSpeed = rotationSpeed;
        rotationMovement.TargetRotation = targetRotation;

        //Setup towards movement
        towardsMovement.enabled = true;
        towardsMovement.MovementSpeed = speed;
        var playfieldBounds = GameHelper.PlayfieldBounds;
        var topOfScreen = new Vector2((playfieldBounds.x + playfieldBounds.z) / 2, playfieldBounds.y);
        sleepingPosition = topOfScreen + new Vector2(0, sleepHeight);
        towardsMovement.TargetDestination = sleepingPosition;

        IsDamagable = false;
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