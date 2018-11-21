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

    public int GoldPerSecond;
    public int PopulationPerSecond;

    public float Timer;
    public float TimerTarget;

    public int HouseGoldIncome;
    public int HousePopulationIncome;

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
    }

    public void UpdatePopulationOnBtn()
    {
        InfoStatic.population++;
        PopulationString = InfoStatic.population.ToString();
    }

    public void AddGold()
    {
        if (InfoStatic.housebought == true)
        {
            GoldPerSecond += (InfoStatic.housegoldincome * InfoStatic.houses);
        }
    }

    public void AddPopulation()
    {
        if (InfoStatic.housebought == true)
        {
            PopulationPerSecond += (InfoStatic.housepopincome * InfoStatic.houses);
        }
    }

    public void UpdatePoints()
    {
        AddGold();
        AddPopulation();

        if (Timer < TimerTarget)
        {
            Timer += Time.deltaTime;
        }
        else if (Timer >= TimerTarget)
        {
            InfoStatic.gold += GoldPerSecond;
            InfoStatic.population += PopulationPerSecond;
            UpdateValues();
            Timer = 0;
        }

    }

    public void UpdateValues()
    {
        Debug.Log("Gold:" + InfoStatic.gold);
        Debug.Log("Population:" + InfoStatic.population);
        PopulationAmountTxt.text = PopulationString;
        GoldAmountTxt.text = GoldString;
    }

    public void SetIncomes()
    {
        InfoStatic.housegoldincome = HouseGoldIncome;
        InfoStatic.housepopincome = HousePopulationIncome;
    }
}
