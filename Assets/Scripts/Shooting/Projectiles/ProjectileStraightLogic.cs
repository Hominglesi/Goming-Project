using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStraightLogic : MonoBehaviour, IProjectile
{
    public Vector2 Direction;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Initialize(ProjectileArgs args)
    {
        transform.position = args.StartPosition;
        if (args.StartPositionOffset > 0) transform.position += (Vector3)args.Direction * args.StartPositionOffset; 
        Direction = args.Direction;
        SetRotation(GameHelper.RotationFromDirection(Direction));
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
        transform.position += GameHelper.NormalizeVector3(Direction * Speed * Time.deltaTime);
        if (GameHelper.CheckOffScreen(transform.position, 0.5f)) ProjectileFactory.Destroy(gameObject);
    }

    public void SetRotation(float angle)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
