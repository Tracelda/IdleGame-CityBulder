using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScrpt : MonoBehaviour {

    public InfoStatic InfoStatic;
    public GameObject House;

    private void Start()
    {
        House = GameObject.Find("House");
    }

    public void ShowBuildings()
    {
        if (InfoStatic.housebought == true)
        {
            House.SetActive(true);
        }
    }
}
