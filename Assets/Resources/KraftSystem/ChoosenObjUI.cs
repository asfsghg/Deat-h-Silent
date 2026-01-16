using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 

public class ChoosenObjUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCost;
    [SerializeField] private TextMeshProUGUI textName;
    
    [SerializeField] private List<ScriptableObject> needResources;
    
    [SerializeField] private List<int> costList;
    
 
    [SerializeField] private Slider progressBar;

    public void ButtonPressed()
    {
        if (textCost == null || textName == null)
        {
            
            return; 
        }


        textName.text = "";
        textCost.text = "";

        for (int i = 0; i < needResources.Count; i++)
        {
            if (needResources[i] != null)
            {
                textName.text += needResources[i].name + "\n";
                if (i < costList.Count)
                {
                    textCost.text += costList[i].ToString() + "\n";
                    
                }
                else
                {
                    textCost.text += "0\n";
                }
            }
        }
    }

    
}