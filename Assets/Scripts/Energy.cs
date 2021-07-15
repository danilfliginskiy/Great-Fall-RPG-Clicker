using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    public Button eatButton;
    public Button workButton;
    public Button happinesButton;
    public Button depressionButton;
    public Text energyText;

    public int energy = 300;

    public float mTime = 60f;
    float timeLeft = 0;
    bool timerRunning = false;

    void Start()
    {
        timeLeft = mTime;
    }

    void Update()
    {

        if (timerRunning == true)
        {
            if (energy == 300)
            {
                timerRunning = false;
            }
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
            else
            {
                energy += 1;
                timeLeft = mTime;
            }

        }
        energyText.text = energy.ToString() + "/300";
        if(energy != 0)
        {
            eatButton.interactable = true;
            workButton.interactable = true;
            happinesButton.interactable = true;
            depressionButton.interactable = true;
        }
    }

    public void Button()
    {
        energy -= 1;
        timerRunning = true;
        if (energy == 0)
        {
            eatButton.interactable= false;
            workButton.interactable = false;
            happinesButton.interactable = false;
            depressionButton.interactable = false;
        }
    }
}
