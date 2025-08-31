using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using static UnityEditor.Progress;
using RedstoneinventeGameStudio;

public class InventoriStory : MonoBehaviour
{
    public List<InventoriSlot> slots = new List<InventoriSlot>();
    public float pickupRadius = 2f;
    private Camera MainCamera;
    public bool IsOpen;
    public GameObject UIPanel;

    void Start()
    {
        MainCamera = Camera.main;
        
        InventoriSlot[] slotArray = GetComponentsInChildren<InventoriSlot>();
        slots.AddRange(slotArray);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            IsOpen = !IsOpen;
            if (IsOpen)
            {
                UIPanel.SetActive(true);
            }
            else
            {
                UIPanel.SetActive(false);
            }
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
            if (col.TryGetComponent<ItemS>(out ItemS itemS))
            {
                Debug.Log("Подобран предмет: " + itemS.itemData.itemName);

                AddItemToInventory(itemS.itemData, itemS.amount);

                Destroy(col.gameObject);
                break;
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

        // Ищем пустой слот
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