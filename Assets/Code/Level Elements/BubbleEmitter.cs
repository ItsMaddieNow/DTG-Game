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
            Instantiate(BubblePrefab).transform.position = transform.position;
        }
        BubbleEmitted = Timer >= TimeBetweenBubbles ? false : BubbleEmitted;
        Timer = Timer >= TimeBetweenBubbles ? Timer -= TimeBetweenBubbles : Timer;
    }
}
