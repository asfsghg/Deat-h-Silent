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
    public GameObject UIPanel;
    public Transform InventoriPanel;
    public List<InventoriSlot> slots = new List<InventoriSlot>();
    public bool IsOpen;

    private Camera MainCamera;
    [SerializeField] private float pickupRadius = 2f;

    void Start()
    {
        MainCamera = Camera.main;
        UIPanel.SetActive(false);

        // Собираем все слоты
        slots.Clear();
        for (int i = 0; i < InventoriPanel.childCount; i++)
        {
            InventoriSlot slot = InventoriPanel.GetChild(i).GetComponent<InventoriSlot>();
            if (slot != null) slots.Add(slot);
        }
    }

    void Update()
    {
        // Открытие/закрытие инвентаря
        if (Input.GetKeyDown(KeyCode.E))
        {
            IsOpen = !IsOpen;
            UIPanel.SetActive(IsOpen);
        }

        // Попытка подобрать предмет
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Нажата F");  // проверка
            PickupNearbyItem();
        }
    }

    void PickupNearbyItem()
    {
        // Центр сферы — прямо у игрока (можно смещать по y если нужно)
        Vector3 center = transform.position;

        // Находим все коллайдеры в радиусе
        Collider[] colliders = Physics.OverlapSphere(center, pickupRadius);

        foreach (Collider col in colliders)
        {
            if (col.TryGetComponent<ItemS>(out ItemS itemS))
            {
                Debug.Log("Подобран предмет: " + itemS.itemData.itemName);

                // Добавляем в инвентарь
                AddItem(itemS.itemData, itemS.amount);

                // Удаляем объект со сцены
                Destroy(col.gameObject);

                // берём только один предмет за раз
                break;
            }
        }
    }

    void AddItem(InventoryItemData _item, int _amount)
    {
        // Если предмет уже есть в слоте → суммируем количество
        foreach (InventoriSlot slot in slots)
        {
            if (!slot.isEmpty && slot.item == _item)
            {
                slot.amount += _amount;
                slot.UpdateUI();
                return;
            }
        }

        // Ищем пустой слот
        foreach (InventoriSlot slot in slots)
        {
            if (slot.isEmpty)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.UpdateUI();
                return;
            }
        }

        Debug.Log("Инвентарь заполнен!");

    }
}