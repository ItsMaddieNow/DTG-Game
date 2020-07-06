using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    private PlayerControls Controls;
    public GameObject PauseMenuUI;
    
    // Start is called before the first frame update
    void Awake()
    {
        Controls = new PlayerControls();
        Controls.Gameplay.Pause.started += ctx => PauseCall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PauseCall()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    private void OnEnable()
    {
        Controls.Enable();
    }
    private void OnDisable()
    {
        Controls.Disable();
    }
}
