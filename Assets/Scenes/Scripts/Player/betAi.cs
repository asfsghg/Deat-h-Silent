using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

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

        if (Input.GetKeyDown(KeyCode.G))
        {
            Drop();
        }

       
        for (int i = 0; i < items.Count; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SetActiveItem(i);
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
                item.GetComponent<Collider>().isTrigger = true;
                item.transform.SetParent(handPoint);
                item.transform.localPosition = Vector3.zero;
                item.transform.localEulerAngles = new Vector3(10f, 0f, 0f);

                items.Add(item);

                if (currentIndex == -1)
                {
                    SetActiveItem(0); 
                }
                else
                {
                    item.SetActive(false); 
                }
            }
        }
    }

    void Drop()
    {
        if (currentIndex == -1) return; 

        GameObject currentItem = items[currentIndex];

        
        items.RemoveAt(currentIndex);

       
        currentItem.transform.SetParent(null);
        currentItem.GetComponent<Rigidbody>().isKinematic = false;
        currentItem.GetComponent<Collider>().isTrigger = false;
        currentItem.transform.position = camera.transform.position + camera.transform.forward * 2f;

       
        if (items.Count > 0)
        {
            currentIndex = Mathf.Clamp(currentIndex - 1, 0, items.Count - 1);
            SetActiveItem(currentIndex);
        }
        else
        {
            currentIndex = -1;
        }
    }

    void SetActiveItem(int index)
    {
        if (index < 0 || index >= items.Count) return;

       
        for (int i = 0; i < items.Count; i++)
        {
            items[i].SetActive(false);
        }

        
        currentIndex = index;
        items[currentIndex].SetActive(true);
    }
}
