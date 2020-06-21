using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchExtinguish : MonoBehaviour
{
    public GameObject Flame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CompareTag("Water"))
        {
            Flame.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (CompareTag("Water"))
        {
            Flame.SetActive(true);
        }
    }
}
