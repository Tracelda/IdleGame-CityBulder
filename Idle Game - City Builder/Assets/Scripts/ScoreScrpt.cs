using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScrpt : MonoBehaviour {

    public InfoStatic InfoStatic;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log("Gold:" + InfoStatic.gold);
        Debug.Log("Population:" + InfoStatic.population);
    }

    public void UpdateGoldOnBtn()
    {
        InfoStatic.gold++;
    }

    public void UpdatePopulationOnBtn()
    {
        InfoStatic.population++;
    }
}
