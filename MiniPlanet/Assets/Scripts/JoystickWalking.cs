using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class JoystickWalking : MonoBehaviour
{

    public SteamVR_Action_Vector2 input;
    public float speed = 1;

    // Update is called once per frame
    void Update()
    {
        Vector3 directional = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
        transform.position += speed * Time.deltaTime * Vector3.ProjectOnPlane(directional, Vector3.up);
    }
}
