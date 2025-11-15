using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour, IUsable
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Use();


        }
    }
    public void Use()
    {
        Debug.Log(" 1");
       
        Destroy(gameObject);
    }

}
