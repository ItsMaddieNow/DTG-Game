using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public float TransitionTime = 0.5f;
    public Volume MyVolume;
    [SerializeField] private DepthOfField MyDepthOfField;
    [SerializeField] private CanvasGroup CG;


    [Header("Player Data")]
    public static PlayerCollection PC;


    // Start is called before the first frame update
    void Start()
    {
        DepthOfField tmp;
        if(MyVolume.profile.TryGet<DepthOfField>( out tmp )){
            MyDepthOfField = tmp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseCall(InputAction.CallbackContext context)
    {
        if(context.started){
            if (GameIsPaused)
            {
                GameIsPaused = false;
                print("Resuming");
                StartCoroutine("Resume");
                
            }
            else
            {
                GameIsPaused = true;
                print("pausing");
                StartCoroutine("Pause");
                
            }
        }
    }

    IEnumerator Resume()
    {
        CG.interactable = false;
        float ResumePoint = Time.unscaledTime + TransitionTime;
        while(ResumePoint > Time.unscaledTime)
        {
            float LV = (ResumePoint - Time.unscaledTime)/TransitionTime;
            CG.alpha = Mathf.Lerp(0,1,LV);
            MyDepthOfField.focalLength.value = Mathf.Lerp(1f,64f,LV);
            yield return null;
        }
        Time.timeScale = 1f;
        CG.alpha=0;
        print("Resumed");
        yield break;
    }
    IEnumerator Pause()
    {
        GameIsPaused = true;
        CG.interactable = true;
        float PausePoint = Time.unscaledTime + TransitionTime;
        Time.timeScale = 0f;
        while(PausePoint > Time.unscaledTime)
        {
            float LV = (PausePoint - Time.unscaledTime)/TransitionTime;
            CG.alpha = Mathf.Lerp(1,0,LV);
            MyDepthOfField.focalLength.value = Mathf.Lerp(64f,1f,LV);
            yield return null;
        }
        CG.alpha=1;
        print("Paused");
        yield break;
    }
}