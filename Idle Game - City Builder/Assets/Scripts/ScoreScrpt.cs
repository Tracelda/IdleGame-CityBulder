using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScrpt : MonoBehaviour {

    public InfoStatic InfoStatic;
    public int PreviousGold;
    public int previousPopulation;
    public string GoldString;
    public string PopulationString;

    public GameObject GoldAmount;
    public Text GoldAmountTxt;
    public GameObject PopulationAmount;
    public Text PopulationAmountTxt;

    // Use this for initialization
    void Start ()
    {
        GoldAmount = GameObject.Find("GoldAmount");
        GoldAmountTxt = GoldAmount.GetComponent<Text>();
        PopulationAmount = GameObject.Find("PopulationAmount");
        PopulationAmountTxt = PopulationAmount.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log("Gold:" + InfoStatic.gold);
        Debug.Log("Population:" + InfoStatic.population);
        PopulationAmountTxt.text = PopulationString;
        GoldAmountTxt.text = GoldString;
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
}
