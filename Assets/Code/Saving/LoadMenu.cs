using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class LoadMenu : MonoBehaviour
{
    public ButtonData buttonprefab;
    public RectTransform Content;
    public float ButtonVerticalSize = 45f;
    private string Savedirectory;
    public MainLevelLoad MainLevelLoader;
    public void Start()
    {
        Savedirectory = Application.persistentDataPath + "/saves";
        Load();
    }
    public void Load() 
    {
        Directory.CreateDirectory(Savedirectory);
        string[] Saves = Directory.GetDirectories(Savedirectory);
        print("Starting loading");
        Content.sizeDelta = new Vector2(Content.sizeDelta.x,Saves.Length*ButtonVerticalSize);
        buttonprefab.SceneLoader.LoadManager = MainLevelLoader;
        float ButtonPosition = 5f;
        foreach (string save in Saves)
        {
            print("Loading:" + save );
            string RawSaveData = File.ReadAllText(save + "/SaveData.json");
            SaveData saveData = JsonUtility.FromJson<SaveData>(RawSaveData);
            ButtonData button = Instantiate(buttonprefab, Content.transform);
            button.RT.anchoredPosition = new Vector2(button.RT.anchoredPosition.x,-ButtonPosition);
            button.SaveNameText.text = saveData.SaveName;
            button.SaveDateText.text = saveData.Time;
            button.LoadOfSaves.SaveDirectory = save;
            ButtonPosition += ButtonVerticalSize;
        }

    }
   
}
