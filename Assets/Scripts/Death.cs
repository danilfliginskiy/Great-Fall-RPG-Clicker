using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{

    public Text lvl;
    public Text levelProgress;
    public Text days;
    public Text hours;
    public Text money;
    public Slider progressBar;
    public GameObject DeathPanel;
    public Slider healthBar;
    public Slider hungerBar;
    public Slider happinessBar;
    public Slider depressionBar;


    public void AceptButton()
    {
        progressBar.value = 0f;
        depressionBar.value = 0f;
        healthBar.value = 100f;
        hungerBar.value = 100f;
        happinessBar.value = 100f;
        lvl.text = "0";
        levelProgress.text = "0/40 XP";
        money.text = "0";
        days.text = "Дней: 0";
        hours.text = "Часов: 0";
        DeathPanel.SetActive(false);


    }
    public void PayOffButton()
    {

    }
}