using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatButton : MonoBehaviour {

    public WorkButton linkOnWorkButton;

    public int foodPrice = 1; //Цена на еду
    float addedHealth = 0.1f; //Добавляемое здоровье
    float addedEat = 0.25f; //Добавляемая еда
    float takeAwayHappiness = 0.05f; //Отнимаемое счастье

    public Slider healthBar;
    public Slider hungerBar;
    public Slider happinessBar;

    public void ButtonClick() {

        //Отнимаем деньги за еду
        linkOnWorkButton.amountOfMoney -= foodPrice;

        //Отнимаем/добавляем характеристики
        healthBar.value += addedHealth;
        hungerBar.value += addedEat;

        if (linkOnWorkButton.checkingThePurchasedDoubleStrength == false) {
            happinessBar.value -= takeAwayHappiness;
        } else {
            happinessBar.value -= (takeAwayHappiness / 2);
        }

        //Изменяем моенты в UI
        linkOnWorkButton.amountOfMoneyText.text = linkOnWorkButton.amountOfMoney.ToString();

    }

}