using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType { Default,Food,Weapon, Materials , tools }
public class ItemScriptobelObject : ScriptableObject
{
    public ItemType itemType;
    public string itemName;
    public int maxAmout;
    public string itemDescription;

        
}
