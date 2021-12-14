using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStraightLogic : MonoBehaviour
{
    public Vector2 Direction;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Initialize(ProjectileArgs args)
    {
        //remove this 
        Direction = Vector2.one;
        Speed = args.Speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += GameHelper.NormalizeVector3(Direction * Speed * Time.deltaTime);
    }
}
