using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BezierSolution;

public class SwingSequenceActivator : MonoBehaviour
{
    public BezierWalkerWithSpeed LavaWalker;
    public BezierWalkerWithSpeed PlatformWalker;
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
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Hook") & SaveManagement.saveData.lavaState == LavaManager.LavaState.SwingingSubmerged){
            LavaWalker.enabled=true;
            PlatformWalker.enabled=true;
        }
    }
}
