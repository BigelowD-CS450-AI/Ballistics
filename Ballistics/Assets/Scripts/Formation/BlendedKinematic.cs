using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendedKinematic : IKinematic
{
    [SerializeField] private List<MoveType> moveTypes;
    private List<(SteeringBehaviour steeringBehaviour, float weight)> movementController = new List<(SteeringBehaviour, float)>();
    private SteeringBehaviour rotationController;

    // Start is called before the first frame update
    public override void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.maxAngularVelocity= maxAngularVelocity;
        foreach (MoveType moveType in moveTypes)
        {
            switch (moveType)
            {
                case (MoveType.sinStraight):
                    movementController.Add((new SinStraight(this), 1.0f));
                    break;
                case (MoveType.follow):
                    movementController.Add((new Follow(this, target), .2f));
                    break;
                case (MoveType.seperate):
                    movementController.Add((new Seperate(this, target), 0.9f));
                    break;
            }
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
        rb.velocity = Vector3.zero;
        foreach ((SteeringBehaviour, float) blendedSteeringBehaviour in movementController)
        {
            rb.velocity += blendedSteeringBehaviour.Item1.GetSteering().velocity * blendedSteeringBehaviour.Item2;
        }
        rb.velocity = rb.velocity.normalized * maxSpeed;
        if (rb.velocity != Vector3.zero)
            direction = rb.velocity.normalized;
        transform.rotation = Quaternion.Euler(0.0f, rotationController.GetSteering().angularVelocity, 0.0f);
        
    }
}
