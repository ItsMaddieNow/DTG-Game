using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentFall : MonoBehaviour {
    public Vector2 FallTo;
    public float FallSpeed;
    private void Update() {
        Vector2 pos = transform.position;
        transform.position = Vector2.Lerp(pos, FallTo, Time.deltaTime/Vector2.Distance(pos, FallTo)*FallSpeed);
    }
    /*public SegmentFall(Vector2 FallTo,float FallSpeed){
        this.FallTo = FallTo;
        this.FallSpeed = FallSpeed;
    }*/
}