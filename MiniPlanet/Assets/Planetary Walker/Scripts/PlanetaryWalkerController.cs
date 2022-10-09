using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class PlanetaryWalkerController : MonoBehaviour
{
    public float movementspeed = 10.0f;
    
    public bool canJump = true;
    
    public float jumpHeight = 5.0f;
    
    public Camera playerCamera;
   
    public float CameraSpeed = 2.0f;
   
    public float CameraXLimit = 30.0f;

    bool grounded = false;
    
    Rigidbody Player;
    
    Vector2 rotation = Vector2.zero;
    
    float VelocityChangeLimit = 10.0f;

    void Awake()
    {
        Player = GetComponent<Rigidbody>();
      
        Player.freezeRotation = true;
       
        Player.useGravity = false;
      
        Player.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
       
        rotation.y = transform.eulerAngles.y;
      
        Cursor.lockState = CursorLockMode.Locked;
       
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        if (grounded)
        {
            // Calculations for how fast player is moving
            Vector3 forwardDir = Vector3.Cross(transform.up, -playerCamera.transform.right).normalized;
          
            Vector3 rightdirection = Vector3.Cross(transform.up, playerCamera.transform.forward).normalized;
           
            Vector3 targetVelocity = (forwardDir * Input.GetAxis("Vertical") + rightdirection * Input.GetAxis("Horizontal")) * movementspeed;

            Vector3 velocity = transform.InverseTransformDirection(Player.velocity);
          
            velocity.y = 0;
          
            velocity = transform.TransformDirection(velocity);
           
            Vector3 velocityChange = transform.InverseTransformDirection(targetVelocity - velocity);
           
            velocityChange.x = Mathf.Clamp(velocityChange.x, -VelocityChangeLimit, VelocityChangeLimit);
           
            velocityChange.z = Mathf.Clamp(velocityChange.z, -VelocityChangeLimit, VelocityChangeLimit);
          
            velocityChange.y = 0;
           
            velocityChange = transform.TransformDirection(velocityChange);

            Player.AddForce(velocityChange, ForceMode.VelocityChange);

            if (Input.GetButton("Jump") && canJump)
            {
                Player.AddForce(transform.up * jumpHeight, ForceMode.VelocityChange);
            }
        }

        grounded = false;

        // Roatation input for the camera & player
        rotation.x += -Input.GetAxis("Mouse Y") * CameraSpeed;
       
        rotation.x = Mathf.Clamp(rotation.x, -CameraXLimit, CameraXLimit);
       
        playerCamera.transform.localRotation = Quaternion.Euler(rotation.x, 0, 0);
       
        Quaternion localRotation = Quaternion.Euler(0f, Input.GetAxis("Mouse X") * CameraSpeed, 0f);
      
        transform.rotation = transform.rotation * localRotation;
    }

    void OnCollisionStay()
    {
        grounded = true;
    }
}