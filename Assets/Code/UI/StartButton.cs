using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    //Called when button is pressed 
    public void StartGame()
    {
        print("Hello world Welcome to the game");
        SceneManager.LoadScene("Scene",  LoadSceneMode.Single);
    }
}
