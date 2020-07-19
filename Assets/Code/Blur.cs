using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Blur : MonoBehaviour
{
    [SerializeField] private Volume ThisVolume;
    public bool Blurred;
    public float UnblurredApeture = 32f;
    public float BlurredApeture = 1f;
    public float BlurRate=1f;
    //private float CurrentApeture;
    [Range(1, 32)] public float Interpolation;
    
    private DepthOfField ThisDepthOfField;
    // Start is called before the first frame update
    void Start()
    {
        ThisVolume.profile.TryGet(out ThisDepthOfField);
    }

    // Update is called once per frame
    void Update()
    {
        Blurred = PauseMenu.GameIsPaused;
        if (Blurred)
        {
            ThisDepthOfField.aperture.value = Mathf.Lerp(ThisDepthOfField.aperture.value, BlurredApeture, BlurRate/Mathf.Abs(ThisDepthOfField.aperture.value - BlurredApeture)*Time.unscaledDeltaTime);
        }
        else
        {
            ThisDepthOfField.aperture.value = Mathf.Lerp(ThisDepthOfField.aperture.value, UnblurredApeture, BlurRate/Mathf.Abs(ThisDepthOfField.aperture.value - UnblurredApeture)*Time.unscaledDeltaTime);
        }
        
    }
}
