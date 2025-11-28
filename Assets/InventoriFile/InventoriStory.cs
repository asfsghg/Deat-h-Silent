
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RedstoneinventeGameStudio;
using Unity.VisualScripting;

public class InventoriStory : MonoBehaviour
{
    public List<InventoriSlot> slots = new List<InventoriSlot>();
    public float pickupRadius = 10f;
    private Camera MainCamera;
    public bool IsOpen;
    public GameObject UIPanel;

    void Start()
    {
        MainCamera = Camera.main;
        
        InventoriSlot[] slotArray = GetComponentsInChildren<InventoriSlot>();
        slots.AddRange(slotArray);
    }

    void LateUpdate()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            IsOpen = !IsOpen;
            UIPanel.SetActive(IsOpen);
        }
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            PickupNearbyItem();
        }
    }

    void PickupNearbyItem()
    {
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        Vector3 center = transform.position;
        Collider[] colliders = Physics.OverlapSphere(center, pickupRadius);

        foreach (Collider col in colliders)                       
            
        {
            Debug.Log(1);
            if (col.TryGetComponent<Item>(out Item itemS))
            {
                Debug.Log("редмет: " + itemS.itemData.itemName);

                AddItemToInventory(itemS.itemData, itemS.amount);

                Destroy(col.gameObject);
            }
        }

    }

    void AddItemToInventory(InventoryItemData item, int amount)
    {
       
        foreach (InventoriSlot slot in slots)
        {
            if (!slot.isEmpty && slot.item == item)
            {
                slot.amount += amount;
                slot.UpdateUI(); 
                return;
            }
        }

        
        foreach (InventoriSlot slot in slots)
        {
            if (slot.isEmpty)
            {
                slot.item = item;      
                slot.amount = amount;  
                slot.isEmpty = false;   
                slot.UpdateUI();
                //slot.itemAmount.text = amount.ToString();
                return; 
            }
        }


        Debug.Log("фул инвентарь");
    }
}