using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchFlameController : MonoBehaviour
{
    public Fire ThisFire;

    public GameObject Flame;
    // Start is called before the first frame update
    void Start()
    {
        ThisFire = this.GetComponent<Fire>();
    }

    // Update is called once per frame
    void Update()
    {
        Flame.SetActive(ThisFire.CanCatchFire);
    }

}
