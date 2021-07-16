using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warning : MonoBehaviour
{

    public WorkButton linkOnWorkButton;

    public GameObject WarningPanel;
    public Text warningText;

    public Slider healthBar;
    public Slider hungerBar;
    public Slider happinessBar;
    public Slider depressionBar;

    int a = 0;// переменная для скрытия warning панели 

    void Update()
    {

        if (healthBar.value != 0f && hungerBar.value != 0f && happinessBar.value != 0f && depressionBar.value != depressionBar.maxValue)
        {
            a = 0;
        }

        if ((healthBar.value == 0f && linkOnWorkButton.hittingInChance == false) || (hungerBar.value == 0f && linkOnWorkButton.hittingInChance == false) || (happinessBar.value == 0f && linkOnWorkButton.hittingInChance == false) || (depressionBar.value == depressionBar.maxValue && linkOnWorkButton.hittingInChance == false))
        {
            warningText.text = "Вы на грани смерти. Проверьте свое состояние. У вас есть 5 секунд, чтобы устранить проблему";
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
