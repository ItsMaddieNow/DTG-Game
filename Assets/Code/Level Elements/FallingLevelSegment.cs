using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingLevelSegment : MonoBehaviour
{
    public Vector2 FallTo;
    public float FallSpeed = 1;
    public bool Falling = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")&!Falling){
            SegmentFall SF = gameObject.AddComponent<SegmentFall>() as SegmentFall;
            SF.FallSpeed=FallSpeed;
            SF.FallTo=FallTo;
            Falling=true;
        }
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, FallTo);
    }
}
