using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ProjectileHomingLogic : MonoBehaviour, IProjectile
{
    public Vector2 CurrentDirection;
    public float Speed;
    public float homingStrength;

    public Transform CurrentTarget;

    // Start is called before the first frame update
    void Start()
    {
        CurrentTarget = GameHelper.GetPlayer().transform;
    }

    public void Initialize(ProjectileArgs args)
    {
        transform.position = args.StartPosition;
        if (args.StartPositionOffset > 0) transform.position += (Vector3)args.Direction * args.StartPositionOffset;
        homingStrength = args.HomingStrenght;
        CurrentDirection = args.Direction;
        Speed = args.Speed;
        gameObject.tag = (args.IsPlayerOrigin) ? "PlayerProjectile" : "EnemyProjectile";

        if (args.SpritePath != null)
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(args.SpritePath);

        if (args.ColliderSize != null)
            gameObject.GetComponent<BoxCollider2D>().size = args.ColliderSize;

        if (args.ColliderOffset != null)
            gameObject.GetComponent<BoxCollider2D>().offset = args.ColliderOffset;
    }

    // Update is called once per frame
    void Update()
    {
        var desiredDirection = GameHelper.GetAngleBetweenPoints(transform.position, CurrentTarget.position);
        float newAngle = Mathf.LerpAngle(GameHelper.RotationFromDirection(CurrentDirection), desiredDirection, (homingStrength / 100) * Time.deltaTime);

        CurrentDirection = GameHelper.DirectionFromRotation(newAngle);
        SetRotation(newAngle);
        transform.position += GameHelper.NormalizeVector3(CurrentDirection * Speed * Time.deltaTime);
    }

    public void SetRotation(float angle)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}

