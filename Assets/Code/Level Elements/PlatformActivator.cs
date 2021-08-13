using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BezierSolution;

public class PlatformActivator : MonoBehaviour
{
    [SerializeField]
    private BezierWalkerWithSpeed Walker;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Walker.spline[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        print("Collission Detected");
        if(other.gameObject.CompareTag("Hook")){
            print("Hook Collided");
            Walker.enabled = true;
        }
    }
}
