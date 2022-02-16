using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Vector3 launchDirection;
    [SerializeField] private float launchSpeed;
    [SerializeField] private GameObject target;
    private bool hasLaunched = false;
    private Rigidbody rb;
    private Vector3 delta;
    private Vector2 times;

    public void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = false;
        delta = target.transform.position - transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if (!hasLaunched)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CalcTimesToTarget();
                Debug.Log("TTT " + times);
                SetLaunchDirection();
                rb.useGravity = true;
                rb.velocity = launchDirection * launchSpeed;
            }
    }

    private void SetLaunchDirection()
    {
        launchDirection = (2 * delta - Physics.gravity * Squared(times.x)) / (2 * launchSpeed * times.x);
        launchDirection.Normalize();
    }

    private void CalcTimesToTarget()
    {
        float gravity_delta_dot = Vector3.Dot(Physics.gravity, delta);
        float gravity_squared_abs = Squared(Physics.gravity.x) + Squared(Physics.gravity.y) + Squared(Physics.gravity.z);
        float delta_squared_abs = Squared(delta.x) + Squared(delta.y) + Squared(delta.z);
        float speed_squared = Squared(launchSpeed);

        //coming up with not possible
        //
        if (Squared(gravity_delta_dot + speed_squared) < gravity_squared_abs*delta_squared_abs)
        {
            Debug.Log("Not Possible");
            return;
        }
        times = new Vector2(
            2 * 
            Mathf.Sqrt(
                (gravity_delta_dot + speed_squared + Mathf.Sqrt(    Squared(gravity_delta_dot + speed_squared) - gravity_squared_abs * delta_squared_abs)   ) 
                                                                        / (2 * gravity_squared_abs)
            ),

            2 * 
            Mathf.Sqrt(
                (gravity_delta_dot + speed_squared - Mathf.Sqrt(    Squared(gravity_delta_dot + speed_squared) - gravity_squared_abs * delta_squared_abs)   ) 
                                                                        / (2 * gravity_squared_abs) 
            )
        );
    }

    private float Squared(float x)
    {
        return x * x;
    }
}
