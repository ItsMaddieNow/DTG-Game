using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float PopDelay=1f;

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Water")){
            Destroy(this.gameObject, PopDelay);
        }
    }
}
