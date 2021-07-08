using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopOfDonate : MonoBehaviour {

    //Ссылки на другие скрипты с магазинами, чтобы менять там переменную типа bool
    public ShopOfWork linkOnShopOfWork;
    public ShopOfEat linkOnShopOfEat;
    public ShopOfHappiness linkOnShopOfHappiness;
    public ShopOfDepression linkOnShopOfDepression;

    public bool CheckButtonOfDonatePanel = true; //Проверка активности магазина

    //Ссылки на другие магазины (объекты "Panel"), чтобы закрывать их
    public GameObject ShopOfWorkPanel;
    public GameObject ShopOfEatPanel;
    public GameObject ShopOfHappinessPanel;
    public GameObject ShopOfDepressionPanel;
    public GameObject ShopOfDonatePanel;
    
    public void OnClickShopOfDonateButton() {

        //Закрытие всех других магазинов при открытии нужного
        if(CheckButtonOfDonatePanel == true) {
            ShopOfDonatePanel.SetActive(true);
            ShopOfWorkPanel.SetActive(false);
            ShopOfEatPanel.SetActive(false);
            ShopOfHappinessPanel.SetActive(false);
            ShopOfDepressionPanel.SetActive(false);
            linkOnShopOfWork.CheckButtonOfWorkPanel = true;
            linkOnShopOfEat.CheckButtonOfEatPanel = true;
            linkOnShopOfHappiness.CheckButtonOfHappinessPanel = true;
            linkOnShopOfDepression.CheckButtonOfDepressionPanel = true;
            CheckButtonOfDonatePanel = false;
        } else {
            ShopOfDonatePanel.SetActive(false);
            CheckButtonOfDonatePanel = true;
        }

    }

}
