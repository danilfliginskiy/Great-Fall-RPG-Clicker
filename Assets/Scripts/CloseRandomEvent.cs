using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseRandomEvent : MonoBehaviour {
    
    public Warning linkOnWarning;
    public WorkButton linkOnWorkButton;

    public GameObject randomEventBG;

    public void ButtonClick() {

        randomEventBG.SetActive(false);

        if (linkOnWorkButton.healthBar.value == 0f)
        {
            linkOnWarning.warningText.text = "У вас не осталось жизней. У вас есть 5 секунд, чтобы восстановить здоровье";
            linkOnWarning.WarningPanel.SetActive(true);
        }

        if (linkOnWorkButton.hungerBar.value == 0f)
        {
            linkOnWarning.warningText.text = "Вы слишком голодны. У вас есть 5 секунд, чтобы покушать";
            linkOnWarning.WarningPanel.SetActive(true);
        }

        if (linkOnWorkButton.happinessBar.value == 0f)
        {
            linkOnWarning.warningText.text = "У вас совсем нет сил. У вас есть 5 секунд, чтобы отдохнуть";
            linkOnWarning.WarningPanel.SetActive(true);
        }

        if (linkOnWorkButton.depressionBar.value == 100f)
        {
            linkOnWarning.warningText.text = "Вы переутомлены. У вас есть 5 секунд, чтобы развлечься";
            linkOnWarning.WarningPanel.SetActive(true);
        }

    }

}
