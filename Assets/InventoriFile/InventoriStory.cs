using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoriStory : MonoBehaviour
{
    public GameObject UIPanel;
    public Transform InventoriPanel;
    public List<InventoriSlot> slots = new List<InventoriSlot>();
    public bool IsOpen;
    private Camera MainCamera;
    public float reachDistance = 1;
    void Start()
    {
        MainCamera = Camera.main;
        UIPanel.SetActive(false); 
        for (int i = 0; i < InventoriPanel.childCount; i++)
        {
            if(InventoriPanel.GetChild(i).GetComponent<InventoriSlot>() != null)
            {
                slots.Add(InventoriPanel.GetChild(i).GetComponent<InventoriSlot>());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
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
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.F))
        {


            if (Physics.Raycast(ray, out hit, reachDistance))
            {
                if (hit.collider.gameObject.GetComponent<ItemS>() != null)
                {
                    AddItem(hit.collider.gameObject.GetComponent<ItemS>().item, hit.collider.gameObject.GetComponent<ItemS>().amount);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
    private void AddItem(ItemScriptobelObject _item, int _amount)
    {
        foreach(InventoriSlot slot in slots)
        {
            if(slot.item == _item)
            {
                slot.amount += _amount;
                return;
            }
        }
        foreach (InventoriSlot slot in slots)
        {
            if(slot.isEmpty ==false)
            {
                slot.amount = _amount;
                slot.item = _item;
                slot.isEmpty = false;
                //slot.SetIcon(ItemS.icon);
            }
        }
    }
}
