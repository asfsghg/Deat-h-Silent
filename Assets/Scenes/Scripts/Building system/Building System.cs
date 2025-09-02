using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class Build : MonoBehaviour
{
    public LayerMask groundMask;
    [SerializeField] private GameObject BuildingOBJ;
    public bool _canBuild = true;
    
    void LateUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 50f, groundMask))
        {
            BuildingOBJ.transform.position = hit.point; 
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            
                BuildingOBJ.transform.Rotate(Vector3.forward, 90);
            
        
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            BuildingOBJ.transform.Rotate(Vector3.up, -90f);
            
        }
    }
    
}

