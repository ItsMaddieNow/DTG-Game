using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LavaController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TilemapRenderer[] renderers = GetComponentsInChildren<TilemapRenderer>();
        foreach (TilemapRenderer renderer in renderers) {
            renderer.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
