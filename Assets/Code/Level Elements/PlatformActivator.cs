using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BezierSolution;

[RequireComponent(typeof(BezierWalkerWithSpeed))]
public class PlatformActivator : MonoBehaviour
{
    private BezierWalkerWithSpeed Walker;
    // Start is called before the first frame update
    void Start()
    {
        Walker = GetComponent<BezierWalkerWithSpeed>();
        transform.position = Walker.spline[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Hook")){
            Walker.enabled = true;
        }
    }
}
