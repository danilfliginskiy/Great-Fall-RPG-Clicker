using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatButton : MonoBehaviour {

    // int chanceOfRandomEvent = 5; // 5% возникновения события
    // System.Random randomVariable = new System.Random();

    // //Массив случайных событий на работе
    // public string[,,] arrayOfRandomEvents = { //i

    //     { //j Означает номер уровня
    //         //k Означает событие и отнимаемые харакетристики
    //         {"Еда оказалась просрочена", "-20", "-20", "-10", "0"},
    //         {"Собаки отобрали еду", "0", "-10", "-10", "+40"},
    //         {"Прохожий дал еды", "0", "-10", "-20", "-30"},
    //         {"Печенье на дороге было только из печи", "-40", "-10", "-20", "-10"},
    //         {"Кто-то забыл еду на лавочке", "0", "0", "+10", "-10"}
    //     },

    //     { //j
    //         //k Означает событие и отнимаемые харакетристики
    //         {"Паек оказался просроченным", "-10", "-10", "-20", "+20"},
    //         {"Хлеб в пайке был черствый", "0", "0", "+10", "-50"},
    //         {"Кто-то стянул твою еду с лавочки", "0", "0", "+10", "-50"},
    //         {"Кто-то случайно положил две порции в паек", "-10", "-10", "-20", "+20"},
    //         {"Увидеть яблоко в обеде было очень приятно", "-40", "-10", "-20", "0"}
    //     },

    //     { //j
    //         //k Означает событие и отнимаемые харакетристики
    //         {"Барин опять дал несвежую еду", "-10", "-20", "-20", "+20"},
    //         {"Лишили обеда за провинность", "0", "0", "-10", "+20"},
    //         {"Лошадь украла овощи и фрукты с обеда", "-10", "-10", "-20", "+20"},
    //         {"Хозяин угостил вином", "0", "0", "+20", "-30"},
    //         {"Угостили пирогом", "-30", "-20", "-20", "+50"}
    //     }

    // };

    // //Ссылки на элементы для случайных событий
    // public GameObject randomEventBG;
    // public Text randomEventText;
    // public Text userLevel;

    // public bool hittingInChance;

    //Ссылки на другие скрипты
    public SelectProfession linkOnSelectProfession;
    public ShopOfWork linkOnShopOfWork;

    public WorkButton linkOnWorkButton; //Ссылка на другой скрипт

    public int foodPrice = 0; //Цена на еду
    public int addedHealth = 10; //Добавляемое здоровье
    public int addedEat = 25; //Добавляемая еда
    public int takeAwayHappiness = -5; //Отнимаемое счастье

    //Ссылка на слайдеры
    public Slider healthBar;
    public Slider hungerBar;
    public Slider happinessBar;

    public void ButtonClick() {

        //hittingInChance = false;

        //Отнимаем деньги за еду
        linkOnWorkButton.amountOfMoney -= foodPrice;

        //Добавляем характеристики
        healthBar.value += addedHealth;
        hungerBar.value += addedEat;

        //Если куплен донат, то активируем улучшения
        if (linkOnWorkButton.checkingThePurchasedDoubleStrength == false) {
            happinessBar.value -= takeAwayHappiness;
        } else {
            happinessBar.value -= (takeAwayHappiness / 2);
        }

        //Изменяем моенты в UI
        linkOnWorkButton.amountOfMoneyText.text = linkOnWorkButton.amountOfMoney.ToString();

    //     int randomValue = randomVariable.Next(0, 100);

    //     //Появление случайного события с нужным для профессии текстом
    //     if (randomValue < chanceOfRandomEvent) {

    //         hittingInChance = true;
            
    //         //Проходим массив случайных событий
    //         for (int i = 1; i <= arrayOfRandomEvents.GetLength(0); i++) {

    //             //Проходим массив кнопок в магазине
    //             for (int m = 0; m < linkOnSelectProfession.buttonsInShop.Length; m++) {

    //                 if (linkOnSelectProfession.textOfButtonsInShop[m].text == "Выбрано") {

    //                     //Используем нужные случайные события
    //                     for (int j = 1; j <= arrayOfRandomEvents.GetLength(1); j++) {

    //                         for (int k = 1; k <= arrayOfRandomEvents.GetLength(2); k++) {

    //                             int randomEvent = randomVariable.Next(0, 4);
    //                             randomEventText.text = arrayOfRandomEvents[m, randomEvent, 0];
    //                             healthBar.value += Convert.ToInt32(arrayOfRandomEvents[m, randomEvent, 1]);
    //                             hungerBar.value += Convert.ToInt32(arrayOfRandomEvents[m, randomEvent, 2]);
    //                             happinessBar.value += Convert.ToInt32(arrayOfRandomEvents[m, randomEvent, 3]);
    //                             depressionBar.value += Convert.ToInt32(arrayOfRandomEvents[m, randomEvent, 4]);

    //                             break;

    //                         }

    //                         break;

    //                     }

    //                 }

    //                 break;

    //             }

    //         }

    //         randomEventBG.SetActive(true);

    //     }

    }

}