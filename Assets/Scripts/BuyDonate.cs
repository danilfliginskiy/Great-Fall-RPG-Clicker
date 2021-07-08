using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyDonate : MonoBehaviour {

    public WorkButton linkOnWorkButton;

    public Button[] buttonsInShop = new Button[] {};
    public Text[] textOfButtonsInShop = new Text[] {};
    public int indexOfButton;
    
    public GameObject mainCamera;

    public void ButtonClick() {

        if (indexOfButton == 2) {
            linkOnWorkButton.checkingThePurchasedDoubleSalary = true;
        } else if (indexOfButton == 3) {
            linkOnWorkButton.checkingThePurchasedDoubleStrength = true;
        }

        textOfButtonsInShop[indexOfButton].text = "Куплено"; //Убираем активность нажатой кнопки
        buttonsInShop[indexOfButton].interactable = false;

    }

}
