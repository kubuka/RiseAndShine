using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    //cel : uzbieraj tyle kasy zeby miec duzo wojska i wyruszaj na walke
    public int coins; //do kupowania ludzi
    public int wood;  //do ulepszania budynkow
    public int bread; // do sprzedawania dla merchanta
    public int berries; //do sprzedawania dla merchanta;
    public int army;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI breadText;
    public TextMeshProUGUI berriesText;
    public TextMeshProUGUI armyText;

    public void AddCoins(int amount)
    {
        coins += amount;
        coinText.text = coins.ToString();
    }
    public void AddWood(int amount)
    {
        wood += amount;
        woodText.text = wood.ToString();
    }
    public void AddBread(int amount)
    {
        bread += amount;
        breadText.text = bread.ToString();
    }
    public void AddBerries  (int amount)
    {
        berries += amount;
        berriesText.text = berries.ToString();
    }

    public void AddArmy(int amount)
    {
        army += amount;
        armyText.text = army.ToString();
    }
}
