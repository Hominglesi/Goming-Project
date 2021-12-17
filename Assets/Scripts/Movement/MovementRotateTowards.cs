using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRotateTowards : MonoBehaviour
{
    public float TargetRotation;
    public float RotationSpeed;

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.eulerAngles.z == TargetRotation) return;

        var dist = Mathf.DeltaAngle(transform.rotation.eulerAngles.z, TargetRotation);
        var absDist = Mathf.Abs(dist);
        var dir = dist < 0 ? -1 : 1;
        var speed = RotationSpeed * 100 * Time.deltaTime;

        if(absDist < speed)
        {
            SetAngle(TargetRotation);
        }
        else
        {
            var newAngle = transform.rotation.eulerAngles.z + (speed * dir);
            SetAngle(newAngle);
        }
    }

    private void SetAngle(float angle) => transform.rotation = Quaternion.Euler(0, 0, angle);
}
