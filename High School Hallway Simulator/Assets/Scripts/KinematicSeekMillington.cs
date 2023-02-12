using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicSeekMillington
{
    public Transform mover;
    public Transform target;
    public float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetSteering();
    }

    public KinematicSeekingOutput GetSteering()
    {
        var result = new KinematicSeekingOutput();
        result.velocity = target.position - mover.position;
        result.velocity.Normalize();
        result.velocity *= maxSpeed;
        float targetAngle = NewOrientation(mover.rotation.eulerAngles.y, result.velocity);
        mover.eulerAngles = new Vector3(0, targetAngle, 0);
        return result;
    }
    private float NewOrientation(float current, Vector3 velocity)
    {
        if (velocity.magnitude > 0)
        {
            float targetAngle = Mathf.Atan2(velocity.x, velocity.z);
            targetAngle *= Mathf.Rad2Deg;
            return targetAngle;
        }
        else
        {
            return current;
        }
    }
}
