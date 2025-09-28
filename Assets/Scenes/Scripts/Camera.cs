using UnityEngine;
public class CameraController : MonoBehaviour
{
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        Cursor.visible = true;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        cam.transform.Translate(Vector3.right * horizontal);
        cam.transform.Translate(Vector3.forward * vertical);

    }
}