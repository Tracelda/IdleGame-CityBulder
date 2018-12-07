using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Navigation { mainmenu, shop, game };

public class NavigationScript : MonoBehaviour {

    public Navigation SceneNum;

    void Start ()
    {
		
	}
	

	void Update ()
    {
		
	}

    public void ChangeScene()
    {
        switch (SceneNum)
        {
            case Navigation.mainmenu:
                Debug.Log("Switch to main menu");
                SceneManager.LoadScene(0);
                break;

            case Navigation.shop:
                Debug.Log("Switch to shop");
                SceneManager.LoadScene(1);
                break;

            case Navigation.game:
                Debug.Log("Switch to game");
                SceneManager.LoadScene(2);
                break;
        }
    }

    public void SwitchToMainMenu()
    {
        SceneNum = (Navigation)0; // Main Menu
        ChangeScene();
    }

    public void SwitchToShop()
    {
        SceneNum = (Navigation)1; // Shop
        ChangeScene();
    }

    public void SwitchToGame()
    {
        SceneNum = (Navigation)2; // Game
        ChangeScene();
    }
}
