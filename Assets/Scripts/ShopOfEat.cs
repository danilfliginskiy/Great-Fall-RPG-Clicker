using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopOfEat : MonoBehaviour {

    //Ссылка на скрипт с выбором услуги
    public SelectFood linkOnSelectFood;

    //Ссылки на другие скрипты с магазинами, чтобы менять там переменную типа bool
    public ShopOfWork linkOnShopOfWork;
    public ShopOfHappiness linkOnShopOfHappiness;
    public ShopOfDepression linkOnShopOfDepression;
    public ShopOfDonate linkOnShopOfDonate;

    public bool CheckButtonOfEatPanel = true; //Проверка активности магазина
    public int[] neededLVLArray = new int[] {}; //Массив нужных уровней для отображения недоступных кнопок и доступных

    //Ссылки на другие магазины (объекты "Panel"), чтобы закрывать их
    public GameObject ShopOfWorkPanel;
    public GameObject ShopOfEatPanel;
    public GameObject ShopOfHappinessPanel;
    public GameObject ShopOfDepressionPanel;
    public GameObject ShopOfDonatePanel;

    public Text amountOfMoneyInShop; //Кол-во монет в магазине
    public GameObject mainCamera; //Ссылка на камеру, в которой лежит нужный скрипт
    
    public void OnClickShopOfEatButton() {

        //Закрытие всех других магазинов при открытии нужного
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

        //Монеты в магазине равны монетом в главном окне
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