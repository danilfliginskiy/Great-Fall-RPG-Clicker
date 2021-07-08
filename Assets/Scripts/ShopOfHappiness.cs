using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopOfHappiness : MonoBehaviour {

    //Ссылка на скрипт с выбором услуги
    public SelectHappiness linkOnSelectHappiness;

    //Ссылки на другие скрипты с магазинами, чтобы менять там переменную типа bool
    public ShopOfWork linkOnShopOfWork;
    public ShopOfEat linkOnShopOfEat;
    public ShopOfDepression linkOnShopOfDepression;
    public ShopOfDonate linkOnShopOfDonate;

    public bool CheckButtonOfHappinessPanel = true; //Проверка активности магазина
    public int[] neededLVLArray = new int[] {}; //Массив нужных уровней для отображения недоступных кнопок и доступных

    //Ссылки на другие магазины (объекты "Panel"), чтобы закрывать их
    public GameObject ShopOfWorkPanel;
    public GameObject ShopOfEatPanel;
    public GameObject ShopOfHappinessPanel;
    public GameObject ShopOfDepressionPanel;
    public GameObject ShopOfDonatePanel;

    public Text amountOfMoneyInShop; //Кол-во монет в магазине
    public GameObject mainCamera; //Ссылка на камеру, в которой лежит нужный скрипт
    
    public void OnClickShopOfHappinessButton() {

        //Закрытие всех других магазинов при открытии нужного
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

        //Монеты в магазине равны монетом в главном окне
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