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

        if (healthBar.value != 0f && hungerBar.value != 0f && happinessBar.value != 0f && depressionBar.value != 100f)
        {
            a = 0;
        }

        if (healthBar.value == 0f && linkOnWorkButton.hittingInChance == false)
        {
            warningText.text = "У вас не осталось жизней. У вас есть 5 секунд, чтобы восстановить здоровье";
            WarningPanel.SetActive(true);
        }

        if (hungerBar.value == 0f && linkOnWorkButton.hittingInChance == false)
        {
            warningText.text = "Вы слишком голодны. У вас есть 5 секунд, чтобы покушать";
            WarningPanel.SetActive(true);
        }

        if (happinessBar.value == 0f && linkOnWorkButton.hittingInChance == false)
        {
            warningText.text = "У вас совсем нет сил. У вас есть 5 секунд, чтобы отдохнуть";
            WarningPanel.SetActive(true);
        }

        if (depressionBar.value == 100f && linkOnWorkButton.hittingInChance == false)
        {
            warningText.text = "Вы переутомлены. У вас есть 5 секунд, чтобы развлечься";
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
