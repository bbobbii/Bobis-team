using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetoidGravity : MonoBehaviour
{

    public Transform gravityTarget;
    public bool autoOrient = false;
    public float autoOrientSpeed = 2f;

    [SerializeField] float gravity;

    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ProcessGravity();
    }

    void ProcessGravity()
    {
        Vector3 diff = transform.position - gravityTarget.position;
        rb.AddForce( - diff.normalized * gravity * (rb.mass));

        if(autoOrient) { AutoOrient(-diff); }

    }

    void AutoOrient(Vector3 down)
    {
        Quaternion orientationDirection = Quaternion.FromToRotation(-transform.up, down) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, orientationDirection, autoOrientSpeed * Time.deltaTime);
    }
}
