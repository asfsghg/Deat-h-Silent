using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public float sensitivity = 2f;
    public float maxYAngle = 80f;

    
    private float _rotationX = 0f;
    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        
        transform.parent.Rotate(Vector3.up * mouseX * sensitivity);
        
        _rotationX -= mouseY * sensitivity;
        _rotationX = Mathf.Clamp(_rotationX, -maxYAngle, maxYAngle);
        transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);



    }
}
