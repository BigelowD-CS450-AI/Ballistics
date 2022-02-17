using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    [SerializeField] private Slider distanceOffset;
    private Vector3 distanceOffsetVector;
    private Vector3 initialPosition;
    private Rigidbody rb;
    public GameManager gm;

    public void Start()
    {
        initialPosition = transform.position;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (!gm.Launched)
        {
            distanceOffsetVector = new Vector3(distanceOffset.value, 1.0f, 0.87f);
            transform.position = distanceOffsetVector;
            rb.angularVelocity = Vector3.zero;
        }
    }
    public void Reset()
    {
        transform.position = initialPosition;
        transform.rotation = Quaternion.identity;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
