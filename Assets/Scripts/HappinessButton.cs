using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappinessButton : MonoBehaviour {

    public WorkButton linkOnWorkButton; //Ссылка на другой скрипт

    public int holidayPrice = 0; //Цена на отдых
    public int addedHealth = 10; //Добавляемое здоровье
    public int takeAwayEat = 2; //Отнимаемая еда
    public int addedHappiness = 10; //Добавляемое счастье

    //Ссылка на слайдеры
    public Slider healthBar;
    public Slider hungerBar;
    public Slider happinessBar;

    public void ButtonClick() {

        //Отнимаем деньги за отдых
        linkOnWorkButton.amountOfMoney -= holidayPrice;

        //Если куплен донат, то активируем улучшения
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