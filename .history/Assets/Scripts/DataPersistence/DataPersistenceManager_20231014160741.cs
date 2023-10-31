using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;

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
        dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }
    public void NewGame()
    {
        gameData = new GameData(); 
    }
     
    public void LoadGame()
    {
        if(gameData == null)
        {
            Debug.Log("No data was found. Initializing data to default");
            NewGame();
        }

        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

        Debug.Log("loaded gold = " + gameData.gold);
        Debug.Log("loaded gold = " + gameData.gold);
        Debug.Log("loaded gold = " + gameData.gold);
        Debug.Log("loaded gold = " + gameData.gold);
    }

    public void SaveGame()
    {
        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(gameData);
        }

        Debug.Log("Saved gold = " + gameData.gold);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
