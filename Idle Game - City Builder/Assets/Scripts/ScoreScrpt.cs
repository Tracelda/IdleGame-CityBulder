using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScrpt : MonoBehaviour {

    public InfoStatic InfoStatic;
    public BuildingScrpt BuildingScrpt;
    public int PreviousGold;
    public int previousPopulation;
    public string GoldString;
    public string PopulationString;

    public GameObject GoldAmount;
    public Text GoldAmountTxt;
    public GameObject PopulationAmount;
    public Text PopulationAmountTxt;

    public float GoldPerSecond;
    public float PopulationPerSecond;

    public float Timer;
    public float TimerTarget;

    public float HouseGoldIncome;
    public float HousePopulationIncome;

    public float GoldIncome;
    public float PopulationIncome;

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

    public void UpdateGoldOnBtn()
    {
        InfoStatic.gold++;
        GoldString = InfoStatic.gold.ToString();
        GoldAmountTxt.text = GoldString;
    }

    public void UpdatePopulationOnBtn()
    {
        InfoStatic.population++;
        PopulationString = InfoStatic.population.ToString();
        PopulationAmountTxt.text = PopulationString;
    }

    public void AddGold()
    {
        if (InfoStatic.housebought == true)
        {
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
    }

    public void AddPopulation()
    {
        if (InfoStatic.housebought == true)
        {
            PopulationPerSecond += (InfoStatic.housepopincome * InfoStatic.houses);
            Debug.Log("Pop per second: " + PopulationPerSecond);
            if (PopulationPerSecond >= 1)
            {
                PopulationIncome = 0;
                Debug.Log("Pop Per Second Higher Than 1");
                PopulationIncome = Mathf.Floor(PopulationPerSecond);
                PopulationPerSecond -= Mathf.Floor(PopulationPerSecond);
                Debug.Log("Population Income: " + PopulationIncome);
                // aaaaa
            }
        }
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

    public void UpdateValues()
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
    }
}
