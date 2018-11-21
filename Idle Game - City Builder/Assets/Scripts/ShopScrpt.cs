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
    public string HouseValueString;
    public string HouseAmountString;

	void Start ()
    {
        HousePriceTxt = GameObject.Find("HousePriceTxt");
        HousePriceValue = HousePriceTxt.GetComponent<Text>();
        HouseAmountTxt = GameObject.Find("HouseAmountTxt");
        HouseAmountValue = HouseAmountTxt.GetComponent<Text>();

        HouseValueString = HouseValue.ToString(); // Changes Displayed value of House Price
        HousePriceValue.text = "Price: " + HouseValueString;

        HouseAmountString = InfoStatic.houses.ToString();
        HouseAmountValue.text = "Built: " + HouseAmountString;
	}
	

	void Update ()
    {
		
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

            InfoStatic.gold -= InfoStatic.houseprice;
            InfoStatic.houses++;
            Debug.Log(InfoStatic.houses);
            HouseAmountValue.text = "Built: " + HouseAmountString;
        }
        else
        {
            Debug.Log("Not Enough Gold");
        }
    }
}
