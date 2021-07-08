using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkButton : MonoBehaviour {

    public bool checkingThePurchasedDoubleSalary = false; //Проверка покупки доната
    public bool checkingThePurchasedDoubleStrength = false; //Проверка покупки доната

    public int amountOfMoney = 0; //Кол-во монет при старте
    public int moneyMultiplier = 1; //Множитель заработка

    public int takeAwayHealth = -10; //Отнимаемое здоровье
    public int takeAwayEat = -10; //Отнимаемая еда
    public int takeAwayHappiness = -10; //Отнимаемое счастье
    public int addDepression = 10; //Получаемое утомление

    public Text amountOfMoneyText; //Кол-во денег

    //Ссылки на слайдеры с харакетристиками
    public Slider healthBar;
    public Slider hungerBar;
    public Slider happinessBar;
    public Slider depressionBar;

    public void ButtonClick() {

        //Если донат куплен, то активировать улучшения
        if (checkingThePurchasedDoubleSalary == false) {
            amountOfMoney += moneyMultiplier;
        } else {
            amountOfMoney += (moneyMultiplier * 2);
        }

        //Если донат куплен, то активировать улучшения
        if (checkingThePurchasedDoubleStrength == false) {
            healthBar.value += takeAwayHealth;
            hungerBar.value += takeAwayEat;
            happinessBar.value += takeAwayHappiness;
        } else {
            healthBar.value += (takeAwayHealth / 2);
            hungerBar.value += (takeAwayEat / 2);
            happinessBar.value += (takeAwayHappiness / 2);
        }

        depressionBar.value += addDepression; //Добавить утомление

        //Прибавляем монеты в UI
        amountOfMoneyText.text = amountOfMoney.ToString();

    }

}