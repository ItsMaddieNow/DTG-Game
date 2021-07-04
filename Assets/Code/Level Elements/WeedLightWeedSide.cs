using System.Collections;
using UnityEngine;


public class WeedLightWeedSide : MonoBehaviour
{
    public float MaxDistance = 20f;
    public bool Glowing = false;
    public struct MessageInfo
    {
        public Vector2 Position;
        public float CurrentDistance;
        public MessageInfo (Vector2 position, float currentDistance){
            Position = position;
            CurrentDistance = currentDistance;
        }
    }
    void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        if (other.CompareTag("Player")&&!Glowing)
        {
            Glowing = true;
            print("Collision Detected");
            StartCoroutine("GlowBroadcast", new Vector2(other.transform.position.x,other.transform.position.y));    
        }
    }
    IEnumerator GlowBroadcast(Vector2 CollisionPoint)
    {
        for (float CurrentDistance = 0;CurrentDistance < MaxDistance;CurrentDistance+=Time.deltaTime)
        {
            gameObject.BroadcastMessage("GlowEvaluate",new MessageInfo(CollisionPoint,CurrentDistance));
            yield return null;
        }
        yield break;
    }
    
}
