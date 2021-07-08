using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyDonate : MonoBehaviour {

    //Ссылка на другой скрипт
    public WorkButton linkOnWorkButton;

    //Обозначение всех кнопок в продукции
    public Button[] buttonsInShop = new Button[] {};
    public Text[] textOfButtonsInShop = new Text[] {};

    //Индекс кнопки на которую нажмут
    public int indexOfButton;

    public void ButtonClick() {

        //Если донат куплен, то включаются нужные улучшения
        if (indexOfButton == 2) {
            linkOnWorkButton.checkingThePurchasedDoubleSalary = true;
        } else if (indexOfButton == 3) {
            linkOnWorkButton.checkingThePurchasedDoubleStrength = true;
        }

        //Обозначение покупки
        textOfButtonsInShop[indexOfButton].text = "Куплено"; //Убираем активность нажатой кнопки
        buttonsInShop[indexOfButton].interactable = false;

    }

}
