using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappinessButton : MonoBehaviour {

    int chanceOfRandomEvent = 15; // 15% возникновения события
    System.Random randomVariable = new System.Random();

    int chanceOfRandomAdvertisingEvent = 10; // 10% возникновения события
    System.Random randomAdvertisingVariable = new System.Random();

    //Массив случайных событий на работе
    public string[,,] arrayOfRandomEvents = { //i

        { //j Означает номер уровня
            //k Означает событие и отнимаемые харакетристики
            {"Собаки мешали спать", "-", "20"},
            {"Молодежь шумела всю ночь", "-", "30"},
            {"Было очень тихо", "+", "20"},
            {"На скамейке лежало одеяло", "+", "20"},
            {"Было холодно", "-", "20"}
        },

        { //j
            //k Означает событие и отнимаемые харакетристики
            {"По мосту бегали кони и некоторые камни падали на голову", "-", "25"},
            {"Комары закусали", "-", "15"},
            {"Бандиты доставили хлопот", "-", "30"},
            {"Уютная постель помогла выспаться", "+", "30"},
            {"Прохожий оставил одеяло на ночь", "+", "30"}
        },

        { //j
            //k Означает событие и отнимаемые харакетристики
            {"В сене были насекомые, которые покусали", "-", "30"},
            {"Лошадь сбежала и её пришлось ловить", "-", "40"},
            {"Барин пировал с гостями", "-", "20"},
            {"Сено было достаточно мягким", "+", "20"},
            {"Коты придали спокойствия и былj уютной", "+", "20"}
        }

    };



    //Массив случайных рекламных событий на работе
    public string[,,] arrayOfRandomAdvertisingEvents = { //i

        { //j Означает номер уровня
            //k Означает событие и отнимаемые харакетристики
            {"Когда-то вы помогли какому-то человеку. Он не забыл ваш поступок и приглашает переночевать у него; Принять приглашение?", "+", "20"},
            {"Перед городом был лагерь бандитов. В спешке они забыли спальный мешок; Переночевать в нем?", "+", "10"},
            {"Сегодня корчма работает всю ночь; Остаться на ночь в ней?", "+", "10"},
            {"Вы набрели на ночлежку; Переночевать тут?", "+", "30"},
            {"Сегодня ночью проходит праздник 'Цветение' - ежегодный кметский праздник; Принять участие в празднестве?", "+", "20"}
        },

        { //j
            //k Означает событие и отнимаемые харакетристики
            {"Вас нанимают в богатый дом на 2 дня, переночевать можно в нем; Согласиться?", "+", "15"},
            {"На премии 'Дворник недели' вам выделили койку в комнате отдыха; Отдохнуть?", "+", "30"},
            {"В корчме на втором этаже есть свободная комната; Хотите переночевать здесь за символическую плату?", "+", "40"},
            {"Подметая на кладбище, вы нашли открытый склеп. Страшно, зато тихо; Остаться спать тут?", "+", "15"},
            {"Вы можете напроситься к вашему коллеге на ночевку; Напроситься?", "+", "40"}
        },

        { //j
            //k Означает событие и отнимаемые харакетристики
            {"Барин выкидовал одеяло и решил предложить его вам; Принять подарок?", "+", "30"},
            {"Второй конюх предложил вам сыграть в покер на костях. В случае вашей победы он уступит мягкий стог сена.; Принять вызов?", "+", "40"},
            {"Вам одолжили книгу про беловолосого человека с двумя мечами. Время ее почитать есть только ночью; Читать книгу?", "+", "30"},
            {"Дочь хозяина, Реджина, пришла в конюшню, чтобы остаться на ночть с вами; Остаться с ней?", "+", "50"},
            {"У хозяина отличное настроение, он разрешает переночевать у него; Принять его предложение?", "+", "50"}
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
    public SelectHappiness linkOnSelectHappiness;
    public ShopOfHappiness linkOnShopOfHappiness;

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

        hittingInChance = false;

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

        int randomValue = randomVariable.Next(0, 100);

        //Появление случайного события с нужным для профессии текстом
        if (randomValue < chanceOfRandomEvent) {

            hittingInChance = true;
            int differenceInLevels;
            
            //Проходим массив случайных событий
            for (int i = 1; i <= arrayOfRandomEvents.GetLength(0); i++) {

                //Проходим массив кнопок в магазине
                for (int m = 0; m < linkOnSelectHappiness.buttonsInShop.Length; m++) {

                    if (linkOnSelectHappiness.textOfButtonsInShop[m].text == "Выбрано") {

                        //Используем нужные случайные события
                        for (int j = 1; j <= arrayOfRandomEvents.GetLength(1); j++) {

                            for (int k = 1; k <= arrayOfRandomEvents.GetLength(2); k++) {

                                differenceInLevels = Convert.ToInt32(userLevel.text) - linkOnShopOfHappiness.neededLVLArray[m] + 1;

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
                for (int m = 0; m < linkOnSelectHappiness.buttonsInShop.Length; m++)
                {

                    if (linkOnSelectHappiness.textOfButtonsInShop[m].text == "Выбрано")
                    {

                        //Используем нужные случайные события
                        for (int j = 1; j <= arrayOfRandomAdvertisingEvents.GetLength(1); j++)
                        {

                            for (int k = 1; k <= arrayOfRandomAdvertisingEvents.GetLength(2); k++)
                            {

                                differenceInLevels = Convert.ToInt32(userLevel.text) - linkOnShopOfHappiness.neededLVLArray[m] + 1;

                                int randomAdvertisingEvent = randomVariable.Next(0, 4);
                                randomAdvertisingEventText.text = arrayOfRandomAdvertisingEvents[m, randomAdvertisingEvent, 0];

                                int randomHealth = randomVariable.Next(0, Convert.ToInt32(arrayOfRandomAdvertisingEvents[m, randomAdvertisingEvent, 2])) * differenceInLevels;
                                int randomEat = randomVariable.Next(0, Convert.ToInt32(arrayOfRandomAdvertisingEvents[m, randomAdvertisingEvent, 2])) * differenceInLevels;
                                int randomHappy = randomVariable.Next(0, Convert.ToInt32(arrayOfRandomAdvertisingEvents[m, randomAdvertisingEvent, 2])) * differenceInLevels;

                                if (arrayOfRandomEvents[m, randomAdvertisingEvent, 1] == "+")
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