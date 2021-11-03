using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    Vector4 PlayfieldBounds;
    EnemyState State;
    float Speed;

    private void Start()
    {
        PlayfieldBounds = GameHelper.PlayfieldBounds;
        State = EnemyState.HorizontalRight;
        Speed = 3;
    }

    private void Update()
    {
        if(State == EnemyState.Vertical)
        {
            
        }
        else
        {
            if(State == EnemyState.HorizontalRight)
            {
                transform.position += new Vector3(1, 0, 0) * Time.deltaTime * Speed;
                if (transform.position.x >= PlayfieldBounds.z) State = EnemyState.HorizontalLeft;
            }
            else
            {
                transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * Speed;
                if (transform.position.x <= PlayfieldBounds.x) State = EnemyState.HorizontalRight;
            }
        }
    }
}

enum EnemyState
{
    HorizontalLeft,
    HorizontalRight,
    Vertical
}
