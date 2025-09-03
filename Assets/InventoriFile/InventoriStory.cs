
using System.Collections.Generic;
using UnityEngine;

using RedstoneinventeGameStudio;

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
            if (col.TryGetComponent<ItemS>(out ItemS itemS))
            {
                Debug.Log("Подобран предмет: " + itemS.itemData.itemName);

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
                return;
            }
        }


        Debug.Log("Инвентарь заполнен!");
    }
}