using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SaveCreator : MonoBehaviour
{
    [SerializeField] private TMP_InputField SaveName;
    public void CreateSave(){
        SaveManagement.SaveSlotDir = Application.persistentDataPath + "/saves/" + System.Guid.NewGuid();
        print("Creating Save at " + SaveManagement.SaveSlotDir);
        SaveManagement.CreateSave(SaveName.text);
    }
}
