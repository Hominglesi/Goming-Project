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
        //remove this 
        Direction = Vector2.one;
        Speed = args.Speed;

        BounceAmount = args.BounceAmount;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += GameHelper.NormalizeVector3(Direction * Speed * Time.deltaTime);
        ProccessBouncing();
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

