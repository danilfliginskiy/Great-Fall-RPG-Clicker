using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepressionButton : MonoBehaviour {

    float takeAwayDepression = 0.3f; //Отнимаемая депрессия

    public Slider depressionBar;
    public ChangeData linkOnChangeData;

    public void ButtonClick() {

        //Отнимаем депрессию
        depressionBar.value -= takeAwayDepression;

        linkOnChangeData.amountOfHours += 3;

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
