using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    private PlayerControls Controls;
    public GameObject PauseMenuUI;
    public RectTransform PauseMenuRectTransform;
    
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
        GameIsPaused = false;
        LeanTween.alpha(PauseMenuRectTransform, 0f, 1f).setOnComplete(OnResumeComplete);
    }

    void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
        PauseMenuUI.SetActive(true);
        LeanTween.alpha(PauseMenuRectTransform, 1f, 1f).setOnComplete(OnPauseComplete);
    }

    void OnPauseComplete()
    {
        
    }

    void OnResumeComplete()
    {
        Time.timeScale = 1f;
        PauseMenuUI.SetActive(false);
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
