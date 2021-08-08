using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatButton : MonoBehaviour {

    int chanceOfRandomEvent = 15; // 15% возникновения события
    System.Random randomVariable = new System.Random();

    int chanceOfRandomAdvertisingEvent = 10; // 10% возникновения события
    System.Random randomAdvertisingVariable = new System.Random();

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



    //Массив случайных рекламных событий на работе
    public string[,,] arrayOfRandomAdvertisingEvents = { //i

        { //j Означает номер уровня
            //k Означает событие и отнимаемые харакетристики
            {"Вы проходите мимо чьих-то похорон; Поесть на халяву, прикинувшись гостем?", "+", "20"},
            {"Богатый человек принял вас за своего друга; Отобедать с ним?", "+", "10"},
            {"Сегодня корчма раздает еду беднякам; Зайти?", "+", "10"},
            {"Кто-то опрокинул прилавок; Взять еды?", "+", "30"},
            {"Ваш бездомный товаришь поджарил вам крысу; Принять угощение?", "+", "20"}
        },

        { //j
            //k Означает событие и отнимаемые харакетристики
            {"У короля праздник, и все работяги могут поесть бесплатно; Посетить праздник?", "+", "15"},
            {"На премии 'Дворник недели' вам предложили тройной паек; Взяь?", "+", "30"},
            {"Ваш коллега проспорил вам паек; Взять его еду?", "+", "40"},
            {"Пекарь просит подмести у него в обмен на свежую булочку; Помочь?", "+", "15"},
            {"Вы подметали после концерта барда. Еда, которой в него кидали, была вполне съестной; Подобрать?", "+", "40"}
        },

        { //j
            //k Означает событие и отнимаемые харакетристики
            {"Молодой барин просит вас поухаживать за его конем пару дней. Взамен он предлагает вам хорошую еду; Согласиться?", "+", "30"},
            {"Барин устроил конную прогулку и позвал вас с собой. Обед входит в эту прогулку; Поехать?", "+", "40"},
            {"Сегодня хозяи в хорошем расположении духа. Он предлагает вам отобедать с ним; Согласиться?", "+", "30"},
            {"Дочь хозяина пришла в конюшни, чтоб угостить вас; Принять ее угощение?", "+", "50"},
            {"Хозяин устраивает скачки. Главный приз - корзина с фруктами; Принять участие?", "+", "50"}
        }

    };


    //Ссылки на элементы для случайных событий
    public GameObject randomEventBG;
    public Text randomEventText;
    public Text userLevel;

    public GameObject randomAdvertisingEventBG;
    public Text randomAdvertisingEventText;

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
                for (int m = 0; m < linkOnSelectFood.buttonsInShop.Length; m++)
                {

                    if (linkOnSelectFood.textOfButtonsInShop[m].text == "Выбрано")
                    {

                        //Используем нужные случайные события
                        for (int j = 1; j <= arrayOfRandomAdvertisingEvents.GetLength(1); j++)
                        {

                            for (int k = 1; k <= arrayOfRandomAdvertisingEvents.GetLength(2); k++)
                            {

                                differenceInLevels = Convert.ToInt32(userLevel.text) - linkOnShopOfEat.neededLVLArray[m] + 1;

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

                                linkOnWorkButton.health_1.text = arrayOfRandomAdvertisingEvents[m, randomAdvertisingEvent, 1] + randomHealth.ToString();
                                linkOnWorkButton.eat_1.text = arrayOfRandomAdvertisingEvents[m, randomAdvertisingEvent, 1] + randomEat.ToString();
                                linkOnWorkButton.happy_1.text = arrayOfRandomAdvertisingEvents[m, randomAdvertisingEvent, 1] + randomHappy.ToString();

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