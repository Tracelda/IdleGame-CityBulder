﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScrpt : MonoBehaviour {

    // Scripts
    public InfoStatic InfoStatic;
    
    // Points
    public GameObject PointsTxt;
    public Text PointstxtVal;
    public string GoldString;
    public string PopulationString;

    // House
    public string HouseValueString;
    public string HouseAmountString;
    public int HouseValue;
    public GameObject HousePriceTxt;
    public Text HousePriceValue;
    public GameObject HouseAmountTxt;
    public Text HouseAmountValue;

    // Market
    public string MarketValueString;
    public string MarketAmountString;
    public int MarketValue;
    public GameObject MarketPriceTxt;
    public Text MarketPriceValue;
    public GameObject MarketAmountTxt;
    public Text MarketAmountValue;


    void Start ()
    {
        SetPrices();

        // House
        HousePriceTxt = GameObject.Find("HousePriceTxt");
        HousePriceValue = HousePriceTxt.GetComponent<Text>();
        HouseAmountTxt = GameObject.Find("HouseAmountTxt");
        HouseAmountValue = HouseAmountTxt.GetComponent<Text>();

        HouseValueString = HouseValue.ToString(); // Initilises displayed value of house price
        HousePriceValue.text = "Price: " + HouseValueString;

        HouseAmountString = InfoStatic.houses.ToString(); // Initilises Displayed Value of houses bought
        HouseAmountValue.text = "Built: " + HouseAmountString;

        // Market
        MarketPriceTxt = GameObject.Find("MarketPriceTxt");
        MarketPriceValue = MarketPriceTxt.GetComponent<Text>();
        MarketAmountTxt = GameObject.Find("MarketAmountTxt");
        MarketAmountValue = MarketAmountTxt.GetComponent<Text>();

        MarketValueString = MarketValue.ToString(); // Initilises displayed value of market price
        MarketPriceValue.text = "Price: " + MarketValueString;

        MarketAmountString = InfoStatic.markets.ToString(); // Initilises Displayed Value of markets bought
        MarketAmountValue.text = "Built: " + MarketAmountString;

        // Points
        PointsTxt = GameObject.Find("PointsTxt");
        PointstxtVal = PointsTxt.GetComponent<Text>();
    }
	

	void Update ()
    {
        UpdateText();
	}

    public void SetPrices()
    {
        InfoStatic.houseprice = HouseValue;
        InfoStatic.marketprice = MarketValue;
    }

    public void UpdateText()
    {
        // Points Text
        GoldString = InfoStatic.gold.ToString();
        PopulationString = InfoStatic.population.ToString();
        PointstxtVal.text = "Gold: " + GoldString + "  Population: " + PopulationString;
        // House Text
        HouseAmountString = InfoStatic.houses.ToString();
        HouseAmountValue.text = "Built: " + HouseAmountString;
        // Market Text
        MarketAmountString = InfoStatic.markets.ToString();
        MarketAmountValue.text = "Built: " + MarketAmountString;
    }

    public void BuyHouse()
    {
        Debug.Log("Click");
        if (InfoStatic.gold >= InfoStatic.houseprice) // Detect if player has enough gold
        {
            Debug.Log("Able To Buy");
            if (InfoStatic.housebought == false) // Checks if player has bought upgrade before
            {
                Debug.Log("First House");
                InfoStatic.housebought = true;
            }

            InfoStatic.gold -= InfoStatic.houseprice; // Updates values to represent a house being bought
            InfoStatic.houses++;
            Debug.Log("Houses: " + InfoStatic.houses);
            Debug.Log("Gold: " + InfoStatic.gold);
            HouseAmountValue.text = "Built: " + HouseAmountString;
        }
        else
        {
            Debug.Log("Not Enough Gold");
        }
    }

    public void BuyMarket()
    {
        Debug.Log("Click");
        Debug.Log("Market Price: " + InfoStatic.marketprice);
        if (InfoStatic.gold >= InfoStatic.marketprice) // Detect if player has enough gold
        {
            Debug.Log("Able To Buy");
            if (InfoStatic.marketbought == false) // Checks if player has bought upgrade before
            {
                Debug.Log("First Market");
                InfoStatic.marketbought = true;
            }

            InfoStatic.gold -= InfoStatic.marketprice; // Updates values to represent a market being bought
            InfoStatic.markets++;
            Debug.Log("Markets: " + InfoStatic.markets);
            Debug.Log("Gold: " + InfoStatic.gold);
            MarketAmountValue.text = "Built: " + MarketAmountString;
        }
        else
        {
            Debug.Log("Not Enough Gold");
        }
    }
}
