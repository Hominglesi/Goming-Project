using System;
using UnityEngine;

public class MikicStageIntroAnimation : BossStageBase, IBossStage
{
    float startHeight = 4f;
    float endHeight = -2.5f;
    float speed = 2;

    MovementMoveTowards towardsMovement;

    private void Awake()
    {
        towardsMovement = GetComponent<MovementMoveTowards>();
    }

    public override void OnDisabled()
    {
        towardsMovement.enabled = false;
    }

    public override void OnAwake()
    {
        IsDamagable = false;
        transform.rotation = Quaternion.identity;

        //Setup towards movement
        towardsMovement.enabled = true;
        var playfieldBounds = GameHelper.PlayfieldBounds;
        var topOfScreen = new Vector2((playfieldBounds.x + playfieldBounds.z) / 2, playfieldBounds.y);
        towardsMovement.TargetDestination = topOfScreen + new Vector2(0, endHeight);
        towardsMovement.MovementSpeed = speed;

        transform.position = topOfScreen + new Vector2(0, startHeight);
    }

    public void Update()
    {
        if(transform.position == (Vector3)towardsMovement.TargetDestination)
        {
            gameObject.GetComponent<MikicBossLogic>().SetStage(MikicStages.Sleeping);
        }
        
    }
}

