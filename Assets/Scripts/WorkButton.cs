using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkButton : MonoBehaviour {

    public bool checkingThePurchasedDoubleSalary = false;
    public bool checkingThePurchasedDoubleStrength = false;

    public int amountOfMoney = 0; //Кол-во монет при старте
    public int moneyMultiplier = 1; //Множитель заработка

    float takeAwayHealth = 0.1f; //Отнимаемое здоровье
    float takeAwayEat = 0.1f; //Отнимаемая еда
    float takeAwayHappiness = 0.1f; //Отнимаемое счастье
    float addDepression = 0.1f; //Получаемое утомление

    public Text amountOfMoneyText;
    public Slider healthBar;
    public Slider hungerBar;
    public Slider happinessBar;
    public Slider depressionBar;
    public Button buttonWork;

    public void ButtonClick() {

        if (checkingThePurchasedDoubleSalary == false) {
            amountOfMoney += moneyMultiplier;
        } else {
            amountOfMoney += (moneyMultiplier * 2);
        }

        if (checkingThePurchasedDoubleStrength == false) {
            healthBar.value -= takeAwayHealth;
            hungerBar.value -= takeAwayEat;
            happinessBar.value -= takeAwayHappiness;
        } else {
            healthBar.value -= (takeAwayHealth / 2);
            hungerBar.value -= (takeAwayEat / 2);
            happinessBar.value -= (takeAwayHappiness / 2);
        }

        depressionBar.value += addDepression;

        //Прибавляем монеты в UI
        amountOfMoneyText.text = amountOfMoney.ToString();

    }

}