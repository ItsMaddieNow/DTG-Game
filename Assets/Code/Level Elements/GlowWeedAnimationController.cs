using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowWeedAnimationController : MonoBehaviour
{
    public Animator ThisAnimator;
    public bool LightOn;
    
    // Start is called before the first frame update
    void Start()
    {
        ThisAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ThisAnimator.SetBool("Light On",LightOn);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ThisAnimator.SetBool("Player In Range",true);
        }
    }
}
