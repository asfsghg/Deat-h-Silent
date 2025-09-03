using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class neRun : MonoBehaviour
{
    [Header("Move")]
    public float walkSpeed = 4f;
    public float sprintSpeed = 7f;
    public float acceleration = 12f;   

    [Header("Jump & Gravity")]
    public float jumpHeight = 1.2f;
    public float gravity = -18f;       
    public float groundSnap = -2f;     

    [Header("Ground Check")]
    public Transform groundCheck;    
    public float groundRadius = 0.25f;
    public LayerMask groundMask;

    private CharacterController cc;
    private Vector3 velocity;          
    private Vector3 currentMove;       

    void Start()
    {
        cc = GetComponent<CharacterController>();
        if (groundCheck == null)
        {
           
            GameObject gc = new GameObject("GroundCheck");
            gc.transform.SetParent(transform);
            gc.transform.localPosition = new Vector3(0, -cc.height * 0.5f, 0);
            groundCheck = gc.transform;
        }
    }

    void Update()
    {
        
        float x = Input.GetAxisRaw("Horizontal");   
        float z = Input.GetAxisRaw("Vertical");     
        Vector3 inputDir = (transform.right * x + transform.forward * z).normalized;

        
        float targetSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;
        Vector3 targetMove = inputDir * targetSpeed;

       
        currentMove = Vector3.MoveTowards(currentMove, targetMove, acceleration * Time.deltaTime);

       
        bool isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask, QueryTriggerInteraction.Ignore);

        if (isGrounded && velocity.y < 0f)
            velocity.y = groundSnap;


        if (isGrounded && Input.GetButtonDown("Jump"))
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);


        velocity.y += gravity * Time.deltaTime;

        
        Vector3 motion = currentMove * Time.deltaTime + Vector3.up * velocity.y * Time.deltaTime;
        cc.Move(motion);
    }

    
    void OnDrawGizmosSelected()
    {
        if (groundCheck)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        }
    }
}
