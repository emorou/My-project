using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    private GameData gameData;

    public static DataPersistenceManager instance {get; private set;}

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Found more than one daata persistence manager in this scene");
        }
        instance = this;
    }

    private void Start()
    {
        LoadGame();
    }
    public void NewGame()
    {
        this.gameData = new GameData(); 
    }
     
    public void LoadGame()
    {
        if(this.gameData == null)
        {
            Debug.Log("No data was found. Initializing data to default");
            NewGame();
        }

    }

    public void SaveGame()
    {

    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
