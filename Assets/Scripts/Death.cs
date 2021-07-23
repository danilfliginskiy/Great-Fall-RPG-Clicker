using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{

    //Ссылки на другие скрипты
    public WorkButton linkOnWorkButton;
    public EatButton linkOnEatButton;
    public HappinessButton linkOnHappinessButton;
    public DepressionButton linkOnDepressionButton;
    //------------------
    public ShopOfWork linkOnShopOfWork;
    public ShopOfEat linkOnShopOfEat;
    public ShopOfHappiness linkOnShopOfHappiness;
    public ShopOfDonate linkOnShopOfDonate;
    public ShopOfDepression linkOnShopOfDepression;
    //------------------
    public ChangeData linkOnChangeData;
    public AddExperience linkOnAddExperience;
    //------------------
    public SelectProfession linkOnSelectProfession;
    public SelectFood linkOnSelectFood;
    public SelectHappiness linkOnSelectHappiness;
    public SelectDepression linkOnSelectDepression;
    //------------------
    public Energy linkOnEnergy;

    public Text lvl;
    public Text levelProgress;
    public Text days;
    public Text hours;
    public Text money;

    public GameObject DeathPanel;
    public GameObject RefinementPanel;

    public GameObject WorkPanel;
    public GameObject EatPanel;
    public GameObject HappinessPanel;
    public GameObject DepressionPanel;
    public GameObject DonatePanel;

    public Slider progressBar;

    public Slider healthBar;
    public Slider hungerBar;
    public Slider happinessBar;
    public Slider depressionBar;

    public void RefinementButton() //Вызывает панель уточнения
    {
        DeathPanel.SetActive(false);
        RefinementPanel.SetActive(true);
        WorkPanel.SetActive(false);
        linkOnShopOfWork.CheckButtonOfWorkPanel = true;
        EatPanel.SetActive(false);
        linkOnShopOfEat.CheckButtonOfEatPanel = true;
        HappinessPanel.SetActive(false);
        linkOnShopOfHappiness.CheckButtonOfHappinessPanel = true;
        DepressionPanel.SetActive(false);
        linkOnShopOfDepression.CheckButtonOfDepressionPanel = true;
        DonatePanel.SetActive(false);
        linkOnShopOfDonate.CheckButtonOfDonatePanel = true;
    }

    public void NoButton() //Возвращает к панели смерти
    {
        RefinementPanel.SetActive(false);
        DeathPanel.SetActive(true);
    }


    public void AcceptButton() //Подтверждает выбор смерти
    {

        //Обнуление опыта
        progressBar.value = 0;
        lvl.text = "1";
        levelProgress.text = "0/20 XP";
        linkOnAddExperience.level = 1;
        linkOnAddExperience.index = 0;
        progressBar.maxValue = linkOnAddExperience.amountOfProgress[0];
        linkOnAddExperience.addedProgress = 1;

        //Пополнение характеристик
        depressionBar.value = 0;
        healthBar.value = 100;
        hungerBar.value = 100;
        happinessBar.value = 100;
        //---
        healthBar.maxValue = 100;
        hungerBar.maxValue = 100;
        happinessBar.maxValue = 100;
        depressionBar.maxValue = 100;
        //---
        money.text = "0";
        linkOnWorkButton.amountOfMoney = 0;
        
        //Сброс магазина профессий
        for (int i = 1; i < linkOnSelectProfession.buttonsInShop.Length; i++) {
            linkOnSelectProfession.textOfButtonsInShop[i].text = "Недоступно";
            linkOnSelectProfession.buttonsInShop[i].interactable = false;
        }
        linkOnSelectProfession.textOfButtonsInShop[0].text = "Выбрано";
        linkOnSelectProfession.buttonsInShop[0].interactable = false;
        linkOnWorkButton.moneyMultiplier = 1;
        linkOnWorkButton.takeAwayHealth = -10;
        linkOnWorkButton.takeAwayEat = -10;
        linkOnWorkButton.takeAwayHappiness = -10;
        linkOnWorkButton.addDepression = 10;

        //Сброс магазина еды
        for (int i = 1; i < linkOnSelectFood.buttonsInShop.Length; i++) {
            linkOnSelectFood.textOfButtonsInShop[i].text = "Недоступно";
            linkOnSelectFood.buttonsInShop[i].interactable = false;
        }
        linkOnSelectFood.textOfButtonsInShop[0].text = "Выбрано";
        linkOnSelectFood.buttonsInShop[0].interactable = false;
        linkOnEatButton.foodPrice = 0;
        linkOnEatButton.addedHealth = 10;
        linkOnEatButton.addedEat = 25;
        linkOnEatButton.takeAwayHappiness = -5;

        //Сброс магазина счастья
        for (int i = 1; i < linkOnSelectHappiness.buttonsInShop.Length; i++) {
            linkOnSelectHappiness.textOfButtonsInShop[i].text = "Недоступно";
            linkOnSelectHappiness.buttonsInShop[i].interactable = false;
        }
        linkOnSelectHappiness.textOfButtonsInShop[0].text = "Выбрано";
        linkOnSelectHappiness.buttonsInShop[0].interactable = false;
        linkOnHappinessButton.holidayPrice = 0;
        linkOnHappinessButton.addedHealth = 10;
        linkOnHappinessButton.takeAwayEat = 2;
        linkOnHappinessButton.addedHappiness = 10;

        //Сброс магазина счастья
        for (int i = 1; i < linkOnSelectHappiness.buttonsInShop.Length; i++) {
            linkOnSelectHappiness.textOfButtonsInShop[i].text = "Недоступно";
            linkOnSelectHappiness.buttonsInShop[i].interactable = false;
        }
        linkOnSelectHappiness.textOfButtonsInShop[0].text = "Выбрано";
        linkOnSelectHappiness.buttonsInShop[0].interactable = false;
        linkOnHappinessButton.holidayPrice = 0;
        linkOnHappinessButton.addedHealth = 10;
        linkOnHappinessButton.takeAwayEat = 2;
        linkOnHappinessButton.addedHappiness = 10;

        //Сброс магазина депрессии
        for (int i = 1; i < linkOnSelectDepression.buttonsInShop.Length; i++) {
            linkOnSelectDepression.textOfButtonsInShop[i].text = "Недоступно";
            linkOnSelectDepression.buttonsInShop[i].interactable = false;
        }
        linkOnSelectDepression.textOfButtonsInShop[0].text = "Выбрать";
        linkOnSelectDepression.buttonsInShop[0].interactable = false;
        
        //Обнуление времени
        days.text = "Дней: 0";
        hours.text = "Часов: 0";
        linkOnChangeData.amountOfDays = 0;
        linkOnChangeData.amountOfHours = 0;

        //Восполнение энергии
        linkOnEnergy.energy = 300;
        linkOnEnergy.energyText.text = linkOnEnergy.energy.ToString() + "/300";

        //Отключение магазинов
        RefinementPanel.SetActive(false);
        DeathPanel.SetActive(false);

    }
}
