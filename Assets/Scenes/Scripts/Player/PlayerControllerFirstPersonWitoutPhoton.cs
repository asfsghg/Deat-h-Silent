using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFirstPersonWithoutPhoton : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private bool _isJumping = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * vertical + transform.right * horizontal;
        move.Normalize();

        Vector3 newVelocity = move * moveSpeed;
        newVelocity.y = rb.velocity.y;
        rb.velocity = newVelocity;


        if (Input.GetButtonDown("Jump") && !_isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isJumping = false;
        }
    }
}