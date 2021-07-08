using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectProfession : MonoBehaviour {

    //Новые значения для добаляемых/отнимаемых харакетристик
    public Text newTakeAwayHealth;
    public Text newTakeAwayEat;
    public Text newTakeAwayHappiness;

    //Массив всех кнопок в магазине
    public Button[] buttonsInShop = new Button[] {};
    public Text[] textOfButtonsInShop = new Text[] {};
    public int indexOfButton; //Индекс нажимаемой кнопки
    
    public GameObject mainCamera; //Ссылка на камеру, внутри которой лежит нужный скрипт
    public Text salaryText; //Зарплата за использование работы
    public Text neededLVL; //Нужный для улучшения уровень
    public Text usersLVL; //Уровень игрока

    public void ButtonClick() {

        if (Convert.ToInt32(usersLVL.text) >= Convert.ToInt32(neededLVL.text)) {

            mainCamera.GetComponent<WorkButton>().moneyMultiplier = Convert.ToInt32(salaryText.text); //Зарплата увеличивается

            //Меняются добавляемые/отнимаемые характеристики
            mainCamera.GetComponent<WorkButton>().takeAwayHealth = Convert.ToInt32(newTakeAwayHealth.text);
            mainCamera.GetComponent<WorkButton>().takeAwayEat = Convert.ToInt32(newTakeAwayEat.text);
            mainCamera.GetComponent<WorkButton>().takeAwayHappiness = Convert.ToInt32(newTakeAwayHappiness.text);

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