using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSaveStateUpdater : MonoBehaviour
{
    public LavaManager.LavaState state;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        SaveManagement.saveData.lavaState = state;
    }
}
