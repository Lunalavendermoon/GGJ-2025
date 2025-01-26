using UnityEngine;
using System;
using System.IO;
using System.Linq.Expressions;
public class FileDataHandler
{
    private readonly string dataDirPath;
    private readonly string dataFileName;

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public GameData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;

        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = File.ReadAllText(fullPath);
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError($"Error loading data: {e}");
            }
        }
        else
        {
            Debug.LogWarning($"File not found at path: {fullPath}");
        }

        return loadedData;
    }

    public void Save(GameData data)
    {
        if (data == null)
        {
            Debug.LogError("No data to save.");
            return;
        }

        string fullPath = Path.Combine(dataDirPath, dataFileName);

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            string dataToStore = JsonUtility.ToJson(data, true);
            File.WriteAllText(fullPath, dataToStore);
            Debug.Log($"Data saved to {fullPath}");
        }
        catch (Exception e)
        {
            Debug.LogError($"Error saving data: {e}");
        }
    }

    public void ClearData()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);

        try
        {
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                Debug.Log($"Data cleared at {fullPath}");
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Error clearing data: {e}");
        }
    }
}

