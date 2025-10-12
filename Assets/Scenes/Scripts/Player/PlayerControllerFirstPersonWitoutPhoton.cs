using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFirstPersonWithoutPhoton : MonoBehaviour
{

    [SerializeField] private Camera mainCamera;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    
    [SerializeField] private float bobAmplitude = 0.05f; 
    [SerializeField] private float bobFrequency = 6f;   
    private Vector3 cameraStartPos;

    private Rigidbody rb;
    private bool _isJumping = false;
    private float bobTimer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        cameraStartPos = mainCamera.transform.localPosition;
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


        if (Input.GetKey(KeyCode.C))
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 20, Time.deltaTime * 10f);
        }
        else
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 95, Time.deltaTime * 5f);
        }


        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (flatVelocity.magnitude > 0.1f && _isJumping == false)
        {
            bobTimer += Time.deltaTime * bobFrequency;
            float bobOffset = Mathf.Sin(bobTimer) * bobAmplitude;
            mainCamera.transform.localPosition = cameraStartPos + new Vector3(0, bobOffset, 0);
        }
        else
        {
            bobTimer = 0;
            mainCamera.transform.localPosition = Vector3.Lerp(mainCamera.transform.localPosition, cameraStartPos, Time.deltaTime * 5f);
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
