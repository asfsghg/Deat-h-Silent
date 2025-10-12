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
    private float yRotation = 0f;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (selectedPrefab == null)
        {
            if (previewInstance != null)
            {
                Destroy(previewInstance);
                previewInstance = null;
            }
            return;
        }

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, maxRayDistance, groundMask))
        {
 
            if (previewInstance == null)
            {
                previewInstance = Instantiate(selectedPrefab);
                MakePreview(previewInstance);
            }

            Transform targetPoint = null;
            


            if (hit.collider.TryGetComponent(out Build build))
            {
      
                if (previewInstance.CompareTag("NoBaseplate"))
                {
                    targetPoint = build.SetBuild(hit.point);
                }
                else
                {
                    targetPoint = build.SetBuildWall(hit.point);
                }

                if (targetPoint != null)
                {
                    previewInstance.transform.position = targetPoint.position;
                    previewInstance.transform.rotation = targetPoint.rotation;
                }
            }

          
            
            else
            {

                previewInstance.transform.position = hit.point;
                previewInstance.transform.rotation = Quaternion.Euler(0, yRotation, 0);
            }

  
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 spawnPos = targetPoint != null ? targetPoint.position : hit.point;
                Quaternion spawnRot = targetPoint != null ? targetPoint.rotation : Quaternion.Euler(0, yRotation, 0);

                Instantiate(selectedPrefab, spawnPos, spawnRot);

                Destroy(previewInstance);
                previewInstance = null;
                selectedPrefab = null;
            }
        }


        if (Input.GetKeyDown(KeyCode.R) && previewInstance != null)
        {
            yRotation += 90f;
            previewInstance.transform.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }


    private void MakePreview(GameObject go)
    {
        foreach (var c in go.GetComponentsInChildren<Collider>())
            c.enabled = false;

        foreach (var rb in go.GetComponentsInChildren<Rigidbody>())
            Destroy(rb);

        foreach (var r in go.GetComponentsInChildren<Renderer>())
        {
            foreach (var mat in r.materials)
            {
                Material previewMat = new Material(mat);
                previewMat.color = new Color(0f, 1f, 0f, 0.5f); 
                r.material = previewMat;
            }
        }
    }



    public void BaseplateSpawn() => SelectPrefab(baseplatePrefab);
    public void StairsSpawn() => SelectPrefab(stairsPrefab);
    public void WallSpawn() => SelectPrefab(wallPrefab);
    public void WindowSpawn() => SelectPrefab(windowPrefab);

    private void SelectPrefab(GameObject prefab)
    {
        selectedPrefab = prefab;
        yRotation = 0f;

        if (previewInstance != null)
            Destroy(previewInstance);

        previewInstance = Instantiate(selectedPrefab);
        MakePreview(previewInstance);
    }
}


