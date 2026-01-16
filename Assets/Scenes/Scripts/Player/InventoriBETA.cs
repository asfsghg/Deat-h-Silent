using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoriBETA : MonoBehaviour

{
    
    public GameObject playerCamera;
    public float pickDistance = 20f;
    
    public InventoryData inventoryCore;
    public float pickupRadius = 3f;
    public LayerMask itemLayer;   

    
    public KeyCode pickKey = KeyCode.F;
    public KeyCode dropKey = KeyCode.G;

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
       
        if (Input.GetKeyDown(pickKey))
            PickUp();

       
        if (Input.GetKeyDown(dropKey))
            Drop();

        
        for (int i = 0; i < items.Count; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                SetActiveItem(i);
        }

       
        if (currentIndex != -1 && Input.GetMouseButtonDown(0))
            PlayUseAnimation();
    }

    
    void PickUp()
    {
        if (!playerCamera) return;

        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position,
           playerCamera.transform.forward,
           out hit, pickDistance,itemLayer))
        {
           
           
            
                GameObject item = hit.transform.gameObject;

                Rigidbody rb = item.GetComponent<Rigidbody>();
                Collider col = item.GetComponent<Collider>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                    rb.useGravity = false;
                    col.isTrigger = true;
                }

                item.transform.SetParent(handPoint);
                item.transform.localPosition = Vector3.zero;
                item.transform.localEulerAngles = new Vector3(10f, 0f, 0f);
                bool success = inventoryCore.AddItem(item.GetComponent<Items>().itemData);
                item.layer = LayerMask.NameToLayer("Default");

                items.Add(item);

                if (currentIndex == -1)
                    SetActiveItem(0);
                else
                    item.SetActive(false);
            
        }
    }

   
    void Drop()
    {
        if (currentIndex == -1) return;

        GameObject currentItem = items[currentIndex];
        bool success = inventoryCore.RemoveItem(items[currentIndex].GetComponent<Items>().itemData);
        items.RemoveAt(currentIndex);

        currentItem.transform.SetParent(null);
        currentItem.layer = LayerMask.NameToLayer("Items");

        Rigidbody rb = currentItem.GetComponent<Rigidbody>();
        Collider col = currentItem.GetComponent<Collider>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            col.isTrigger = false;
        }

        currentItem.transform.position =
            playerCamera.transform.position + playerCamera.transform.forward * 2f;
        
    


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
            items[i].SetActive(i == index);

        currentIndex = index;
    }

    void PlayUseAnimation()
    {
        GameObject currentItem = items[currentIndex];
        Animator anim = currentItem.GetComponent<Animator>();

        if (anim != null)
        {
            anim.ResetTrigger("Use");   
            anim.SetTrigger("Use");     
        }
        else
        {
            Debug.LogWarning($"{currentItem.name}");
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }
   
}



