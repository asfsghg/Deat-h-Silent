using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoriStory : MonoBehaviour
{
    [Header("UI")]
    public GameObject UIPanel;
    public Transform InventoriPanel;
    public List<InventoriSlot> slots = new List<InventoriSlot>();
    public bool IsOpen;

    private Camera MainCamera;

    [Header("Pickup Settings")]
    public float reachDistance = 2f;   
    public float pickupRadius = 1f;    

    void Start()
    {
        MainCamera = Camera.main;
        UIPanel.SetActive(false);

        
        for (int i = 0; i < InventoriPanel.childCount; i++)
        {
            InventoriSlot slot = InventoriPanel.GetChild(i).GetComponent<InventoriSlot>();
            if (slot != null)
                slots.Add(slot);
        }
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            IsOpen = !IsOpen;
            UIPanel.SetActive(IsOpen);
        }

        
        if (Input.GetKeyDown(KeyCode.F))
        {
            PickupItem();
        }
    }

    private void PickupItem()
    {
        
        Vector3 center = MainCamera.transform.position + MainCamera.transform.forward * reachDistance;

        
        Collider[] colliders = Physics.OverlapSphere(center, pickupRadius);

        ItemS nearestItem = null;
        float nearestDistance = Mathf.Infinity;

       
        foreach (Collider col in colliders)
        {
            if (col.gameObject.TryGetComponent<ItemS>(out ItemS itemS))
            {
                float dist = Vector3.Distance(MainCamera.transform.position, col.transform.position);
                if (dist < nearestDistance)
                {
                    nearestDistance = dist;
                    nearestItem = itemS;
                }
            }
        }

       
        if (nearestItem != null)
        {
            AddItem(nearestItem.item, nearestItem.amount);
            Destroy(nearestItem.gameObject);
        }
    }

    private void AddItem(ItemScriptobelObject _item, int _amount)
    {
      
        foreach (InventoriSlot slot in slots)
        {
            if (slot.item == _item)
            {
                slot.amount += _amount;
                return;
            }
        }

        foreach (InventoriSlot slot in slots)
        {
            if (slot.isEmpty)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon); 
                return;
            }
        }
    }

    
    private void OnDrawGizmosSelected()
    {
        if (MainCamera != null)
        {
            Vector3 center = MainCamera.transform.position + MainCamera.transform.forward * reachDistance;
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(center, pickupRadius);
        }
    }
}
