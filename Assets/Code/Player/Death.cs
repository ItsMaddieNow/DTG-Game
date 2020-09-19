using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Hazard")){
            DeathEvent(other.GetComponent<Hazard>().HazardType);
        }
    }
    public void DeathEvent(string CauseOfDeath){
        switch (CauseOfDeath)
            {
                case "Spikes":
                    print("You got pricked by some pricks ya prick");
                    break;
                default:
                    print("Undefined Death of Type\""+ CauseOfDeath + "\" ");
                    break;
            }
    }
}
