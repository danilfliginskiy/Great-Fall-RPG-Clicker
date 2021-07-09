using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{

    //Ссылки на другие скрипты
    public WorkButton linkOnWorkButton;
    public ChangeData linkOnChangeData;
    public AddExperience linkOnAddExperience;

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


    public void AceptButton() {

        //Обнуление прогресса при смерти
        progressBar.value = 0;
        lvl.text = "1";
        levelProgress.text = "0/20 XP";
        linkOnAddExperience.level = 1;
        linkOnAddExperience.index = 0;
        progressBar.maxValue = linkOnAddExperience.amountOfProgress[0];
        linkOnAddExperience.addedProgress = 1;

        depressionBar.value = 0;
        healthBar.value = 100;
        hungerBar.value = 100;
        happinessBar.value = 100;
        money.text = "0";
        linkOnWorkButton.amountOfMoney = 0;
        //Добавить присовение первых элементов магазина
        
        days.text = "Дней: 0";
        hours.text = "Часов: 0";
        linkOnChangeData.amountOfDays = 0;
        linkOnChangeData.amountOfHours = 0;

        DeathPanel.SetActive(false);

    }

    public void PayOffButton() {

    }
}