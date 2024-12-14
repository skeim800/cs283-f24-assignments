using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidFollowCamera : MonoBehaviour
{
    public Transform target;
    public float hDist = 5f;
    public float vDist = 5f;
    public float rotationSpeed = 5f;

    public float minPitch = -40f;
    public float maxPitch = 80f;
    private float pitch = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        pitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        // tPos, tUp, tForward = Position, up, and forward vector of target
        Vector3 tPos = target.position;
        Vector3 tForward = target.forward;
        Vector3 tUp = target.up;

        // Camera position is offset from the target position
        Vector3 eye = tPos - tForward * hDist + tUp * vDist;

        // Set the camera's position and rotation with the new values
        // This code assumes that this code runs in a script attached to the camera
        transform.position = eye;
        Quaternion horizontalRotation = Quaternion.LookRotation(tForward);
        Quaternion verticalRotation = Quaternion.Euler(pitch, 0f, 0f);

        // Combine rotations to keep camera behind target but allow vertical mouse look
        transform.rotation = horizontalRotation * verticalRotation;
    }

}

