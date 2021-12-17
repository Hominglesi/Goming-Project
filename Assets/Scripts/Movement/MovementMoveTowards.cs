using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMoveTowards : MonoBehaviour
{
    public Vector2 TargetDestination;
    public float MovementSpeed;

    // Update is called once per frame
    void Update()
    {
        if((Vector2)transform.position != TargetDestination)
            transform.position = GameHelper.MoveTowards(transform.position, TargetDestination, MovementSpeed);
    }
}
