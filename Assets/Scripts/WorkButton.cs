using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkButton : MonoBehaviour {

    int chanceOfRandomEvent = 15; // 15% возникновения события
    System.Random randomVariable = new System.Random();

    int chanceOfRandomAdvertisingEvent = 10; // 10% возникновения события
    System.Random randomAdvertisingVariable = new System.Random();

    //Массив случайных событий на работе
    public string[,,] arrayOfRandomEvents = { //i

        { //j Означает номер уровня
            //k Означает событие и отнимаемые харакетристики
            {"Побили хулиганы", "-", "20"},
            {"Посетила налоговая", "-", "10"},
            {"Задержала полиция", "-", "10"},
            {"Атаковали собаки", "-", "30"},
            {"Добряк пожелал хорошего дня", "+", "20"}
        },

        { //j
            //k Означает событие и отнимаемые харакетристики
            {"Бросили мусор под ноги", "-", "15"},
            {"Поздоровались и пожелали счастья", "+", "30"},
            {"Нашел деньги", "+", "40"},
            {"Ветер разнес листья", "-", "15"},
            {"Атаковали собаки", "-", "40"}
        },

        { //j
            //k Означает событие и отнимаемые харакетристики
            {"Лошадь сбежала", "-", "30"},
            {"Хозяин наругал", "-", "40"},
            {"Дети разбросали сено", "-", "30"},
            {"Хозяин дал премию", "+", "50"},
            {"Бандиты прокрались в хлев", "-", "50"}
        }

    };



    //Массив случайных рекламных событий на работе
    public string[,,] arrayOfRandomAdvertisingEvents = { //i

        { //j Означает номер уровня
            //k Означает событие и отнимаемые харакетристики
            {"Человек в шлеме с рогами подкинул септим; Взять его?", "+", "20"},
            {"Вы нашли чей-то кошель; Подобрать?", "+", "10"},
            {"Бард спел песню о попрошайке; Сказать, что это песня про вас?", "+", "10"},
            {"Умер родственник и оставил часть наследства; Получить его?", "+", "30"},
            {"Вы бродили по кладбищу, наткнулись на открытый склеп; Забрать сокровища?", "+", "20"}
        },

        { //j
            //k Означает событие и отнимаемые харакетристики
            {"Вы нашли немного монет в мусоре; Забрать?", "+", "15"},
            {"Вас пригласили подмести двор за дополнительную плату; Согласиться?", "+", "30"},
            {"Женщина в странной шляпе попросила продать ей метлу; Согласиться?", "+", "40"},
            {"На ваших глазах произошло убийство, преступники попросили замести следы; Помочь им?", "+", "15"},
            {"Вас прегласили на премию 'Дворник недели'; Пойти?", "+", "40"}
        },

        { //j
            //k Означает событие и отнимаемые харакетристики
            {"Вы нашли лошадиную подкову; Продать ее?", "+", "30"},
            {"Дама попросила подковать ее коня за вознаграждение; Помочь?", "+", "40"},
            {"Вы убирали за богатырским конем и обнаружили золото; Взять?", "+", "30"},
            {"Великий угонщик коней предложил помочь ему; Согласиться?", "+", "50"},
            {"Барин спросил, подходить ли имя 'Плотва' для его лошади?", "+", "50"}
        }

    };


    //Ссылки на элементы для случайных событий
    public GameObject randomEventBG;
    public Text randomEventText;
    public Text userLevel;
    public Text health;
    public Text eat;
    public Text happy;

    public GameObject randomAdvertisingEventBG;
    public Text randomAdvertisingEventText;
    public Text health_1;
    public Text eat_1;
    public Text happy_1;

    public bool hittingInChance;

    //Ссылки на другие скрипты
    public SelectProfession linkOnSelectProfession;
    public ShopOfWork linkOnShopOfWork;

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

        hittingInChance = false;

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

        int randomValue = randomVariable.Next(0, 100);

        //Появление случайного события с нужным для профессии текстом
        if (randomValue < chanceOfRandomEvent) {

            hittingInChance = true;
            int differenceInLevels;
            
            //Проходим массив случайных событий
            for (int i = 1; i <= arrayOfRandomEvents.GetLength(0); i++) {

                //Проходим массив кнопок в магазине
                for (int m = 0; m < linkOnSelectProfession.buttonsInShop.Length; m++) {

                    if (linkOnSelectProfession.textOfButtonsInShop[m].text == "Выбрано") {

                        //Используем нужные случайные события
                        for (int j = 1; j <= arrayOfRandomEvents.GetLength(1); j++) {

                            for (int k = 1; k <= arrayOfRandomEvents.GetLength(2); k++) {

                                differenceInLevels = Convert.ToInt32(userLevel.text) - linkOnShopOfWork.neededLVLArray[m] + 1;

                                int randomEvent = randomVariable.Next(0, 4);
                                randomEventText.text = arrayOfRandomEvents[m, randomEvent, 0];

                                int randomHealth = randomVariable.Next(0, Convert.ToInt32(arrayOfRandomEvents[m, randomEvent, 2])) * differenceInLevels;
                                int randomEat = randomVariable.Next(0, Convert.ToInt32(arrayOfRandomEvents[m, randomEvent, 2])) * differenceInLevels;
                                int randomHappy = randomVariable.Next(0, Convert.ToInt32(arrayOfRandomEvents[m, randomEvent, 2])) * differenceInLevels;

                                if (arrayOfRandomEvents[m, randomEvent, 1] == "+") {

                                    healthBar.value += randomHealth;
                                    hungerBar.value += randomEat;
                                    happinessBar.value += randomHappy;

                                } else {

                                    healthBar.value -= randomHealth;
                                    hungerBar.value -= randomEat;
                                    happinessBar.value -= randomHappy;

                                }

                                health.text = arrayOfRandomEvents[m, randomEvent, 1] + randomHealth.ToString();
                                eat.text = arrayOfRandomEvents[m, randomEvent, 1] + randomEat.ToString();
                                happy.text = arrayOfRandomEvents[m, randomEvent, 1] + randomHappy.ToString();

                                break;

                            }

                            break;

                        }

                        break;

                    }

                }

                break;

            }

            randomEventBG.SetActive(true);

        }



        int randomAdvertisingValue = randomVariable.Next(0, 100);

        //Появление случайного события с нужным для профессии текстом
        if (randomAdvertisingValue < chanceOfRandomAdvertisingEvent)
        {

            hittingInChance = true;
            int differenceInLevels;

            //Проходим массив случайных событий
            for (int i = 1; i <= arrayOfRandomAdvertisingEvents.GetLength(0); i++)
            {

                //Проходим массив кнопок в магазине
                for (int m = 0; m < linkOnSelectProfession.buttonsInShop.Length; m++)
                {

                    if (linkOnSelectProfession.textOfButtonsInShop[m].text == "Выбрано")
                    {

                        Debug.Log("Vibrano");

                        //Используем нужные случайные события
                        for (int j = 1; j <= arrayOfRandomAdvertisingEvents.GetLength(1); j++)
                        {

                            for (int k = 1; k <= arrayOfRandomAdvertisingEvents.GetLength(2); k++)
                            {

                                differenceInLevels = Convert.ToInt32(userLevel.text) - linkOnShopOfWork.neededLVLArray[m] + 1;

                                int randomAdvertisingEvent = randomVariable.Next(0, 4);
                                randomAdvertisingEventText.text = arrayOfRandomAdvertisingEvents[m, randomAdvertisingEvent, 0];

                                int randomHealth = randomVariable.Next(0, Convert.ToInt32(arrayOfRandomAdvertisingEvents[m, randomAdvertisingEvent, 2])) * differenceInLevels;
                                int randomEat = randomVariable.Next(0, Convert.ToInt32(arrayOfRandomAdvertisingEvents[m, randomAdvertisingEvent, 2])) * differenceInLevels;
                                int randomHappy = randomVariable.Next(0, Convert.ToInt32(arrayOfRandomAdvertisingEvents[m, randomAdvertisingEvent, 2])) * differenceInLevels;

                                if (arrayOfRandomAdvertisingEvents[m, randomAdvertisingEvent, 1] == "+")
                                {

                                    healthBar.value += randomHealth;
                                    hungerBar.value += randomEat;
                                    happinessBar.value += randomHappy;

                                }

                                health_1.text = arrayOfRandomAdvertisingEvents[m, randomAdvertisingEvent, 1] + randomHealth.ToString();
                                eat_1.text = arrayOfRandomAdvertisingEvents[m, randomAdvertisingEvent, 1] + randomEat.ToString();
                                happy_1.text = arrayOfRandomAdvertisingEvents[m, randomAdvertisingEvent, 1] + randomHappy.ToString();

                                break;

                            }

                            break;

                        }

                        break;

                    }

                }

                break;

            }

            randomAdvertisingEventBG.SetActive(true);

        }

    }

}