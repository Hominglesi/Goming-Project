using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BouncingProjectileLogic : ProjectileLogic
{
    int remainingHits = 3;

    public override void Update()
    {
        base.Update();
        if (transform.position.x <= PlayfieldBounds.x)
        {
            Direction.x *= -1;
            SetRotation(GameHelper.RotationFromDirection(Direction));
            remainingHits--;
        }
        if (transform.position.y >= PlayfieldBounds.y) 
        {
            Direction.y *= -1;
            SetRotation(GameHelper.RotationFromDirection(Direction));
            remainingHits--;
        }
        if (transform.position.x >= PlayfieldBounds.z) 
        {
             Direction.x *= -1;
            SetRotation(GameHelper.RotationFromDirection(Direction));
            remainingHits--;
        }
        if (transform.position.y <= PlayfieldBounds.w) 
        {
            Direction.y *= -1;
            SetRotation(GameHelper.RotationFromDirection(Direction));
            remainingHits--;
        }
    }
}

