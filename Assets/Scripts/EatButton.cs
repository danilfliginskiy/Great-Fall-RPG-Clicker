using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatButton : MonoBehaviour {

    int chanceOfRandomEvent = 15; // 15% возникновения события
    System.Random randomVariable = new System.Random();

    //Массив случайных событий на работе
    public string[,,] arrayOfRandomEvents = { //i

        { //j Означает номер уровня
            //k Означает событие и отнимаемые харакетристики
            {"Еда оказалась просрочена", "-", "20"},
            {"Собаки отобрали еду", "-", "30"},
            {"Прохожий дал еды", "+", "20"},
            {"Печенье на дороге было только из печи", "+", "20"},
            {"Кто-то забыл еду на лавочке", "+", "20"}
        },

        { //j
            //k Означает событие и отнимаемые харакетристики
            {"Паек оказался просроченным", "-", "25"},
            {"Хлеб в пайке был черствый", "-", "15"},
            {"Кто-то стянул твою еду с лавочки", "-", "30"},
            {"Кто-то случайно положил две порции в паек", "+", "30"},
            {"Увидеть яблоко в обеде было очень приятно", "+", "30"}
        },

        { //j
            //k Означает событие и отнимаемые харакетристики
            {"Барин опять дал несвежую еду", "-", "30"},
            {"Лишили обеда за провинность", "-", "40"},
            {"Лошадь украла овощи и фрукты с обеда", "-", "20"},
            {"Хозяин угостил вином", "+", "20"},
            {"Угостили пирогом", "+", "20"}
        }

    };

    //Ссылки на элементы для случайных событий
    public GameObject randomEventBG;
    public Text randomEventText;
    public Text userLevel;

    public bool hittingInChance;

    //Ссылки на другие скрипты
    public SelectFood linkOnSelectFood;
    public ShopOfEat linkOnShopOfEat;

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

        hittingInChance = false;

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

        int randomValue = randomVariable.Next(0, 100);

        //Появление случайного события с нужным для профессии текстом
        if (randomValue < chanceOfRandomEvent) {

            hittingInChance = true;
            int differenceInLevels;
            
            //Проходим массив случайных событий
            for (int i = 1; i <= arrayOfRandomEvents.GetLength(0); i++) {

                //Проходим массив кнопок в магазине
                for (int m = 0; m < linkOnSelectFood.buttonsInShop.Length; m++) {

                    if (linkOnSelectFood.textOfButtonsInShop[m].text == "Выбрано") {

                        //Используем нужные случайные события
                        for (int j = 1; j <= arrayOfRandomEvents.GetLength(1); j++) {

                            for (int k = 1; k <= arrayOfRandomEvents.GetLength(2); k++) {

                                differenceInLevels = Convert.ToInt32(userLevel.text) - linkOnShopOfEat.neededLVLArray[m] + 1;

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

                                linkOnWorkButton.health.text = arrayOfRandomEvents[m, randomEvent, 1] + randomHealth.ToString();
                                linkOnWorkButton.eat.text = arrayOfRandomEvents[m, randomEvent, 1] + randomEat.ToString();
                                linkOnWorkButton.happy.text = arrayOfRandomEvents[m, randomEvent, 1] + randomHappy.ToString();

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

    }

}