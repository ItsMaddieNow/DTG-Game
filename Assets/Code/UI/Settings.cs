using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    //Called when button is pressed 
    public void OpenSettings()
    {
        print("Hello world Welcome to the game");
        SceneManager.LoadScene("settings", LoadSceneMode.Single);
    }
}