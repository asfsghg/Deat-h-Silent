using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class inventopi : MonoBehaviour
{
    public List<UnityEditor.Progress.Item> items = new List<UnityEditor.Progress.Item>();
    public int capacity = 20;

    public bool AddItem(UnityEditor.Progress.Item item)
    {
        if (items.Count >= capacity) return false;
        items.Add(item);
        return true;
    }

    public void RemoveItem(UnityEditor.Progress.Item item)
    {
        items.Remove(item);
    }
}
