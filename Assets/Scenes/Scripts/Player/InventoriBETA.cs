using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoriBETA : MonoBehaviour

{
    public GameObject playerCamera;
    public float pickDistance = 20f;

    public KeyCode pickKey = KeyCode.F;
    public KeyCode dropKey = KeyCode.G;

    private List<GameObject> items = new List<GameObject>();
    private int currentIndex = -1;
    private Transform handPoint;

    void Start()
    {
        handPoint = new GameObject("HandPoint").transform;
        handPoint.SetParent(transform);
        handPoint.localPosition = Vector3.zero;
        handPoint.localRotation = Quaternion.identity;
    }

    void Update()
    {
        if (Input.GetKeyDown(pickKey))
            PickUp();

        if (Input.GetKeyDown(dropKey))
            Drop();

        for (int i = 0; i < items.Count && i < 9; i++) // клавіші 1..9
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                SetActiveItem(i);
        }

        if (currentIndex != -1 && Input.GetMouseButtonDown(0))
            PlayUseAnimation();
    }

    void PickUp()
    {
        if (playerCamera == null)
        {
            Debug.LogWarning("playerCamera не задана в інспекторі!");
            return;
        }

        RaycastHit hit;
        Vector3 origin = playerCamera.transform.position;
        Vector3 dir = playerCamera.transform.forward;

        // намалювати для дебагу (тимчасово)
        Debug.DrawRay(origin, dir * pickDistance, Color.green, 1f);

        if (Physics.Raycast(origin, dir, out hit, pickDistance))
        {
            // Отримуємо головний об'єкт, пов'язаний з колайдером / Rigidbody
            GameObject hitObject = null;
            if (hit.rigidbody != null)
                hitObject = hit.rigidbody.gameObject;
            else
                hitObject = hit.collider.gameObject;

            if (hitObject == null) return;

            // Перевірка тегів (використовуємо ||). Переконайся, що теги в сцені збігаються (наприклад "Apple", "Weapon", "Other").
            string t = hitObject.tag;
            if (t == "Apple" || t == "Weapon" || t == "Other")
            {
                // Якщо предмет уже в нашому списку — ігноруємо
                if (items.Contains(hitObject))
                {
                    Debug.Log($"{hitObject.name} вже підібрано.");
                    return;
                }

                // Вимикаємо фізику і чіпляємо предмет за handPoint
                Rigidbody rb = hitObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                    rb.useGravity = false;
                }

                // Зафіксувати масштаб/позицію відносно handPoint
                hitObject.transform.SetParent(handPoint, true);
                hitObject.transform.localPosition = Vector3.zero;
                hitObject.transform.localEulerAngles = new Vector3(10f, 0f, 0f);

                items.Add(hitObject);

                if (currentIndex == -1)
                    SetActiveItem(0);
                else
                    hitObject.SetActive(false);
            }
            else
            {
                // Для дебагу: який тег був виявлений
                Debug.Log($"Raycast влучив у {hitObject.name} з тегом '{hitObject.tag}' (не підходить під pick).");
            }
        }
    }

    void Drop()
    {
        if (currentIndex == -1) return;

        GameObject currentItem = items[currentIndex];
        items.RemoveAt(currentIndex);

        currentItem.transform.SetParent(null);

        Rigidbody rb = currentItem.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }

        currentItem.transform.position =
            playerCamera.transform.position + playerCamera.transform.forward * 2f;
        if (items.Count > 0)
        {
            currentIndex = Mathf.Clamp(currentIndex - 1, 0, items.Count - 1);
            SetActiveItem(currentIndex);
        }
        else
        {
            currentIndex = -1;
        }
    }

    void SetActiveItem(int index)
    {
        if (index < 0 || index >= items.Count) return;

        for (int i = 0; i < items.Count; i++)
            items[i].SetActive(i == index);

        currentIndex = index;
    }

    void PlayUseAnimation()
    {
        GameObject currentItem = items[currentIndex];
        Animator anim = currentItem.GetComponent<Animator>();

        if (anim != null)
        {
            anim.ResetTrigger("Use");
            anim.SetTrigger("Use");
        }
        else
        {
            Debug.LogWarning($"{currentItem.name} не має Animator.");
        }
    }

}



