using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectFood : MonoBehaviour {

    //Новые значения для добаляемых/отнимаемых харакетристик
    public Text newAddedHealth;
    public Text newAddedEat;
    public Text newTakeAwayHappiness;

    //Массив всех кнопок в магазине
    public Button[] buttonsInShop = new Button[] {};
    public Text[] textOfButtonsInShop = new Text[] {};
    public int indexOfButton; //Индекс нажимаемой кнопки
    
    public GameObject mainCamera; //Ссылка на камеру, внутри которой лежит нужный скрипт
    public Text priceText; //Цена за использование еды
    public Text neededLVL; //Нужный для улучшения уровень
    public Text usersLVL; //Уровень игрока

    public void ButtonClick() {

        if (Convert.ToInt32(usersLVL.text) >= Convert.ToInt32(neededLVL.text)) {

            mainCamera.GetComponent<EatButton>().foodPrice = Convert.ToInt32(priceText.text); //Цена увеличивается

            //Меняются добавляемые/отнимаемые характеристики
            mainCamera.GetComponent<EatButton>().addedHealth = Convert.ToInt32(newAddedHealth.text);
            mainCamera.GetComponent<EatButton>().addedEat = Convert.ToInt32(newAddedEat.text);
            mainCamera.GetComponent<EatButton>().takeAwayHappiness = Convert.ToInt32(newTakeAwayHappiness.text);

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