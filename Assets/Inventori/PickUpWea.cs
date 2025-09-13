using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWea : MonoBehaviour
{
    public GameObject camera;
    public float distance = 15f;
    GameObject surrent;
    bool canPIckUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void PickUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position,camera.transform.forward,out hit,distance))
        {
            if(hit.transform.tag =="Apple")
            {
                if (canPIckUp) Drop();
                surrent = hit.transform.gameObject;
                surrent.GetComponent<Rigidbody>().isKinematic = true;
                surrent.transform.parent = transform;
                surrent.transform.localPosition = Vector3.zero;
                surrent.transform.localEulerAngles = new Vector3(10f,0f,0f);
                canPIckUp = true;
            }
        }
    }
    void Drop()
    {
        surrent.transform.parent = null;
        surrent.GetComponent<Rigidbody>().isKinematic = false;
        canPIckUp =false;
        surrent = null;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) PickUp();
        if (Input.GetKeyDown(KeyCode.Q)) Drop();
    }
}
