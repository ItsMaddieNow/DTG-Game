using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevTools : MonoBehaviour
{
    [SerializeField]bool AllTools;
    // Start is called before the first frame update
    void Start()
    {
        if (AllTools)
        {
            PlayerAbilities.TorchAvaliable = true;
            PlayerAbilities.GrapplingHookAvaliable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
