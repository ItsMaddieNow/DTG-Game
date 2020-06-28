using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLock : MonoBehaviour
{
    private Quaternion Rotation;
    
    // Start is called before the first frame update
    void Awake()
    {
        Rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Rotation;
    }
}
