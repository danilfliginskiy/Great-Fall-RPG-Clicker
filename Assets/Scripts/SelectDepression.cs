using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectDepression : MonoBehaviour {

    int chanceOfRandomEvent = 20; // 20% возникновения события
    System.Random randomVariable = new System.Random();

    //Массив случайных событий на работе
    public string[,,] arrayOfRandomEvents = { //i

        { //j Означает номер уровня
            //k Означает событие и отнимаемые харакетристики
            {"Ваша теория расположения звезд понравилась не всем", "-", "20"},
            {"Люди больше хотели обсуждать футбол", "-", "30"},
            {"Вы нашли тех, кому тема звезд интересна", "+", "20"}
        },

        { //j
            //k Означает событие и отнимаемые харакетристики
            {"Не все любят анектоды", "-", "25"},
            {"Вы оскорбили чуства меньшинств", "-", "15"},
            {"Получилось рассмешить большое кол-во людей", "+", "30"}
        }

    };

    //Ссылки на элементы для случайных событий
    public GameObject randomEventBG;
    public Text randomEventText;
    public Text userLevel;

    public bool hittingInChance;

    //Ссылки на другие скрипты
    public ShopOfDepression linkOnShopOfDepression;

    public WorkButton linkOnWorkButton; //Ссылка на другой скрипт

    //Слайдеры
    public Slider healthBar;
    public Slider hungerBar;
    public Slider happinessBar;
    
    //Массив всех кнопок в магазине
    public Button[] buttonsInShop = new Button[] {};
    public Text[] textOfButtonsInShop = new Text[] {};
    public int indexOfButton; //Индекс нажимаемой кнопки

    public Text neededLVL; //Нужный для улучшения уровень
    public Text usersLVL; //Уровень игрока

    public void ButtonClick() {

        hittingInChance = false;

        if (Convert.ToInt32(usersLVL.text) >= Convert.ToInt32(neededLVL.text)) {


            for (int i = 0; i < buttonsInShop.Length; i++) { //Ставим активность у всех кнопок, кроме недоступных

                if (textOfButtonsInShop[i].text == "Недоступно") {

                    textOfButtonsInShop[i].text = "Недоступно";
                    buttonsInShop[i].interactable = false;

                } else {

                    textOfButtonsInShop[i].text = "Выбрать";
                    buttonsInShop[i].interactable = true;

                }

            }

            int randomValue = randomVariable.Next(0, 100);

            //Появление случайного события с нужным для профессии текстом
            if (randomValue < chanceOfRandomEvent) {

                hittingInChance = true;
                
                //Проходим массив случайных событий
                for (int i = 1; i <= arrayOfRandomEvents.GetLength(0); i++) {

                    //Используем нужные случайные события
                    for (int j = 1; j <= arrayOfRandomEvents.GetLength(1); j++) {

                        for (int k = 1; k <= arrayOfRandomEvents.GetLength(2); k++) {

                            int randomEvent = randomVariable.Next(0, 2);
                            Debug.Log(randomEvent);
                            randomEventText.text = arrayOfRandomEvents[indexOfButton, randomEvent, 0];

                            int randomHealth = randomVariable.Next(0, Convert.ToInt32(arrayOfRandomEvents[indexOfButton, randomEvent, 2]));
                            int randomEat = randomVariable.Next(0, Convert.ToInt32(arrayOfRandomEvents[indexOfButton, randomEvent, 2]));
                            int randomHappy = randomVariable.Next(0, Convert.ToInt32(arrayOfRandomEvents[indexOfButton, randomEvent, 2]));

                            if (arrayOfRandomEvents[indexOfButton, randomEvent, 1] == "+") {

                                healthBar.value += randomHealth;
                                hungerBar.value += randomEat;
                                happinessBar.value += randomHappy;

                            } else {

                                healthBar.value -= randomHealth;
                                hungerBar.value -= randomEat;
                                happinessBar.value -= randomHappy;

                            }

                            linkOnWorkButton.health.text = arrayOfRandomEvents[indexOfButton, randomEvent, 1] + randomHealth.ToString();
                            linkOnWorkButton.eat.text = arrayOfRandomEvents[indexOfButton, randomEvent, 1] + randomEat.ToString();
                            linkOnWorkButton.happy.text = arrayOfRandomEvents[indexOfButton, randomEvent, 1] + randomHappy.ToString();

                            break;

                        }

                        break;

                    }

                    break;

                }

                randomEventBG.SetActive(true);

            }


        }

    }

}
