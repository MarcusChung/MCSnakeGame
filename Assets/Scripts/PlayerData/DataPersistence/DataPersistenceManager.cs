using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DataPersistenceManager : MonoBehaviour
{
    [SerializeField] private string fileName;

    public static DataPersistenceManager instance { get; private set; }
    private Data gameData;
    private const string PROFILE_PREFIX = "data.profile.";
    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler DataHandler;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void NewGame()
    {
        this.gameData = new Data();
    }

    public void DeleteSave(string fileName)
    {
        this.DataHandler = new FileDataHandler(Application.persistentDataPath, PROFILE_PREFIX + fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        this.gameData = new Data();
        foreach (IDataPersistence dataPersistenceObject in dataPersistenceObjects)
        {
            dataPersistenceObject.LoadData(gameData);
        }
        DataHandler.Save(gameData);
    }

    public void LoadGame(string fileName)
    {
        this.DataHandler = new FileDataHandler(Application.persistentDataPath, PROFILE_PREFIX + fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        this.gameData = DataHandler.Load();
        if (this.gameData == null)
        {
            Debug.Log("No data found, using default");
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObject in dataPersistenceObjects)
        {
            dataPersistenceObject.LoadData(gameData);
        }
        // Debug.Log("Loaded death count = " + gameData.deathCount);
    }

    private void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObject in dataPersistenceObjects)
        {
            dataPersistenceObject.SaveData(ref gameData);
        }
        Debug.Log("Saved game");
        DataHandler.Save(gameData);
    }

    private void Start()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;
        this.DataHandler = new FileDataHandler(Application.persistentDataPath, PROFILE_PREFIX + fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame("data.default");
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    //on application scene change, save game()
    private void ChangedActiveScene(Scene current, Scene next)
    {
        string currentName = current.name;

        if (currentName == null)
        {
            currentName = "Replaced";
        }
        SaveGame();
        Debug.Log("Scenes: " + currentName + ", " + next.name);
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
        .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
