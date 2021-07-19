using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Slider healthBar;
    public Slider hungerBar;
    public Slider happinessBar;
    public Slider depressionBar;

    public GameObject DeathPanel;
    public Text timer;

    public float maTime = 5f;
    float timeLeft = 0;

    bool timerRunning = false;

    void Start()
    {
        timeLeft = maTime;
    }

    void Update()
    {

        if (timerRunning == true)
        {
            timer.text = Mathf.Round(timeLeft).ToString();

            if (healthBar.value != 0f && hungerBar.value != 0f && happinessBar.value != 0f && depressionBar.value != 100f)
            {
                timerRunning = false;
                timeLeft = maTime;
                timer.text = " ";
            }

            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                
            }
            else
            {
                DeathPanel.SetActive(true);
                timerRunning = false;
                timeLeft = maTime;
                timer.text = " ";
            }

        }

    }

    public void ButtonTimer()
    {
        timerRunning = true;
    }

}
