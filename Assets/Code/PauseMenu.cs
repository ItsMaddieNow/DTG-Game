using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    private PlayerControls Controls;
    public GameObject UIContainer;
    public RectTransform PauseMenuRectTransform;
    public RectTransform OpaqueRectTransform;
    public float TransitionTime = 0.5f;
    public Volume MyVolume;
    [SerializeField] private DepthOfField MyDepthOfField;

    // Start is called before the first frame update
    void Awake()
    {
        MyVolume.profile.TryGet(out MyDepthOfField);
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
        LeanTween.value(gameObject,MyDepthOfField.aperture.value,32f,TransitionTime).setIgnoreTimeScale(true)
            .setOnUpdate((float val) =>
            {
                MyDepthOfField.aperture.value = val;
            });
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
        LeanTween.value(MyDepthOfField.aperture.value, 1f, TransitionTime).setIgnoreTimeScale(true)
            .setOnUpdate((float val) =>
            {
                MyDepthOfField.aperture.value = val;
            });
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
}
