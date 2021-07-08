using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopOfHappiness : MonoBehaviour {

    public SelectHappiness linkOnSelectHappiness;
    public ShopOfWork linkOnShopOfWork;
    public ShopOfEat linkOnShopOfEat;
    public ShopOfDepression linkOnShopOfDepression;
    public ShopOfDonate linkOnShopOfDonate;

    public bool CheckButtonOfHappinessPanel = true;
    public int[] neededLVLArray = new int[] {};

    public GameObject ShopOfWorkPanel;
    public GameObject ShopOfEatPanel;
    public GameObject ShopOfHappinessPanel;
    public GameObject ShopOfDepressionPanel;
    public GameObject ShopOfDonatePanel;
    public Text amountOfMoneyInShop;
    public GameObject mainCamera;
    
    public void OnClickShopOfHappinessButton() {

        if(CheckButtonOfHappinessPanel == true) {
            ShopOfHappinessPanel.SetActive(true);
            ShopOfWorkPanel.SetActive(false);
            ShopOfEatPanel.SetActive(false);
            ShopOfDepressionPanel.SetActive(false);
            ShopOfDonatePanel.SetActive(false);
            linkOnShopOfWork.CheckButtonOfWorkPanel = true;
            linkOnShopOfEat.CheckButtonOfEatPanel = true;
            linkOnShopOfDepression.CheckButtonOfDepressionPanel = true;
            linkOnShopOfDonate.CheckButtonOfDonatePanel = true;
            CheckButtonOfHappinessPanel = false;
        } else {
            ShopOfHappinessPanel.SetActive(false);
            CheckButtonOfHappinessPanel = true;
        }

        amountOfMoneyInShop.text = mainCamera.GetComponent<WorkButton>().amountOfMoney.ToString();

        for (int i = 0; i < linkOnSelectHappiness.buttonsInShop.Length; i++) { //Делаем недоступными кнопки, которые выше уровня игрока

            if (linkOnSelectHappiness.textOfButtonsInShop[i].text == "Выбрано") {

                linkOnSelectHappiness.textOfButtonsInShop[i].text = "Выбрано";
                linkOnSelectHappiness.buttonsInShop[i].interactable = false;

            } else if (Convert.ToInt32(linkOnSelectHappiness.usersLVL.text) >= neededLVLArray[i]) {

                linkOnSelectHappiness.textOfButtonsInShop[i].text = "Выбрать";
                linkOnSelectHappiness.buttonsInShop[i].interactable = true;

            }

        }

    }

}