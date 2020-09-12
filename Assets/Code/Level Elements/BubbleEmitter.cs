using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleEmitter : MonoBehaviour
{
    public GameObject BubblePrefab;
    public float Timer;
    public float TimeToGrow=1;
    public float TimeBetweenBubbles = 3;
    private bool BubbleEmitted;
    public SpriteRenderer ThisSpriteRenderer;

    public float MaxHeight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        float Scale = Timer/TimeToGrow;
        transform.localScale = new Vector2(Scale,Scale);
        ThisSpriteRenderer.enabled = Timer <= TimeToGrow;
        if(Timer >= TimeToGrow & !BubbleEmitted){
            BubbleEmitted = true;
            GameObject NewBubble = Instantiate(BubblePrefab);
            NewBubble.transform.position = transform.position;
            NewBubble.GetComponent<Bubble>().MaxHeight=MaxHeight;
        }
        BubbleEmitted = Timer >= TimeBetweenBubbles ? false : BubbleEmitted;
        Timer = Timer >= TimeBetweenBubbles ? Timer -= TimeBetweenBubbles : Timer;
    }
    
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Vector3 pos = transform.position;
        Gizmos.DrawWireSphere(new Vector3(pos.x,MaxHeight,pos.z),1);
    }
}
