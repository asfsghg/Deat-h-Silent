using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFirstPersonWithoutPhoton : MonoBehaviour
{
    //камера
    [SerializeField] private Camera mainCamera;
    private Vector3 cameraStartPos;
    [SerializeField] private float bobAmplitude = 0.05f; 
    [SerializeField] private float bobFrequency = 6f;
    private float bobTimer;
    
    //характеристика гравця
    
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    
    //голова
    
    [SerializeField] private Transform Head;

//інше
    
    private Rigidbody rb;
    private bool _isJumping = false;

    //аниматор
    
    private Animator _animator;
    

    private void Awake() //посилання на компоненти
    {
        _animator = GetComponent<Animator>();
        
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        cameraStartPos = mainCamera.transform.localPosition;
        
    }

    private void Update() // система руху
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        _animator.SetFloat("Speed", vertical);

        Vector3 move = transform.forward * vertical + transform.right * horizontal;
        move.Normalize();

        Vector3 newVelocity = move * moveSpeed;
        newVelocity.y = rb.velocity.y;
        rb.velocity = newVelocity;
        
        Vector3 headEuler = Head.localEulerAngles;
        headEuler.x = mainCamera.transform.localEulerAngles.x;
        Head.localEulerAngles = headEuler;


  
        if (Input.GetButtonDown("Jump") && !_isJumping) //стрибок
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _isJumping = true;
            _animator.ResetTrigger("IsGround");
            _animator.SetTrigger("Jump");
        }


        if (Input.GetKey(KeyCode.C)) //сближення камери
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 20, Time.deltaTime * 10f);
        }
        else
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 60, Time.deltaTime * 5f);
        }
        if (Input.GetKey(KeyCode.LeftShift)) //біг
        {
            moveSpeed = 5f;
            _animator.SetTrigger("IsRunning");
        }
        else
        {
            moveSpeed = 2f;
            _animator.ResetTrigger("IsRunning");
 
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
    
    private void LateUpdate()
    {
        if (Head != null && mainCamera != null)
        {
            Vector3 euler = Head.localEulerAngles;
            euler.x = mainCamera.transform.localEulerAngles.x;
            

            Head.localEulerAngles = euler;
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _animator.SetTrigger("IsGround");
            _isJumping = false;
        }
    }
} 