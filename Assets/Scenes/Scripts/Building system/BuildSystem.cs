using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class BuildSystem : MonoBehaviour
{
    [SerializeField] private GameObject Baseplate;
    [SerializeField] private GameObject Stairs;
    [SerializeField] private GameObject Wall;
    [SerializeField] private GameObject Window;
    private GameObject _spawn;
    private bool _canBuild = true;
    private bool _IsSpawned = false;
    [SerializeField] private LayerMask groundMask;
    void LateUpdate()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 10f, groundMask))
        {
            _spawn.transform.position = hit.point;
            if (Input.GetMouseButtonDown(0))
            {
                
                Instantiate(_spawn, hit.point, _spawn.transform.rotation);
                Debug.Log(11111);
                _IsSpawned = false;
            }
        }
    }
   

    public void BaseplateSpawn()
    {
        if (_IsSpawned == false)
        {
            _spawn = Instantiate(Baseplate);
            _IsSpawned = true;
        }
       
    }
    public void StairsSpawn()
    {
        if (_IsSpawned == false)
        {
            _spawn = Instantiate(Baseplate);
            _IsSpawned = true;
        }
    }
    public void WallSpawn()
    {
        if (_IsSpawned == false)
        {
            _spawn = Instantiate(Baseplate);
            _IsSpawned = true;
        }
    }
    public void WindowSpawn()
    {
        if (_IsSpawned == false)
        {
            _spawn = Instantiate(Baseplate);
            _IsSpawned = true;
        }
    }
    
}
