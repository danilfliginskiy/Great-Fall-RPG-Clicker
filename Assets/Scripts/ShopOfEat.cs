using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopOfEat : MonoBehaviour {

    public SelectFood linkOnSelectFood;
    public ShopOfWork linkOnShopOfWork;
    public ShopOfHappiness linkOnShopOfHappiness;
    public ShopOfDepression linkOnShopOfDepression;
    public ShopOfDonate linkOnShopOfDonate;

    public bool CheckButtonOfEatPanel = true;
    public int[] neededLVLArray = new int[] {};

    public GameObject ShopOfWorkPanel;
    public GameObject ShopOfEatPanel;
    public GameObject ShopOfHappinessPanel;
    public GameObject ShopOfDepressionPanel;
    public GameObject ShopOfDonatePanel;
    public Text amountOfMoneyInShop;
    public GameObject mainCamera;
    
    public void OnClickShopOfEatButton() {

        if(CheckButtonOfEatPanel == true) {
            ShopOfEatPanel.SetActive(true);
            ShopOfWorkPanel.SetActive(false);
            ShopOfHappinessPanel.SetActive(false);
            ShopOfDepressionPanel.SetActive(false);
            ShopOfDonatePanel.SetActive(false);
            linkOnShopOfWork.CheckButtonOfWorkPanel = true;
            linkOnShopOfHappiness.CheckButtonOfHappinessPanel = true;
            linkOnShopOfDepression.CheckButtonOfDepressionPanel = true;
            linkOnShopOfDonate.CheckButtonOfDonatePanel = true;
            CheckButtonOfEatPanel = false;
        } else {
            ShopOfEatPanel.SetActive(false);
            CheckButtonOfEatPanel = true;
        }

        amountOfMoneyInShop.text = mainCamera.GetComponent<WorkButton>().amountOfMoney.ToString();

        for (int i = 0; i < linkOnSelectFood.buttonsInShop.Length; i++) { //Делаем недоступными кнопки, которые выше уровня игрока

            if (linkOnSelectFood.textOfButtonsInShop[i].text == "Выбрано") {

                linkOnSelectFood.textOfButtonsInShop[i].text = "Выбрано";
                linkOnSelectFood.buttonsInShop[i].interactable = false;

            } else if (Convert.ToInt32(linkOnSelectFood.usersLVL.text) >= neededLVLArray[i]) {

                linkOnSelectFood.textOfButtonsInShop[i].text = "Выбрать";
                linkOnSelectFood.buttonsInShop[i].interactable = true;

            }

        }

    }

}