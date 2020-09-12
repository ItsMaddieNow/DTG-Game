using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float MaxHeight = 1;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y>=MaxHeight){
            Destroy(this.gameObject);
        }
    }
    
}
