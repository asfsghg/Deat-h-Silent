using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpp : MonoBehaviour
{
    Image healtBar;
    public float maxHP = 100f;
    public float HP;
    // Start is called before the first frame update
    void Start()
    {
        healtBar = GetComponent<Image>();
        HP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        healtBar.fillAmount = HP / maxHP ;
    }
}
