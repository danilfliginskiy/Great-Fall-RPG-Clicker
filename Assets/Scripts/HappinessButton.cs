using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappinessButton : MonoBehaviour {

    public WorkButton linkOnWorkButton;

    public int holidayPrice = 0; //Цена на отдых
    float addedHealth = 0.1f; //Добавляемое здоровье
    float takeAwayEat = 0.02f; //Отнимаемая еда
    float addedHappiness = 0.1f; //Добавляемое счастье

    public Slider healthBar;
    public Slider hungerBar;
    public Slider happinessBar;

    public void ButtonClick() {

        //Отнимаем деньги за отдых
        linkOnWorkButton.amountOfMoney -= holidayPrice;

        if (linkOnWorkButton.checkingThePurchasedDoubleStrength == false) {
            hungerBar.value -= takeAwayEat;
        } else {
            hungerBar.value -= (takeAwayEat / 2);
        }
        
        //Отнимаем/добавляем характеристики
        healthBar.value += addedHealth;
        happinessBar.value += addedHappiness;

        //Изменяем моенты в UI
        linkOnWorkButton.amountOfMoneyText.text = linkOnWorkButton.amountOfMoney.ToString();

    }

}