using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AddExperience : MonoBehaviour
{

    public int level = 1; //Уровень
    public int[] amountOfProgress = new int[] { 20, 30, 40, 60, 80, 100, 120, 140, 150 }; //Добавляемый опыт
    public int[] amountOfLVL = new int[] { 100, 130, 150, 180, 230, 275, 350, 450, 600, 700 }; //Кол-во опыта в уровне
    public int index = 0;
    public int addedProgress = 1;

    public Slider progressBar;
    public Text lvl;
    public Text levelProgress;

    public Slider healthBar;
    public Slider hungerBar;
    public Slider happinessBar;
    public Slider depressionBar;

    public void ButtonClick()
    {

        //Заполнение шкалы опыта
        progressBar.value += addedProgress;
        levelProgress.text = progressBar.value + "/" + progressBar.maxValue + " XP";
        
        if (progressBar.value == amountOfProgress[index]) {

            level++;

            if (index < 9) {
                index++;
            } else {
                index = 9;
            }

            lvl.text = level.ToString();
            progressBar.value = 0;
            progressBar.maxValue = amountOfProgress[index];
            levelProgress.text = progressBar.value + "/" + progressBar.maxValue + " XP";

            healthBar.maxValue = amountOfLVL[index];
            hungerBar.maxValue = amountOfLVL[index];
            happinessBar.maxValue = amountOfLVL[index];
            depressionBar.maxValue = amountOfLVL[index];

        }

    }

}
