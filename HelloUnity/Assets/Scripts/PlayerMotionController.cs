// Character controller and colliders for A07
// October 2024
// Sarah Keim

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotionController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 100f;
    private Animator animator;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        Vector3 forward = transform.forward;
        Vector3 moveDirection = Vector3.zero;
        bool IsMoving = false;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += forward;
            //transform.position += forward * moveSpeed * Time.deltaTime;
            IsMoving = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
            //IsMoving = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= forward;
            //transform.position -= forward * moveSpeed * Time.deltaTime;
            IsMoving = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
            //IsMoving = true;
        }

        //Debug.Log($"isMoving: {IsMoving}");

        if (IsMoving)
        {
            moveDirection.Normalize();
            controller.Move(moveDirection * moveSpeed * Time.deltaTime);
        }

        animator.SetBool("IsMoving", IsMoving);
    }
}
