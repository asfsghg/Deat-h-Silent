using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class inventopi : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public int capacity = 20;

    public bool AddItem(Item item)
    {
        if (items.Count >= capacity) return false;
        items.Add(item);
        return true;
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }
}
