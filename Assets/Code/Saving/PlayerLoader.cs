using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    // Loads all player Data Loaded in Save Management by function Load
    void Start()
    {
        transform.position = new Vector2(SaveManagement.saveData.Position[0],SaveManagement.saveData.Position[1]);
        print("Loaded Player Position : [" + SaveManagement.saveData.Position[0] + "," + SaveManagement.saveData.Position[1] + "]");
    }

    // Update is called once per frame
    void Update()
    {

    }
}