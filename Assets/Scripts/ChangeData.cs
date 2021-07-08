using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeData : MonoBehaviour {
    
    public int amountOfDays;
    public int amountOfHours;

    public Text amountOfDaysText;
    public Text amountOfHoursText;

    public void ButtonClick() {

        amountOfHours++;

        if (amountOfHours == 24) {
            amountOfDays++;
            amountOfHours = 0;
            amountOfDaysText.text = "Дней: " + amountOfDays.ToString();
            amountOfHoursText.text = "Часов: " + amountOfHours.ToString();
        } else {
            amountOfHoursText.text = "Часов: " + amountOfHours.ToString();
        }

    }

}