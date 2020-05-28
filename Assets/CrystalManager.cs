//using System;
//using System.Collections;
//using System.Collections.Generic;

using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CrystalManager : MonoBehaviour
{
    public GameObject ParticleBurst;
    private Animator CrystalAnimator;
    // Start is called before the first frame update
    
    void Start()
    {
        CrystalAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }

    public void CreateParticleBurst()
    {
        Instantiate(ParticleBurst);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            CrystalAnimator.SetBool("Destroying", true);
            print("Heck2");
        }
        print("Heck");
    }
}
