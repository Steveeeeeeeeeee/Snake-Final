using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    private GameData gameData;
    public static DataPersistenceManager Instance { get; private set; }

    private List <IDataPersistence> dataPersistenceObjects;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There should never be two data persistence managers.");
        }

        Instance = this;
    }

    private void Start()
    {
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }



    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {


        if (this.gameData == null)
        {
            Debug.Log("No game data to load. Starting new game instead.");
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObject in this.dataPersistenceObjects)
        {
            dataPersistenceObject.LoadData(gameData);
        }   

        Debug.Log("Loaded Max level is " + this.gameData.MaxLevel);
    }

    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObject in this.dataPersistenceObjects)
        {
            dataPersistenceObject.SaveData(ref gameData);
        }
        Debug.Log("Saved Max level is " + this.gameData.MaxLevel);
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }   

    private void OnApplicationQuit()
    {
        //SaveGame();
    }

}
