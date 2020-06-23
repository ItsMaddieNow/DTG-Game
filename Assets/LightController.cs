using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LightController : MonoBehaviour
{
    
    public Animator ThisAnimator;
    public int BodiesOfWater = 0;
    // Start is called before the first frame update
    void Start()
    {
        ThisAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ThisAnimator.SetBool("Dark", (BodiesOfWater>0));
        Debug.Log(BodiesOfWater>0);
    }
}
