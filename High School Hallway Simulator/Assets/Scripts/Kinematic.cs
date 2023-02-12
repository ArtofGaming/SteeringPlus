using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinematic : MonoBehaviour
{
    Vector3 velocity;
    float rotation;

    private KinematicSeekMillington mySteering;
    public Transform myTarget;
    public float myMaxSpeed = 400f;

    // Start is called before the first frame update
    void Start()
    {
        mySteering = new KinematicSeekMillington();
        mySteering.target = myTarget;
        mySteering.mover = this.transform;
        mySteering.maxSpeed= myMaxSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        KinematicSeekingOutput steering = mySteering.GetSteering();
        KinematicUpdate(steering, Time.deltaTime);
    }

    void KinematicUpdate(KinematicSeekingOutput steering, float time)
    {
        velocity += steering.velocity * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;


    }
}
