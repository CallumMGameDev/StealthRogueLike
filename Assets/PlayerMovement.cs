using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;

    [Header("PlayerProperties")]
    [SerializeField]
    private float speed;
    [SerializeField]
    private float gravity;
    [SerializeField]
    private float jumpHeight;

    private float xMovement;
    private float zMovement;
    private Vector3 move;

    private Vector3 velocity;

    [SerializeField]
    private Transform groundCheck;
    private float groundDistance = 0.4f;
    [SerializeField]
    private LayerMask groundMask;

    private bool isGrounded;

    private void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        xMovement = Input.GetAxis("Horizontal");
        zMovement = Input.GetAxis("Vertical");

        move = transform.right * xMovement + transform.forward * zMovement;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}
