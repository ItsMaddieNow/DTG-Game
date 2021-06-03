using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string SceneName)
    {
        print("Loading Scene \"" + SceneName+ "\"");
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
    }
}
