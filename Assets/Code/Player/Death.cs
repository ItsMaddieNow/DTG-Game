using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public static bool TurtleSavingIsAHobby=false;
    public enum DeathCauses
    {
        Spikes,
        Water,
        Lava
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        /*if (other.gameObject.CompareTag("Hazard")){
            DeathEvent(other.GetComponent<Hazard>().HazardType);
        } else if (other.gameObject.CompareTag("Water")) {
             
        }*/
        switch (other.gameObject.tag)
        {
            case "Hazard":
                DeathEvent(other.GetComponent<Hazard>().HazardType);
                return;
            case "Water":
                if (TurtleSavingIsAHobby){
                    DeathEvent(DeathCauses.Water);
                }
                return;
            default:
                return; 
        }
    }
    public void DeathEvent(DeathCauses CauseOfDeath){
        switch (CauseOfDeath)
            {
                case DeathCauses.Spikes:
                    print("You got pricked by some pricks ya prick");
                    break;
                case DeathCauses.Water:
                    print("Turtle Saving Is A Hobby");
                    break;
                case DeathCauses.Lava:
                    print("You were burnt to a crisp");
                    break;
                default:
                    print("Undefined Death of Type\""+ CauseOfDeath + "\" ");
                    break;
            }
        SceneManager.LoadScene("scene");
    }
   
}
