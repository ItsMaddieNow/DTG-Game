using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BezierSolution;

public class LavaRiser : MonoBehaviour
{
    [SerializeField]
    private BezierWalkerWithSpeed Walker;
    [SerializeField]
    private LavaManager lavaManager;
    
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
        //print(SaveManagement.saveData.lavaState);
        if(other.gameObject.CompareTag("Player") & SaveManagement.saveData.lavaState == LavaManager.LavaState.Start){
            print("Lava Triggered");
            Walker.enabled = true;
        }
    }
}
