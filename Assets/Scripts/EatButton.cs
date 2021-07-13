using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatButton : MonoBehaviour {

    // int chanceOfRandomEvent = 5; // 5% возникновения события
    // System.Random randomVariable = new System.Random();

    // //Массив случайных событий на работе
    // public string[,,] arrayOfRandomEvents = { //i

    //     { //j Означает номер уровня
    //         //k Означает событие и отнимаемые харакетристики
    //         {"Побили хулиганы", "-20", "0", "-20", "+20"},
    //         {"Посетила налоговая", "0", "-10", "-10", "+40"},
    //         {"Задержала полиция", "0", "-10", "-20", "+30"},
    //         {"Атаковали собаки", "-40", "-10", "-20", "0"},
    //         {"Добряк пожелал хорошего дня", "0", "0", "+10", "-50"}
    //     },

    //     { //j
    //         //k Означает событие и отнимаемые харакетристики
    //         {"Бросили мусор под ноги", "-10", "-10", "-20", "+20"},
    //         {"Поздоровались и пожелали счастья", "0", "0", "+10", "-50"},
    //         {"Нашел деньги", "0", "0", "+10", "-50"},
    //         {"Ветер разнес листья", "-10", "-10", "-20", "+20"},
    //         {"Атаковали собаки", "-40", "-10", "-20", "0"}
    //     },

    //     { //j
    //         //k Означает событие и отнимаемые харакетристики
    //         {"Лошадь сбежала", "-10", "-20", "-20", "+20"},
    //         {"Хозяин наругал", "0", "0", "-10", "+20"},
    //         {"Дети разбросали сено", "-10", "-10", "-20", "+20"},
    //         {"Хозяин дал премию", "0", "0", "+20", "-30"},
    //         {"Бандиты прокрались в хлев", "-30", "-20", "-20", "+50"}
    //     }

    // };

    //Ссылки на элементы для случайных событий
    public GameObject randomEventBG;
    public Text randomEventText;
    public Text userLevel;

    //Ссылки на другие скрипты
    public SelectProfession linkOnSelectProfession;
    public ShopOfWork linkOnShopOfWork;

    public WorkButton linkOnWorkButton; //Ссылка на другой скрипт

    public int foodPrice = 0; //Цена на еду
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