using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IKinematic : MonoBehaviour
{
    protected Rigidbody rb;
    [SerializeField] protected float maxAngularVelocity;
    [SerializeField] protected float maxSpeed;
    protected Vector3 direction;
    public IKinematic target;

    // Start is called before the first frame update
    public abstract void Start();

    public abstract Vector3 GetVelocityDirection();

    // Update is called once per frame
    public abstract void FixedUpdate();
}
