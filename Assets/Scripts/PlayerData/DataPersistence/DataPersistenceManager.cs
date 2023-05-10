using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    [SerializeField] private string fileName;

    public static DataPersistenceManager instance { get; private set; }
    private Data gameData;
    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler DataHandler;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Instance already exists");
        }
        instance = this;

    }

    public void NewGame()
    {
        this.gameData = new Data();
    }

    public void LoadGame()
    {
        this.gameData = DataHandler.Load();
        if (this.gameData == null)
        {
            Debug.Log("No game data found, using default initialization");
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObject in dataPersistenceObjects)
        {
            dataPersistenceObject.LoadData(gameData);
        }
        // Debug.Log("Loaded death count = " + gameData.deathCount);
    }

    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObject in dataPersistenceObjects)
        {
            dataPersistenceObject.SaveData(ref gameData);
        }
        // Debug.Log("Saved death count = " + gameData.deathCount);

        DataHandler.Save(gameData);
    }

    private void Start()
    {
        this.DataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
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
}
