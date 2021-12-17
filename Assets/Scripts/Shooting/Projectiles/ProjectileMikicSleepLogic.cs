using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMikicSleepLogic : MonoBehaviour
{
    public Vector2 firstTarget;
    public Vector2 secondDirection;
    public float secondDirOffset = 2;
    public float Speed;
    public bool Activated = false;

    public void Initialize(ProjectileArgs args)
    {
        transform.position = args.StartPosition;
        firstTarget = args.TargetDestination;
        var dirAngle = GameHelper.GetAngleBetweenPoints(transform.position, firstTarget);
        var direction = GameHelper.DirectionFromRotation(dirAngle);
        if (args.StartPositionOffset > 0) transform.position += direction * args.StartPositionOffset;
        SetRotation(dirAngle);
        Speed = args.Speed;
        gameObject.tag = (args.IsPlayerOrigin) ? "PlayerProjectile" : "EnemyProjectile";

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
        if(Activated == false)
        {
            transform.position = (Vector3)GameHelper.MoveTowards(transform.position, firstTarget, Speed);
        }
        else
        {
            transform.position += GameHelper.NormalizeVector3(secondDirection * Speed * Time.deltaTime);
        }

        if (GameHelper.CheckOffScreen(transform.position, 0.5f)) ProjectileFactory.Destroy(gameObject);
    }

    public void Activate()
    {
        Activated = true;
        var targetPos = GameHelper.GetPlayer().transform.position + new Vector3(Random.Range(-secondDirOffset, secondDirOffset), 0);
        var dirAngle = GameHelper.GetAngleBetweenPoints(transform.position, targetPos);
        secondDirection = GameHelper.DirectionFromRotation(dirAngle);
        SetRotation(dirAngle);
    }

    public void SetRotation(float angle)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
