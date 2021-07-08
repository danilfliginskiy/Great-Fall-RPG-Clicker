using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AddExperience : MonoBehaviour {

    public int level = 1; //Уровень
    public int[] progressAmount = new int[] { 20, 30, 40, 150, 200, 250, 300, 375, 450, 600}; //Кол-во опыта в уровне
    public int i = 0;

    public int[] statsAmount = new int[] { 140, 180, 230, 300, 400, 520, 640, 800, 950, 1100}; //Кол-во очков харакетристик на каждом уровне

    //Слайдеры для изменения показателей с увеличением уровня
    public Slider healthBar;
    public Slider hungerBar;
    public Slider happinessBar;
    public Slider depressionBar;

    //Прочие объекты, нужные для работы 
    public Slider progressBar;
    public Text lvl;
    public Text levelProgress;

    public void ButtonClick() {

        //Заполнение шкалы опыта
        progressBar.value++;
        levelProgress.text = progressBar.value + "/" + progressAmount[i] + " XP";
        
        if (progressBar.value == progressAmount[i]) {

            //Повышение уровня
            level++;

            if (i < 9)
            {
                i++;
            }
            else
            {
                i = 9;
            }

            //Обнуление шкалы опыта и вывод этого на экран
            lvl.text = level.ToString();
            progressBar.maxValue = progressAmount[i];
            progressBar.value = 0;
            levelProgress.text = progressBar.value + "/" + progressAmount[i] + " XP";

            //Увеличение харакетристик персонажа
            healthBar.maxValue = statsAmount[i];
            hungerBar.maxValue = statsAmount[i];
            happinessBar.maxValue = statsAmount[i];
            depressionBar.maxValue = statsAmount[i];

        }

    }

}
