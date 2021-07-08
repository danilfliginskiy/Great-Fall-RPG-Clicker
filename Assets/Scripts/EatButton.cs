using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatButton : MonoBehaviour {

    public WorkButton linkOnWorkButton; //Ссылка на другой скрипт

    public int foodPrice = 1; //Цена на еду
    public int addedHealth = 10; //Добавляемое здоровье
    public int addedEat = 25; //Добавляемая еда
    public int takeAwayHappiness = -5; //Отнимаемое счастье

    //Ссылка на слайдеры
    public Slider healthBar;
    public Slider hungerBar;
    public Slider happinessBar;

    public void ButtonClick() {

        //Отнимаем деньги за еду
        linkOnWorkButton.amountOfMoney -= foodPrice;

        //Добавляем характеристики
        healthBar.value += addedHealth;
        hungerBar.value += addedEat;

        //Если куплен донат, то активируем улучшения
        if (linkOnWorkButton.checkingThePurchasedDoubleStrength == false) {
            happinessBar.value -= takeAwayHappiness;
        } else {
            happinessBar.value -= (takeAwayHappiness / 2);
        }

        //Изменяем моенты в UI
        linkOnWorkButton.amountOfMoneyText.text = linkOnWorkButton.amountOfMoney.ToString();

    }

}