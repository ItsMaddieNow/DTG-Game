using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    private PlayerControls Controls;
    public GameObject UIContainer;
    public RectTransform PauseMenuRectTransform;
    public RectTransform OpaqueRectTransform;
    public float TransitionTime = 0.5f;
    
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
        Time.timeScale = 1f;
        GameIsPaused = false;
        LeanTween.alpha(PauseMenuRectTransform, 0f, TransitionTime).setOnComplete(OnResumeComplete);
        LeanTween.alpha(OpaqueRectTransform, 0f, TransitionTime);
    }

    void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
        UIContainer.SetActive(true);
        LeanTween.alpha(PauseMenuRectTransform, 1f, TransitionTime).setOnComplete(OnResumeComplete);
        LeanTween.alpha(OpaqueRectTransform, 1f, TransitionTime);
    }

    void OnPauseComplete()
    {
        
    }

    void OnResumeComplete()
    {
        
        UIContainer.SetActive(false);
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
