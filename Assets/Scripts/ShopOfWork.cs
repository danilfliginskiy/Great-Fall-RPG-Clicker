using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopOfWork : MonoBehaviour {

    public SelectProfession linkOnSelectProfession;
    public ShopOfEat linkOnShopOfEat;
    public ShopOfHappiness linkOnShopOfHappiness;
    public ShopOfDepression linkOnShopOfDepression;
    public ShopOfDonate linkOnShopOfDonate;

    public bool CheckButtonOfWorkPanel = true;
    public int[] neededLVLArray = new int[] {};

    public GameObject ShopOfWorkPanel;
    public GameObject ShopOfEatPanel;
    public GameObject ShopOfHappinessPanel;
    public GameObject ShopOfDepressionPanel;
    public GameObject ShopOfDonatePanel;
    public Text amountOfMoneyInShop;
    public GameObject mainCamera;
    
    public void OnClickShopOfWorkButton() {

        if(CheckButtonOfWorkPanel == true) {
            ShopOfWorkPanel.SetActive(true);
            ShopOfEatPanel.SetActive(false);
            ShopOfHappinessPanel.SetActive(false);
            ShopOfDepressionPanel.SetActive(false);
            ShopOfDonatePanel.SetActive(false);
            linkOnShopOfEat.CheckButtonOfEatPanel = true;
            linkOnShopOfHappiness.CheckButtonOfHappinessPanel = true;
            linkOnShopOfDepression.CheckButtonOfDepressionPanel = true;
            linkOnShopOfDonate.CheckButtonOfDonatePanel = true;
            CheckButtonOfWorkPanel = false;
        } else {
            ShopOfWorkPanel.SetActive(false);
            CheckButtonOfWorkPanel = true;
        }

        amountOfMoneyInShop.text = mainCamera.GetComponent<WorkButton>().amountOfMoney.ToString();

        for (int i = 0; i < linkOnSelectProfession.buttonsInShop.Length; i++) { //Делаем недоступными кнопки, которые выше уровня игрока

            if (linkOnSelectProfession.textOfButtonsInShop[i].text == "Выбрано") {

                linkOnSelectProfession.textOfButtonsInShop[i].text = "Выбрано";
                linkOnSelectProfession.buttonsInShop[i].interactable = false;

            } else if (Convert.ToInt32(linkOnSelectProfession.usersLVL.text) >= neededLVLArray[i]) {

                linkOnSelectProfession.textOfButtonsInShop[i].text = "Выбрать";
                linkOnSelectProfession.buttonsInShop[i].interactable = true;

            }

        }

    }

}