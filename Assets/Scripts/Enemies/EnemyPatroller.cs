using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyPatroller : EnemyLogicBase
{
    Vector2[] positions;
    int currentDestination;
    float movementSpeed;

    public new static EnemyLogicBase Spawn(IEnemyArgs args)
    {
        var prefab = Resources.Load<GameObject>("Prefabs/EnemyPatroller");
        var obj = GameObject.Instantiate(prefab);
        var logic = obj.GetComponent<EnemyPatroller>();
        logic.LoadArgs(args);
        return logic;
    }

    public override void LoadArgs(IEnemyArgs args)
    {
        base.LoadArgs(args);
        var specificArgs = (EnemyPatrollerArgs)args;
        positions = specificArgs.Positions;
        movementSpeed = specificArgs.MovementSpeed;
        currentDestination = specificArgs.StartPosition;
        transform.position = positions[currentDestination];
    }

    public override void Update()
    {
        base.Update();

        transform.position = GameHelper.MoveTowards(transform.position, positions[currentDestination], movementSpeed);
        if(Vector2.Distance(transform.position, positions[currentDestination]) < movementSpeed * Time.deltaTime)
        {
            currentDestination = (currentDestination + 1) % positions.Length;
        }
    }
}

public class EnemyPatrollerArgs : EnemyArgs
{
    public Vector2[] Positions { get; set; }
    public float MovementSpeed { get; set; } = 4;
    public int StartPosition { get; set; }
}

