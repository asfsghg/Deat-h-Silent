using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class betAi : MonoBehaviour
{
    public GameObject camera;
    public float distance = 15f;

    private List<GameObject> items = new List<GameObject>(); 
    private int currentIndex = -1;
    private Transform handPoint;   

    void Start()
    {
      
        handPoint = new GameObject("HandPoint").transform;
        handPoint.SetParent(transform);
        handPoint.localPosition = Vector3.zero;
        handPoint.localRotation = Quaternion.identity;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            PickUp();
        }

        
        for (int i = 0; i < items.Count; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SwitchItem(i);
            }
        }
    }

    void PickUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            if (hit.transform.CompareTag("Apple") || hit.transform.CompareTag("Weapon"))
            {
                GameObject item = hit.transform.gameObject;

                
                item.GetComponent<Rigidbody>().isKinematic = true;

               
                item.transform.SetParent(handPoint);
                item.transform.localPosition = Vector3.zero;
                item.transform.localEulerAngles = new Vector3(10f, 0f, 0f);

                
                items.Add(item);

               
                if (currentIndex == -1)
                {
                    SwitchItem(0);
                }
                else
                {
                    item.SetActive(false); 
                }
            }
        }
    }

    void SwitchItem(int index)
    {
        if (index < 0 || index >= items.Count) return;

        
        if (currentIndex != -1)
        {
            items[currentIndex].SetActive(false);
        }

        
        currentIndex = index;
        items[currentIndex].SetActive(true);
    }
}
