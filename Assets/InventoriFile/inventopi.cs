using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryData : MonoBehaviour
{
    public List<InventoryItemData> items = new List<InventoryItemData>();
    public int capacity = 6;


    public Action OnChange; 

    public bool AddItem(InventoryItemData itemData)
    {
        Debug.Log("item was Added");
        if (itemData == null || items.Count >= capacity) return false;
        Debug.Log("item was Added2");
        items.Add(itemData);


        OnChange?.Invoke(); 
        return true;
    }

    public bool RemoveItem(InventoryItemData itemData)
    {
        items.Remove(itemData);
        OnChange?.Invoke(); 
        return true;
    }
}