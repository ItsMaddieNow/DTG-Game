using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLevelLoad : MonoBehaviour
{
    public string LevelName;
    public AsyncOperation Progress;
    [SerializeField] LevelLoadingBar LoadingBar;
    [SerializeField] GameObject LoadingScreen;
    // Start is called before the first frame update
    void Start()
    {
        print("Started Load");
        // Loading Level In Background
        Progress = SceneManager.LoadSceneAsync(LevelName);
        Progress.completed += (op) => print("Level Loaded");
        Progress.allowSceneActivation = false;
    }
    public void LoadLevel(){
        //Reveal Loading Screen
        LoadingScreen.SetActive(true);
        print("Level Deployed");
        LoadingBar.Progress = Progress;
        Progress.allowSceneActivation = true;
    }
}
