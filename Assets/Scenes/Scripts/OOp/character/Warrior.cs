using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoCharacter
{
    public override void Death()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
        Debug.Log("Character Death");
        Destroy(gameObject,1.5f);
    }
}
