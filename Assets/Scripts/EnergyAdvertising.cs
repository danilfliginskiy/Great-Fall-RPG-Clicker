using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyAdvertising : MonoBehaviour
{

    public GameObject EnergyPanel;

    public void ButtonClick()
    {
        EnergyPanel.SetActive(true);
    }
    public void NoButtonClick()
    {
        EnergyPanel.SetActive(false);
    }
    public void YesButtonClick()
    {
        EnergyPanel.SetActive(false);
    }

}
