using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trebuchet : MonoBehaviour
{
    public GameObject projectile;
    private Vector2 offset;
    private float angle;
    [SerializeField] private float maxAngle = 285f;
    [SerializeField] private float angleOffset = 5.0f;
    private bool launched = false;

    public void Start()
    {
        offset = new Vector2(Mathf.Abs(projectile.transform.position.x - transform.position.x), 
                             Mathf.Abs(projectile.transform.position.y - transform.position.y));
    }

    // Update is called once per frame
    void Update()
    {
        if (!launched)
        {
            offset = transform.position - projectile.transform.position;
            angle = 180 * Mathf.Atan2(offset.y, offset.x) / Mathf.PI;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Min(angle + angleOffset, maxAngle));
            Debug.Log("angle: " + transform.rotation.eulerAngles.z + " maxAngle: " + maxAngle);
            if (transform.rotation.eulerAngles.z <= maxAngle)
                launched = true;
        }
    }

    public void Reset()
    {
        launched = false;
    }
}
