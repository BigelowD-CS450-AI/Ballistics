using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    [SerializeField] public Vector3 launchDirection;
    [SerializeField] public float launchSpeed;
    [SerializeField] private GameObject target;
    [SerializeField] private Slider launchForceSlider;
    private Vector3 targetOffset;
    private Vector3 initialPosition;
    //private bool hasLaunched = false;
    public Rigidbody rb;
    private Vector3 delta;
    public float ttt;
    public GameManager gm;
    private Vector2 times;

    public void Start()
    {
        targetOffset = -Vector3.down - Vector3.right * .5f;
        initialPosition = transform.position;
        rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    public void Reset()
    {
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = initialPosition;
    }

    // Update is called once per frame
    void Update()
    {
        launchSpeed = launchForceSlider.value;
    }

    public void Launch()
    {
        if (!gm.Launched)
        {
            if (CalcTimesToTarget() >= 0)
            {
                SetLaunchDirection();
                rb.useGravity = true;
                rb.velocity = launchDirection * launchSpeed;
                gm.Launch();
            }
        }
    }

    public Vector3 SetLaunchDirection()
    { 
        delta = (target.transform.position + targetOffset) - transform.position;
        launchDirection = (2 * delta - Physics.gravity * Squared(ttt)) / (2 * launchSpeed * ttt);
        launchDirection.Normalize();
        return launchDirection;
    }

    public float CalcTimesToTarget()
    {
        delta = transform.position - (target.transform.position + targetOffset);
        float a = Squared(Physics.gravity.magnitude);
        float b = -4 * (Vector3.Dot(Physics.gravity, delta) + Squared(launchSpeed));
        float c = 4 * Squared(delta.magnitude);

        float b2minus4ac = b * b - 4 * a * c;
        if (b2minus4ac < 0)
        {
            Debug.Log("Not Possible 1");
            return -1;
        }

        times = new Vector2(
             Mathf.Sqrt((-b + Mathf.Sqrt(b2minus4ac)) / (2 * a)),
             Mathf.Sqrt((-b - Mathf.Sqrt(b2minus4ac)) / (2 * a))
        );

        if (times.x <= 0 && times.y <= 0) 
        {
            Debug.Log("Not Possible 2");
            return -1;
        }

        ttt = Mathf.Max(times.x, times.y);
        return ttt;
    }

    private float Squared(float x)
    {
        return x * x;
    }
}
