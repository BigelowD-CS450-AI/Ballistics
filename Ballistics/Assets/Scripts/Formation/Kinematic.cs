using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinematic : MonoBehaviour
{
    private Rigidbody rb;
    private const float maxAngularVelocity = Mathf.Deg2Rad * 180.0f;
    private const float maxSpeed = 5.0f;
    LookWhereGoing rotationType;
    SinStraight moveType;
    // Start is called before the first frame update
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.maxAngularVelocity= maxAngularVelocity;
        rotationType = new LookWhereGoing(this);
        moveType = new SinStraight(this);
    }

    public Vector3 GetVelocity()
    {
        return rb.velocity.normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // rb.angularVelocity = new Vector3(0.0f, rotationType.GetSteering().angularVelocity, 0.0f);
        transform.rotation = Quaternion.Euler(0.0f, rotationType.GetSteering().angularVelocity, 0.0f);
        rb.velocity = moveType.GetSteering().velocity * maxSpeed;
    }
}
