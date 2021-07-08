using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warning : MonoBehaviour
{

    public GameObject WarningPanel;
    public Slider hungerBar;
    int a = 0;// переменная для скрытия warning панели 

    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hungerBar.value != 0f)
        {
            a = 0;
        }
        if (hungerBar.value == 0f)
        {
            WarningPanel.SetActive(true);

        }
        if (a == 1)
        {

            WarningPanel.SetActive(false);


        }

    }
    public void WarningButton()
    {
        a = 1;
    }
}
