using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{

    [SerializeField] private GameObject baseplatePrefab;
    [SerializeField] private GameObject stairsPrefab;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject windowPrefab;

    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float maxRayDistance = 100f;

    private Camera mainCamera;
    private GameObject previewInstance;  
    private GameObject selectedPrefab;    

    void Start()
    {
        mainCamera = Camera.main;

    }

    void Update()
    {

        if (selectedPrefab == null) return;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, maxRayDistance, groundMask))
        {
            if (previewInstance == null)
            {
                previewInstance = Instantiate(selectedPrefab);
                MakePreview(previewInstance);
            }

            previewInstance.SetActive(true);
            previewInstance.transform.position = hit.point;

            if (Input.GetMouseButtonDown(0))
            {

                Instantiate(selectedPrefab, hit.point, previewInstance.transform.rotation);
                
                Destroy(previewInstance);
                previewInstance = null;
                selectedPrefab = null;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log(selectedPrefab);
            }
        }
        else
        {

            if (previewInstance != null) previewInstance.SetActive(false);
        }
    }

    private void MakePreview(GameObject go)
    {

        foreach (var c in go.GetComponentsInChildren<Collider>()) c.enabled = false;
        foreach (var rb in go.GetComponentsInChildren<Rigidbody>()) Destroy(rb);

    }
    public void BaseplateSpawn() => SelectPrefab(baseplatePrefab);
    public void StairsSpawn()    => SelectPrefab(stairsPrefab);
    public void WallSpawn()      => SelectPrefab(wallPrefab);
    public void WindowSpawn()    => SelectPrefab(windowPrefab);

    private void SelectPrefab(GameObject prefab)
    {
        selectedPrefab = prefab;
        if (previewInstance != null) Destroy(previewInstance);
        previewInstance = Instantiate(selectedPrefab);
        MakePreview(previewInstance);
    }
}
