using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Build : MonoBehaviour
{
    public LayerMask groundMask;
    [SerializeField] private GameObject BuildingOBJ;
    public bool _canBuild = true;
    public float gridSize = 0.1f;
    [SerializeField] private GameObject SpawnPrefab;
    
    void LateUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 50f, groundMask))
        {
            Vector3 pos = hit.point;

            BuildingOBJ.transform.position = pos;
        }
 
        if (Input.GetKeyDown(KeyCode.R))
        {
            BuildingOBJ.transform.Rotate(Vector3.forward, 90);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            BuildingOBJ.transform.Rotate(Vector3.up, -90f);
        }

        if (Input.GetMouseButtonDown(0))
        {
           

                Instantiate(SpawnPrefab, BuildingOBJ.transform.position, BuildingOBJ.transform.rotation);
        }
    }
}