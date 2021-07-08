using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepressionButton : MonoBehaviour {

    public Text takeAwayDepression; //Отнимаемая депрессия

    public Slider depressionBar;

    public ChangeData linkOnChangeData; //Ссылка на другой скрипт

    public void ButtonClick() {

        //Отнимаем депрессию
        depressionBar.value += Convert.ToInt32(takeAwayDepression.text);

        //Прибавляем часы
        linkOnChangeData.amountOfHours += 3;

        //Меняем кол-во часов и дней
        if (linkOnChangeData.amountOfHours == 24) {
            linkOnChangeData.amountOfDays++;
            linkOnChangeData.amountOfHours = 0;
            linkOnChangeData.amountOfDaysText.text = "Дней: " + linkOnChangeData.amountOfDays.ToString();
            linkOnChangeData.amountOfHoursText.text = "Часов: " + linkOnChangeData.amountOfHours.ToString();
        } else if (linkOnChangeData.amountOfHours > 24) {
            linkOnChangeData.amountOfDays++;
            linkOnChangeData.amountOfHours -= 24;
            linkOnChangeData.amountOfDaysText.text = "Дней: " + linkOnChangeData.amountOfDays.ToString();
            linkOnChangeData.amountOfHoursText.text = "Часов: " + linkOnChangeData.amountOfHours.ToString();
        } else {
            linkOnChangeData.amountOfHoursText.text = "Часов: " + linkOnChangeData.amountOfHours.ToString();
        }

    }

}
