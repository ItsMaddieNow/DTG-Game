using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BezierSolution;

public class LavaRiser : MonoBehaviour
{
    [SerializeField]
    private BezierWalkerWithSpeed Walker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        print("Collission Detected");
        if(other.gameObject.CompareTag("Player")){
            print("Lava Triggered");
            Walker.enabled = true;
        }
    }
}
