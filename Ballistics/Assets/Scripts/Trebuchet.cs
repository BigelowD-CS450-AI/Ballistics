using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trebuchet : MonoBehaviour
{
    public GameObject projectile;
    private Vector2 offset;
    private float angle;
    [SerializeField] private float maxAngle = -75.0f;
    [SerializeField] private float angleOffset = 5.0f;

    public void Start()
    {
        offset = new Vector2(Mathf.Abs(projectile.transform.position.x - transform.position.x), 
                             Mathf.Abs(projectile.transform.position.y - transform.position.y));
    }

    // Update is called once per frame
    void Update()
    {
        offset = transform.position - projectile.transform.position;
        angle = 180 * Mathf.Atan2(offset.y, offset.x) / Mathf.PI;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Max(angle + angleOffset,maxAngle));
            //SetLookRotation(projectile.transform.position, Vector3.up);
    }
}
