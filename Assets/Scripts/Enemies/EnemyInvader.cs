﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyInvader : MonoBehaviour
{
    Vector4 PlayfieldBounds;
    EnemyState State;
    EnemyState LastState;
    public float Speed;
    float spriteWidth;
    float spriteHeight;
    float leeway;
    [SerializeField]
    float currentHeight;
    ProjectileSpawner spawner;

    private void Start()
    {
        PlayfieldBounds = GameHelper.PlayfieldBounds;
        State = EnemyState.HorizontalRight;
        LastState = EnemyState.HorizontalRight;
        Speed = 3;
        var coll = GetComponent<BoxCollider2D>();
        spriteWidth = coll.size.x;
        spriteHeight = coll.size.y;
        leeway = 0.2f;
        currentHeight = transform.position.y;
        spawner = GetComponent<ProjectileSpawner>();
    }

    private void Update()
    {
        spawner.Spawn(new ProjectileSingleArgs()
        {
            Direction = GameHelper.DirectionFromRotation(270)
        }) ;
        spawner.Spawn(new ProjectileSingleArgs()
        {
            Direction = Vector2.down
        });

        if (State == EnemyState.Vertical)
        {
            var dist = spriteHeight + leeway;
            transform.position += new Vector3(0, -1, 0) * Time.deltaTime * Speed;
            if(transform.position.y < currentHeight - dist)
            {
                transform.position = new Vector3(transform.position.x, currentHeight - dist);
                currentHeight -= dist;
                State = LastState == EnemyState.HorizontalLeft ? EnemyState.HorizontalRight : EnemyState.HorizontalLeft;
            }
        }
        else
        {
            if(State == EnemyState.HorizontalRight)
            {
                transform.position += new Vector3(1, 0, 0) * Time.deltaTime * Speed;
                if (transform.position.x >= PlayfieldBounds.z - (spriteWidth / 2 + leeway)) State = EnemyState.Vertical;
                LastState = EnemyState.HorizontalRight;
            }
            else
            {
                transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * Speed;
                if (transform.position.x <= PlayfieldBounds.x + (spriteWidth / 2 + leeway)) State = EnemyState.Vertical;
                LastState = EnemyState.HorizontalLeft;
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
