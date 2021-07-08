using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AddExperience : MonoBehaviour {

    public int level = 1; //Уровень
    public float[] addedProgress = new float[] { 0.1f, 0.05f, 0.05f, 0.05f, 0.03f, 0.03f, 0.03f, 0.02f, 0.02f, 0.01f}; //Добавляемый опыт
    public int i = 0;
    public int maxLevelProgress = 40;

    public Slider progressBar;
    public Text lvl;
    public Text levelProgress;

    public void ButtonClick() {

        //Заполнение шкалы опыта
        progressBar.value += addedProgress[i];
        levelProgress.text = Math.Round(progressBar.value * maxLevelProgress) + "/" + maxLevelProgress;
        if (progressBar.value == 1f)
        {
            level++;
            if (i < 9)
            {
                i++;
            }
            else
            {
                i = 9;
            }

            lvl.text = level.ToString();
            progressBar.value = 0f;
            maxLevelProgress += 20;
            levelProgress.text = (progressBar.value * 100) + "/" + maxLevelProgress + " XP";

        }

    }

}
