using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using Unity.VisualScripting;

public class DataPersistanceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    private GameData gameData;
    private List<IDataPersistance> dataPersistanceObjects;
    private FileDataHandler dataHandler;
    public static DataPersistanceManager instance {get; private set;}

    private void Awake() {
        if (instance != null) {
            Debug.Log("issue with data persistance");
        }
        instance = this;
    }

    private void Start() {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistanceObjects = FindAllDataPersistanceObjects();
        LoadGame();
    }
    public void NewGame() {
        this.gameData = new GameData();
    }

    public void LoadGame() {
        this.gameData = dataHandler.Load();

        if (this.gameData == null) {
            Debug.Log("No data found. Initializing new game.");
            NewGame();
        }

        foreach(IDataPersistance dataPersistanceObj in dataPersistanceObjects) {
            dataPersistanceObj.LoadData(gameData);
        }

        Debug.Log("Loaded score: " + gameData.highScore);
    }

    public void SaveGame() {
        foreach(IDataPersistance dataPersistanceObj in dataPersistanceObjects) {
            dataPersistanceObj.SaveData(ref gameData);
        }
        Debug.Log("Saved score: " + gameData.highScore);
        dataHandler.Save(gameData);
    }

    private List<IDataPersistance> FindAllDataPersistanceObjects() {
        return FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>().ToList();
    }
}
