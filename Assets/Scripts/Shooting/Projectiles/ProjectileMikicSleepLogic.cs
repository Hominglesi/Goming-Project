using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMikicSleepLogic : MonoBehaviour
{
    public Vector2 firstTarget;
    public Vector2 secondDirection;
    public float Speed;
    public float Speed2;
    public bool isSecondStage;
    float waitTimer;
    float missOffset;

    public void Initialize(ProjectileArgs args)
    {
        transform.position = args.StartPosition;
        firstTarget = args.TargetDestination;
        waitTimer = args.WaitTime;
        missOffset = args.OffsetRange;
        Speed = args.Speed;
        Speed2 = args.Speed2;
        gameObject.tag = (args.IsPlayerOrigin) ? "PlayerProjectile" : "EnemyProjectile";
        isSecondStage = false;

        var dirAngle = GameHelper.GetAngleBetweenPoints(transform.position, firstTarget);
        var direction = GameHelper.DirectionFromRotation(dirAngle);
        if (args.StartPositionOffset > 0) transform.position += direction * args.StartPositionOffset;
        SetRotation(dirAngle);

        if (args.SpritePath != null)
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(args.SpritePath);

        if (args.CustomCollider == true)
        {
            gameObject.GetComponent<BoxCollider2D>().size = args.ColliderSize;
            gameObject.GetComponent<BoxCollider2D>().offset = args.ColliderOffset;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(waitTimer > 0)
        {
            transform.position = GameHelper.MoveTowards(transform.position, firstTarget, Speed);
            waitTimer -= Time.deltaTime;
        }
        else
        {
            if(isSecondStage == false)
            {
                var targetPos = GameHelper.GetPlayer().transform.position + new Vector3(Random.Range(-missOffset, missOffset), 0);
                var dirAngle = GameHelper.GetAngleBetweenPoints(transform.position, targetPos);
                secondDirection = GameHelper.DirectionFromRotation(dirAngle);
                SetRotation(dirAngle);
                isSecondStage = true;
            }
            transform.position += GameHelper.NormalizeVector3(secondDirection * Speed2 * Time.deltaTime);
            if (GameHelper.CheckOffScreen(transform.position, 0.5f)) ProjectileFactory.Destroy(gameObject);
        }
    }

    public void SetRotation(float angle)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
