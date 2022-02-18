using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinematic : IKinematic
{
    private SteeringBehaviour rotationController;
    private SteeringBehaviour movementController;

    [SerializeField] protected MoveType moveType;

    // Start is called before the first frame update
    public override void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.maxAngularVelocity= maxAngularVelocity;
        switch (moveType)
        {
            case (MoveType.sinStraight):
                movementController = new SinStraight(this);
                break;
            case (MoveType.follow):
                movementController = new Follow(this, target);
                break;
            case (MoveType.seperate):
                movementController = new Seperate(this, target);
                break;
        }
        rotationController = new LookWhereGoing(this);
    }

    public override Vector3 GetVelocityDirection()
    {
        return direction;
    }

    // Update is called once per frame
    public override void FixedUpdate()
    {
        //Debug.Log("IEXSIST");
        // rb.angularVelocity = new Vector3(0.0f, rotationType.GetSteering().angularVelocity, 0.0f);
        Debug.Log(rb);
        rb.velocity = movementController.GetSteering().velocity * maxSpeed;
        Debug.Log("vel : " + rb.velocity);
        if (rb.velocity != Vector3.zero)
            direction = rb.velocity.normalized;
        transform.rotation = Quaternion.Euler(0.0f, rotationController.GetSteering().angularVelocity, 0.0f);
    }
}

public enum MoveType
{
    sinStraight, follow, seperate
}
