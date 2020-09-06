using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class CrystalController : MonoBehaviour
{
    public GameObject ParticleBurst;
    private ParticleSystem CreatedParticleBurst;
    private bool Created = false;
    
    private Animator Ani;
    // Start is called before the first frame update
    void Start()
    {
        Ani = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateParticleBurst()
    {
        if (!Created)
        {
            Created = true;
            CreatedParticleBurst = Instantiate(ParticleBurst, this.transform.position, this.transform.rotation).GetComponent<ParticleSystem>();
        }
    }

    public void DestroyThis()
    {
        CreatedParticleBurst.Stop();
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Ani.SetBool("Destroying", true);
    }
}
