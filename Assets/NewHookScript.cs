using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHookScript : MonoBehaviour
{
    public Rigidbody2D rb;

    public GrapplePlus DeployedFrom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Terrain"))
        {
            rb.bodyType = RigidbodyType2D.Static;
            DeployedFrom.HookIsLatched = true;
        }
    }
}
