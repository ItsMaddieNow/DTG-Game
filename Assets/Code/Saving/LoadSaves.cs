using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSaves: MonoBehaviour
{
    public string SaveDirectory;
    public void Load()
    {
        SaveManagement.SaveSlotDir = SaveDirectory;
        SaveManagement.Load("Loading error");
    }
}
    