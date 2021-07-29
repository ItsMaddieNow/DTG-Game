using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSaveLoader : MonoBehaviour
{
    // Loads Debug Save If the Player Doesn't Load One from The Main Menu
    void Awake()
    {
        print("Attempting Load");
        if (!SaveManagement.SaveLoaded){
            SaveManagement.Load("Debug Save");
            print("loaded");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
