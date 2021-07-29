using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
public static class SaveManagement
{
    public static SaveData saveData = new SaveData();
    public static bool SaveLoaded = false;
    static string SaveSlotDir = Application.persistentDataPath + "/Debug"; //Set Default Save Slot to Debug
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        Debug.Log(SaveSlotDir);
        Debug.Log(System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + " " + System.DateTime.Now.Day + "/" + System.DateTime.Now.Month + "/" + System.DateTime.Now.Year);
    }
    public static void CreateSave(string SaveName){
        SaveData data = new SaveData();
        data.SaveName = SaveName;
        data.SaveVersion = Application.version;
        data.Time = System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + " " + System.DateTime.Now.Day + "/" + System.DateTime.Now.Month + "/" + System.DateTime.Now.Year;
        saveData = data;
        string json = JsonUtility.ToJson(data);
        Directory.CreateDirectory(SaveSlotDir);
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

}

[System.Serializable]
public  class SaveData
{
    public string SaveName;
    public string SaveVersion; // Use Application.version when writing save
    public string Time;
    
    public float[] Position = {1f,1f};
}