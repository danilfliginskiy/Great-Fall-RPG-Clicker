using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopOfDepression : MonoBehaviour {
    
    //Ссылка на скрипт с выбором услуги
    public SelectDepression linkOnSelectDepression;

    public bool CheckButtonOfDepressionPanel = true;
    public int[] neededLVLArray = new int[] {};

    public GameObject ShopOfDepressionPanel; //Ссылка на данный магазин
    
    public void OnClickShopOfDepressionButton() {

        //Открытие магазина
        if(CheckButtonOfDepressionPanel == true) {
            ShopOfDepressionPanel.SetActive(true);
            CheckButtonOfDepressionPanel = false;
        } else {
            ShopOfDepressionPanel.SetActive(false);
            CheckButtonOfDepressionPanel = true;
        }

        for (int i = 0; i < linkOnSelectDepression.buttonsInShop.Length; i++) { //Делаем недоступными кнопки, которые выше уровня игрока

            if (linkOnSelectDepression.textOfButtonsInShop[i].text == "Выбрано") {

                linkOnSelectDepression.textOfButtonsInShop[i].text = "Выбрано";
                linkOnSelectDepression.buttonsInShop[i].interactable = false;

            } else if (Convert.ToInt32(linkOnSelectDepression.usersLVL.text) >= neededLVLArray[i]) {

                linkOnSelectDepression.textOfButtonsInShop[i].text = "Использовать";
                linkOnSelectDepression.buttonsInShop[i].interactable = true;

            }

        }

    }

}
