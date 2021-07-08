using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectHappiness : MonoBehaviour {

    public Button[] buttonsInShop = new Button[] {};
    public Text[] textOfButtonsInShop = new Text[] {};
    public int indexOfButton;
    
    public GameObject mainCamera;
    public Text priceText;
    public Text neededLVL;
    public Text usersLVL;

    public void ButtonClick() {

        if (Convert.ToInt32(usersLVL.text) >= Convert.ToInt32(neededLVL.text)) {

            mainCamera.GetComponent<HappinessButton>().holidayPrice = Convert.ToInt32(priceText.text); //Цена увеличивается

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