using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformActivator : MonoBehaviour
{
    private MovingPlatform Platform;
    // Start is called before the first frame update
    void Start()
    {
        Platform = GetComponent<MovingPlatform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Hook")){
            Platform.Moving = true;
        }
    }
}
