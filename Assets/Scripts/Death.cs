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
    public GameObject RefinementPanel;
    public GameObject AdvertisingPanel;

    public void RefinementButton() //Вызывает панель уточнения
    {
        DeathPanel.SetActive(false);
        RefinementPanel.SetActive(true);
    }

    public void AdvertisingButton() //Вызывает панель уточнения
    {
        DeathPanel.SetActive(false);
        AdvertisingPanel.SetActive(true);
    }

    public void NoButton() //Возвращает к панели смерти
    {
        RefinementPanel.SetActive(false);
        AdvertisingPanel.SetActive(false);
        DeathPanel.SetActive(true);
    }


    public void AceptButton() //Подтверждает выбор смерти
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
        RefinementPanel.SetActive(false);
        DeathPanel.SetActive(false);


    }
    public void PayOffButton() //Запускает рекламу
    {

    }
}
