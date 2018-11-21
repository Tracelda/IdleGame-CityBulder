using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoStatic
{
    // Score totals
    public static int population;
    public static int gold;

    // Upgrades Bought & Amounts
    public static bool housebought;
    public static int houses;
    public static int houseprice;

    public static bool marketbought;
    public static int markets;
    public static int marketprice;

    public static bool minebought;
    public static int mines;
    public static int mineprice;


    public static int Population
    {
        get
        {
            return population;
        }
        set
        {
            population = value;
        }
    }

    public static int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
        }
    }


    // House
    public static int HousePrice
    {
        get
        {
            return houseprice;
        }
        set
        {
            houseprice = value;
        }
    }
    
    public static bool HousesBought
    {
        get
        {
            return housebought;
        }
        set
        {
            housebought = value;
        }
    }
    public static int Houses
    {
        get
        {
            return houses;
        }
        set
        {
            houses = value;
        }
    }

    // Market
    public static bool Marketbought
    {
        get
        {
            return marketbought;
        }
        set
        {
            marketbought = value;
        }
    }
    public static int Markets
    {
        get
        {
            return markets;
        }
        set
        {
            markets = value;
        }
    }


}
