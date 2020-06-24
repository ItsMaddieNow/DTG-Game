using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

//[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Light2D))]
public class LightController : MonoBehaviour
{
    
    //public Animator ThisAnimator;
    public Light2D ThisLight;
    public int BodiesOfWater = 0;
    [SerializeField] private float MinLight = 0;
    [SerializeField] private float MaxLight = 0.5f;
    [SerializeField] private float ChangeSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        ThisLight = this.GetComponent<Light2D>();
        //ThisAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BodiesOfWater > 0)
        {
            ThisLight.intensity = Mathf.Lerp(ThisLight.intensity, MinLight, ChangeSpeed/Mathf.Abs(ThisLight.intensity - MinLight) * Time.deltaTime);
        }
        else
        {
            ThisLight.intensity = Mathf.Lerp(ThisLight.intensity, MaxLight, ChangeSpeed/Mathf.Abs(ThisLight.intensity - MaxLight) * Time.deltaTime);
        }
        
        //ThisAnimator.SetBool("Dark", (BodiesOfWater>0));
    }
}
