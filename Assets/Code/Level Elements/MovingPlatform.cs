using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private float Timer;
    [Range(0,1)]
    public float Offset;
    public float Speed;
    public bool Moving = true;
    public Vector3 FirstPos;
    public Vector3 SecondPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Moving){
            Timer += Time.deltaTime*Speed/Vector3.Distance(FirstPos, SecondPos);
        }
        transform.position = Vector3.Lerp(FirstPos, SecondPos, Mathf.PingPong(Timer + Offset,1));
    }
    
}
