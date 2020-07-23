using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePlus : MonoBehaviour
{
    public float LineLength;
    public float LineDensity = 0.5f;
    private float LengthNoHook;
    public float ClosestLinkLength;
    public float NumberOfLinks;
    public LinkData[] Links;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LengthNoHook = LineLength - LineDensity;
        ClosestLinkLength = LineLength % LineDensity;
        NumberOfLinks = Mathf.Max(Mathf.FloorToInt((LengthNoHook - ClosestLinkLength) / LineDensity),0);
        //Links[Mathf.FloorToInt((LengthNoHook) / LineDensity)];
    }
}
