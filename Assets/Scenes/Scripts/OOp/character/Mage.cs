using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _character : MonoCharacter
{

    protected override void DisplayHand()
    {
        Destroy(handTransform.GetComponentInChildren<Item>().gameObject);
    }
}
