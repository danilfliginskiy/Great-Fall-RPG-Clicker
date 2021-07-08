﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Slider hungerBar;
    public GameObject DeathPanel;

    public float maTime = 3f;
    float timeLeft=0;

    bool timerRunning = false;

    void Start()
    {    
        timeLeft = maTime;
    }

    void Update()
    {
        if (timerRunning == true)
        {
            if(hungerBar.value != 0f)
            {
                timerRunning = false;
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
            }
               
        }
        
    }

    public void ButtonTimer()
    {
        timerRunning = true;
    }
}