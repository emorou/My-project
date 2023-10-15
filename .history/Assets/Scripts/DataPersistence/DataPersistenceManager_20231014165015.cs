using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    
    [SerializeField] private string fileName;

    private GameData gameData;
     
    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler  dataHandler;

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
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }
    public void NewGame()
    {
        gameData = new GameData(); 
    }
     
    public void LoadGame()
    {
        gameData = dataHandler.Load();

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
        Debug.Log("loaded level = " + gameData.level);
        Debug.Log("loaded experience = " + gameData.experience);
        Debug.Log("loaded experienceCap = " + gameData.experienceCap);
    }

    public void SaveGame()
    {
        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(gameData);
        }

         Debug.Log("saved gold = " + gameData.gold);
        Debug.Log("saved level = " + gameData.level);
        Debug.Log("saved experience = " + gameData.experience);
        Debug.Log("saved experienceCap = " + gameData.experienceCap);

        dataHandler.Save(gameData);
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
