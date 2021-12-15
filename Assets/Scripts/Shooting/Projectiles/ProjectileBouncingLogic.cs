using UnityEngine;

public class ProjectileBouncingLogic : MonoBehaviour
{
    public Vector2 Direction;
    public float Speed;

    public int BounceAmount;
    private Vector4 playfieldBounds;

    // Start is called before the first frame update
    void Start()
    {
        playfieldBounds = GameHelper.PlayfieldBounds;
    }

    public void Initialize(ProjectileArgs args)
    {
        transform.position = args.StartPosition;
        if (args.StartPositionOffset > 0) transform.position += (Vector3)args.Direction * args.StartPositionOffset;
        Direction = args.Direction;
        SetRotation(GameHelper.RotationFromDirection(Direction));
        Speed = args.Speed;
        gameObject.tag = (args.IsPlayerOrigin) ? "PlayerProjectile" : "EnemyProjectile";

        BounceAmount = args.BounceAmount;

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
        transform.position += GameHelper.NormalizeVector3(Direction * Speed * Time.deltaTime);
        ProccessBouncing();
        if (GameHelper.CheckOffScreen(transform.position, 1f)) ProjectileFactory.Destroy(gameObject);
    }

    void ProccessBouncing()
    {
        if (BounceAmount <= 0) return;

        if (transform.position.x <= playfieldBounds.x)
        {
            Direction.x *= -1;
            SetRotation(GameHelper.RotationFromDirection(Direction));
            BounceAmount--;
        }
        if (transform.position.y >= playfieldBounds.y)
        {
            Direction.y *= -1;
            SetRotation(GameHelper.RotationFromDirection(Direction));
            BounceAmount--;
        }
        if (transform.position.x >= playfieldBounds.z)
        {
            Direction.x *= -1;
            SetRotation(GameHelper.RotationFromDirection(Direction));
            BounceAmount--;
        }
        if (transform.position.y <= playfieldBounds.w)
        {
            Direction.y *= -1;
            SetRotation(GameHelper.RotationFromDirection(Direction));
            BounceAmount--;
        }

    }

    public void SetRotation(float angle)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}

