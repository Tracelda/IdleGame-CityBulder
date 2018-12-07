using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class Savegame : MonoBehaviour {

    public bool GameSaveLoaded = false;
    public float PopulationScore = 0f;
    public float GoldScore = 0f;
    public InfoStatic InfoStatic;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Save()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        // creates a file in the data path /C/users/appdata/....
        FileStream DataFile = File.Create(Application.persistentDataPath + "/PlayerData.dat");

        // creates new instance of the game data class
        GameData data = new GameData();

        // populating the new instance with the current ingame values
        data.goldscore = InfoStatic.gold;

        // turns data to binary
        binaryFormatter.Serialize(DataFile, data);
        DataFile.Close();
    }

    public void Load()
    {
        // checks to see if data file exists
        if (File.Exists(Application.persistentDataPath + "/PlayerData.dat"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            // makes a local file with the file in the location and opens it 
            FileStream dataFile = File.Open(Application.persistentDataPath + "/PlayerData.dat", FileMode.Open);

            //converts the data back from binary
            GameData data = (GameData)binaryFormatter.Deserialize(dataFile);
            dataFile.Close();

            // set the ingame values to values in save file 
            InfoStatic.gold = data.goldscore;
        }
        //Reload the scene
        SceneManager.LoadScene(0);
    }
}


// things we want to save 
[Serializable]
class GameData
{
    public float goldscore;

    
}
