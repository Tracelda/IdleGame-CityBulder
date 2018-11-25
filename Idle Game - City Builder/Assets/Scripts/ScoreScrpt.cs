using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScrpt : MonoBehaviour {

    public InfoStatic InfoStatic;
    public BuildingScrpt BuildingScrpt;

    // Text
    public GameObject GoldAmount;
    public Text GoldAmountTxt;
    public GameObject PopulationAmount;
    public Text PopulationAmountTxt;

    public float Timer;
    public float TimerTarget;

    // Points stuff
    public float HouseGoldIncome;
    public float HousePopulationIncome;

    public float MarketGoldIncome;
    public float MarketPopulationIncome;

    public float GoldIncome;
    public float PopulationIncome;

    public float GoldPerSecond;
    public float PopulationPerSecond;

    public string GoldString;
    public string PopulationString;

    public float BasePopulationLimit;
    public float HousePopulationModifier;

    void Start ()
    {
        GoldAmount = GameObject.Find("GoldAmount");
        GoldAmountTxt = GoldAmount.GetComponent<Text>();

        PopulationAmount = GameObject.Find("PopulationAmount");
        PopulationAmountTxt = PopulationAmount.GetComponent<Text>();

        BuildingScrpt.ShowBuildings(); // Check which building have been bought 
        SetIncomes();
        
    }
	
	void Update ()
    {
        UpdatePoints();
    }

    public void UpdateGoldOnBtn() // Adds one to gold score when button is pressed
    {
            InfoStatic.gold++;
            GoldString = InfoStatic.gold.ToString();
            GoldAmountTxt.text = GoldString;
    }

    public void UpdatePopulationOnBtn() // Adds one to population score when button is pressed
    {

        if (InfoStatic.population < InfoStatic.populationlimit)
        {
            InfoStatic.population++;
            PopulationString = InfoStatic.population.ToString();
            PopulationAmountTxt.text = PopulationString;
        }
        else { Debug.Log("Max population reached"); }
    }

    public void AddGold() // adds gold incomes together and adds total to gold score
    {
        if (InfoStatic.housebought == true)
        {
            Debug.Log("Points From House");
            GoldPerSecond += (InfoStatic.housegoldincome * InfoStatic.houses);
            if(GoldPerSecond >=1)
            {
                GoldIncome = 0;
                Debug.Log("Gold Per Second Higher Than 1");
                GoldIncome = Mathf.Floor(GoldPerSecond);
                GoldPerSecond -= Mathf.Floor(GoldPerSecond);
                Debug.Log("Gold Income: " + GoldIncome);
            }
        }
        if (InfoStatic.marketbought == true)
        {
            Debug.Log("Points From Market");
            GoldPerSecond += (InfoStatic.marketgoldincome * InfoStatic.markets);
            if (GoldPerSecond >= 1)
            {
                GoldIncome = 0;
                Debug.Log("Gold Per Second Higher Than 1");
                GoldIncome = Mathf.Floor(GoldPerSecond);
                GoldPerSecond -= Mathf.Floor(GoldPerSecond);
                Debug.Log("Gold Income: " + GoldIncome);
            }
        }
    }

    public void AddPopulation() // adds population incomes together and adds total to population score
    {
        if  (InfoStatic.population < InfoStatic.populationlimit)
        {
            if (InfoStatic.housebought == true)
            {
                PopulationPerSecond += (InfoStatic.housepopincome * InfoStatic.houses);
                Debug.Log("Pop per second: " + PopulationPerSecond);
                if (PopulationPerSecond >= 1)
                {
                    // PopulationIncome = 0;
                    Debug.Log("Pop Per Second Higher Than 1");
                    PopulationIncome = Mathf.Floor(PopulationPerSecond);
                    PopulationPerSecond -= Mathf.Floor(PopulationPerSecond);
                    Debug.Log("Population Income: " + PopulationIncome);
                }
            }
            if (InfoStatic.marketbought == true)
            {
                PopulationPerSecond += (InfoStatic.marketpopincome * InfoStatic.markets);
                Debug.Log("Pop per second: " + PopulationPerSecond);
                if (PopulationPerSecond >= 1)
                {
                    // PopulationIncome = 0;
                    Debug.Log("Pop Per Second Higher Than 1");
                    PopulationIncome = Mathf.Floor(PopulationPerSecond);
                    PopulationPerSecond -= Mathf.Floor(PopulationPerSecond);
                    Debug.Log("Population Income: " + PopulationIncome);
                }
            }
        } 
        else { Debug.Log("Max population reached"); }
    }

    public void UpdatePoints()
    {
        if (Timer < TimerTarget)
        {
            Timer += Time.deltaTime;
        }
        else if (Timer >= TimerTarget)
        {
            AddGold();
            AddPopulation();
            InfoStatic.gold += GoldIncome;
            InfoStatic.population += PopulationIncome;
            UpdateValues();
            Debug.Log("Update Values");
            Timer = 0;
            //PopulationIncome = 0;
            //GoldIncome = 0;
        }

    }

    public void UpdateValues() // updates the values of text boxes
    {
        Debug.Log("Gold:" + InfoStatic.gold);
        Debug.Log("Population:" + InfoStatic.population);
        PopulationString = InfoStatic.population.ToString();
        PopulationAmountTxt.text = PopulationString;
        GoldString = InfoStatic.gold.ToString();
        GoldAmountTxt.text = GoldString;
    }

    public void SetIncomes()
    {
        InfoStatic.housegoldincome = HouseGoldIncome;
        InfoStatic.housepopincome = HousePopulationIncome;
        InfoStatic.marketgoldincome = MarketGoldIncome;
        InfoStatic.marketpopincome = MarketPopulationIncome;
    }

    public void ChangePopulationLimit()
    {
        InfoStatic.populationlimit = BasePopulationLimit + (InfoStatic.houses * HousePopulationModifier);
    }
}
