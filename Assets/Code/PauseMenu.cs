using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

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
        LeanTween.init();
        //Starting Input
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
        //Background transparency
        LeanTween.alpha(PauseMenuRectTransform, 0f, TransitionTime).setIgnoreTimeScale(true);
        //Button transparency
        LeanTween.alpha(OpaqueRectTransform, 0f, TransitionTime).setIgnoreTimeScale(true).setOnComplete(OnResumeComplete);
    }

    void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
        UIContainer.SetActive(true);
        //Background transparency
        LeanTween.alpha(PauseMenuRectTransform, 100f/255f, TransitionTime).setIgnoreTimeScale(true);
        //Button transparency
        LeanTween.alpha(OpaqueRectTransform, 1f, TransitionTime).setIgnoreTimeScale(true).setOnComplete(OnPauseComplete);
    }

    void OnPauseComplete()
    {
        
    }

    void OnResumeComplete()
    {
        UIContainer.SetActive(false);
        Time.timeScale = 1f;
    }
    
    private void OnEnable()
    {
        //Enables The Input WHen This Script is Enabled
        Controls.Enable();
    }
    private void OnDisable()
    {
        //Disables The Input WHen This Script is Disabled
        Controls.Disable();
    }

    void TweenAlpha(Color TweenColor, float To)
    {
        //float a = AlphaValue;
        DOTween.ToAlpha(() => TweenColor, x => TweenColor = x, To, TransitionTime);
    }
    
}
