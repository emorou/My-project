// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.Linq;
// using UnityEngine.SceneManagement;

// public class DataPersistenceManager : MonoBehaviour
// {
//     [Header("Debugging")]

//     [SerializeField] private bool initializeDataIfNull = false;

//     [Header("File Storage Config")]
    
//     [SerializeField] private string fileName;

//     [SerializeField] private bool useEncryption;
            
//     private GameData gameData;
     
//     private List<IDataPersistence> dataPersistenceObjects;

//     private FileDataHandler dataHandler;
    
//     private string selectedProfileId = "test";

//     public static DataPersistenceManager instance {get; private set;}

//     private void Awake()
//     {
//         if(instance != null)
//         {
//             Debug.LogError("Found more than one data persistence manager in this scene. Destroying the newest one");
//             Destroy(gameObject);
//             return;
//         }
//         instance = this;
//         DontDestroyOnLoad(gameObject);

//         dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
//     }

//     private void OnEnable()
//     {
//         SceneManager.sceneLoaded += OnSceneLoaded;
//     }

//     private void OnDisable()
//     {
//         SceneManager.sceneLoaded -= OnSceneLoaded; 
//     }

//     public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//     { 
//         dataPersistenceObjects = FindAllDataPersistenceObjects();
//         LoadGame();
//     }

//     public void NewGame()
//     {
//         gameData = new GameData(); 
//     }
     
//     public void LoadGame()
//     {
//         gameData = dataHandler.Load(selectedProfileId);

//         if(gameData == null && initializeDataIfNull)
//         {
//             NewGame();
//         }

//         if(gameData == null)
//         {
//             Debug.Log("No data was found. A new game needs to be started");
//             return;
//         }

//         foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
//         {
//             dataPersistenceObj.LoadData(gameData);
//         }

//         Debug.Log("loaded gold = " + gameData.gold);
//         Debug.Log("loaded level = " + gameData.level);
//         Debug.Log("loaded experience = " + gameData.experience);
//     }

//     public void SaveGame()
//     {
//         if(gameData == null)
//         {
//             Debug.LogWarning("No data was found. A new game needs to be started"); 
//             return;
//         }
//         foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
//         {
//             dataPersistenceObj.SaveData(gameData);
//         }

//         dataHandler.Save(gameData, selectedProfileId);
//     }

//     private void OnApplicationQuit()
//     {
//         SaveGame();
//     }

//     private List<IDataPersistence> FindAllDataPersistenceObjects()
//     {
//         IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

//         return new List<IDataPersistence>(dataPersistenceObjects);
//     }

//     public bool HasGameData()
//     {
//         return gameData != null;
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("Debugging")]
    [SerializeField] private bool initializeDataIfNull = false;

    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] private bool useEncryption;

    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;

    public static DataPersistenceManager instance { get; private set; }

    private void Awake() 
    {
        if (instance != null) 
        {
            Debug.Log("Found more than one Data Persistence Manager in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
    }

    private void OnEnable() 
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable() 
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode) 
    {
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void OnSceneUnloaded(Scene scene)
    {
        SaveGame();
    }

    public void NewGame() 
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        // load any saved data from a file using the data handler
        this.gameData = dataHandler.Load(set);

        // start a new game if the data is null and we're configured to initialize data for debugging purposes
        if (this.gameData == null && initializeDataIfNull) 
        {
            NewGame();
        }

        // if no data can be loaded, don't continue
        if (this.gameData == null) 
        {
            Debug.Log("No data was found. A New Game needs to be started before data can be loaded.");
            return;
        }

        // push the loaded data to all other scripts that need it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects) 
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        // if we don't have any data to save, log a warning here
        if (this.gameData == null) 
        {
            Debug.LogWarning("No data was found. A New Game needs to be started before data can be saved.");
            return;
        }

        // pass the data to other scripts so they can update it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects) 
        {
            dataPersistenceObj.SaveData(gameData);
        }

        // save that data to a file using the data handler
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit() 
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects() 
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public bool HasGameData() 
    {
        return gameData != null;
    }
}