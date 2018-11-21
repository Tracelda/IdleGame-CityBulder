using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScrpt : MonoBehaviour {
    public InfoStatic InfoStatic;
    public int HouseValue;
    public GameObject HousePriceTxt;
    public Text HousePriceValue;
    public GameObject HouseAmountTxt;
    public Text HouseAmountValue;
    public GameObject PointsTxt;
    public Text PointstxtVal;
    public string HouseValueString;
    public string HouseAmountString;
    public string GoldString;
    public string PopulationString;

    void Start ()
    {
        HousePriceTxt = GameObject.Find("HousePriceTxt");
        HousePriceValue = HousePriceTxt.GetComponent<Text>();
        HouseAmountTxt = GameObject.Find("HouseAmountTxt");
        HouseAmountValue = HouseAmountTxt.GetComponent<Text>();
        PointsTxt = GameObject.Find("PointsTxt");
        PointstxtVal = PointsTxt.GetComponent<Text>();

        SetPrices();

        HouseValueString = HouseValue.ToString(); // Changes Displayed value of House Price
        HousePriceValue.text = "Price: " + HouseValueString;

        HouseAmountString = InfoStatic.houses.ToString();
        HouseAmountValue.text = "Built: " + HouseAmountString;

	}
	

	void Update ()
    {
        UpdateText();
	}

    public void SetPrices()
    {
        InfoStatic.houseprice = HouseValue;
    }

    public void UpdateText()
    {
        GoldString = InfoStatic.gold.ToString();
        PopulationString = InfoStatic.population.ToString();
        PointstxtVal.text = "Gold: " + GoldString + "  Population: " + PopulationString;
        HouseAmountString = InfoStatic.houses.ToString();
        HouseAmountValue.text = "Built: " + HouseAmountString;
    }

    public void BuyHouse()
    {
        Debug.Log("Click");
        if (InfoStatic.gold >= InfoStatic.houseprice)
        {
            Debug.Log("Able To Buy");
            if (InfoStatic.housebought == false)
            {
                Debug.Log("First House");
                InfoStatic.housebought = true;
            }

            InfoStatic.gold = InfoStatic.gold - InfoStatic.houseprice;
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
}
