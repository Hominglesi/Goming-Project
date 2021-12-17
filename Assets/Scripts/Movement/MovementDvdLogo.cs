using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDvdLogo : MonoBehaviour
{
    public Vector4 Bounds;
    public float Speed;

    float horizontalDir = 1;
    float verticalDir = 1;
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(horizontalDir * Speed * Time.deltaTime, verticalDir * Speed * Time.deltaTime);

        if (horizontalDir == -1 && transform.position.x < Bounds.x) horizontalDir *= -1;
        else if (horizontalDir == 1 && transform.position.x > Bounds.z) horizontalDir *= -1;
        if (verticalDir == 1 && transform.position.y > Bounds.y) verticalDir *= -1;
        else if (verticalDir == -1 && transform.position.y < Bounds.w) verticalDir *= -1;
    }
}
