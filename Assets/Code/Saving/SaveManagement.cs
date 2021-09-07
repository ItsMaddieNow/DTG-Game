using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
    public string SaveName;
    public string SaveVersion; // Use Application.version when writing save
    public string Time;
    
    public float[] Position = {1f,1f};
    public int CheckpointIndex = 0;
    public LavaManager.LavaState lavaState = LavaManager.LavaState.Start;
}

public static class SaveManagement
{
    public static SaveData saveData = new SaveData();
    public static bool SaveLoaded = false;
    public static string SaveSlotDir = Application.persistentDataPath + "/saves/Debug"; //Set Default Save Slot to Debug

    public static void CreateSave(string SaveName){
        Debug.Log("Creating Save, Name: " + SaveName);
        Directory.CreateDirectory(SaveSlotDir);
        SaveData data = new SaveData();
        data.SaveName = SaveName;
        data.SaveVersion = Application.version;
        data.Time = System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + " " + System.DateTime.Now.Day + "/" + System.DateTime.Now.Month + "/" + System.DateTime.Now.Year;
        saveData = data;

        string json = JsonUtility.ToJson(saveData);
        BinaryFormatter bf = new BinaryFormatter();
            
        File.WriteAllText(SaveSlotDir + "/SaveData.json", json);
    }

    public static void Save(){
        Directory.CreateDirectory(SaveSlotDir);
        saveData.SaveVersion = Application.version;
        saveData.Time = System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + " " + System.DateTime.Now.Day + "/" + System.DateTime.Now.Month + "/" + System.DateTime.Now.Year;

        string json = JsonUtility.ToJson(saveData);
        BinaryFormatter bf = new BinaryFormatter();

        File.WriteAllText(SaveSlotDir + "/SaveData.json", json);
    }

    public static void Load(string SaveName){
        // Checks if SaveData Exists in Save Slot and loads it into a class that can be pulled from if found, creates save if it isn't.s
        if (File.Exists(SaveSlotDir + "/SaveData.json")){
            string json = File.ReadAllText(SaveSlotDir + "/SaveData.json");
            saveData = JsonUtility.FromJson<SaveData>(json);
        }else{
            CreateSave(SaveName);
        }
        SaveLoaded = true;
        Debug.Log("Loaded Saveslot: " + saveData.SaveName);
    }
    /*public static void LoadNoCreate(string SaveName){
        // Checks if SaveData Exists in Save Slot and loads it into a class that can be pulled from if found, creates save if it isn't.s
        if (File.Exists(SaveSlotDir + "/SaveData.json")){
            string json = File.ReadAllText(SaveSlotDir + "/SaveData.json");
            saveData = JsonUtility.FromJson<SaveData>(json);
        }
        SaveLoaded = true;
        Debug.Log("Loaded Saveslot: " + saveData.SaveName);
    }*/
    public static void AsynchronousLoad(string SaveName){
        // Checks if SaveData Exists in Save Slot and loads it into a class that can be pulled from if found, creates save if it isn't.s
        if (File.Exists(SaveSlotDir + "/SaveData.json")){
            //var process 
            string json = File.ReadAllText(SaveSlotDir + "/SaveData.json");
            saveData = JsonUtility.FromJson<SaveData>(json);
        }else{
            CreateSave(SaveName);
        }
        SaveLoaded = true;
        Debug.Log("Loaded Saveslot: " + saveData.SaveName);
    }
}
