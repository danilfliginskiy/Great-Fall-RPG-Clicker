using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectHappiness : MonoBehaviour {

    //Новые значения для добаляемых/отнимаемых харакетристик
    public Text newAddedHealth;
    public Text newTakeAwayEat;
    public Text newAddedHappiness;

    //Массив всех кнопок в магазине
    public Button[] buttonsInShop = new Button[] {};
    public Text[] textOfButtonsInShop = new Text[] {};
    public int indexOfButton; //Индекс нажимаемой кнопки
    
    public GameObject mainCamera; //Ссылка на камеру, внутри которой лежит нужный скрипт
    public Text priceText; //Цена за использование отдыха
    public Text neededLVL; //Нужный для улучшения уровень
    public Text usersLVL; //Уровень игрока

    public void ButtonClick() {

        if (Convert.ToInt32(usersLVL.text) >= Convert.ToInt32(neededLVL.text)) {

            mainCamera.GetComponent<HappinessButton>().holidayPrice = Convert.ToInt32(priceText.text); //Цена увеличивается

            //Меняются добавляемые/отнимаемые характеристики
            mainCamera.GetComponent<HappinessButton>().addedHealth = Convert.ToInt32(newAddedHealth.text);
            mainCamera.GetComponent<HappinessButton>().takeAwayEat = Convert.ToInt32(newTakeAwayEat.text);
            mainCamera.GetComponent<HappinessButton>().addedHappiness = Convert.ToInt32(newAddedHappiness.text);

            for (int i = 0; i < buttonsInShop.Length; i++) { //Ставим активность у всех кнопок, кроме недоступных

                if (textOfButtonsInShop[i].text == "Недоступно") {

                    textOfButtonsInShop[i].text = "Недоступно";
                    buttonsInShop[i].interactable = false;

                } else {

                    textOfButtonsInShop[i].text = "Выбрать";
                    buttonsInShop[i].interactable = true;

                }

            }

            textOfButtonsInShop[indexOfButton].text = "Выбрано"; //Убираем активность нажатой кнопки
            buttonsInShop[indexOfButton].interactable = false;

        }

    }

}