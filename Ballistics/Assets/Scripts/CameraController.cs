using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Vector3 offset = new Vector3(3.0f, 0.0f, -10.0f);

    public void Update()
    {
        transform.position = projectile.transform.position + offset;
    }
}
