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
    public float jumpForce = 5f;
    public float gravity = 9.8f;
    private Animator animator;
    private CharacterController controller;

    private Vector3 velocity; 
    private bool isGrounded;

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

        isGrounded = controller.isGrounded; 

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; 
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpForce * 2f * gravity); 
        }

        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
