using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseRandomEvent : MonoBehaviour {
    
    public Warning linkOnWarning;
    public WorkButton linkOnWorkButton;

    public GameObject randomEventBG;

    public void ButtonClick() {

        randomEventBG.SetActive(false);

        if (linkOnWorkButton.healthBar.value == 0f || linkOnWorkButton.hungerBar.value == 0f || linkOnWorkButton.happinessBar.value == 0f || linkOnWorkButton.depressionBar.value == linkOnWorkButton.depressionBar.maxValue)
        {
            linkOnWarning.warningText.text = "Вы на грани смерти. Проверьте свое состояние. У вас есть 5 секунд, чтобы устранить проблему";
            linkOnWarning.WarningPanel.SetActive(true);
        }

    }

}
