using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHookSide : MonoBehaviour
{
    public Rigidbody2D Rb;
    public GrapplePlayerSide PlayerScript;
    [SerializeField]
    private float InitialForce = 20f;
    public Vector2 Direction;
    public LineRenderer RopeRenderer;
    //Position Syncing
    public bool HookIsLatched;
    private Vector3 PositionOffset;
    private Transform ToFollow;


    // Start is called before the first frame update
    void Start()
    {
        Rb.AddForce(-Direction * InitialForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        RopeRenderer.SetPosition(0, transform.position);
        if (HookIsLatched){
            transform.position = ToFollow.position + PositionOffset;
        }
    }

    private void OnCollisionEnter2D(Collision2D CollisionInfo)
    {
        if (!CollisionInfo.collider.CompareTag("Player") && !CollisionInfo.collider.CompareTag("Hook"))
        {
            Rb.bodyType = RigidbodyType2D.Static;
            PlayerScript.HookLatched = true;
            PlayerScript.Link(Rb);

            //Position Syncing
            ToFollow = CollisionInfo.transform;
            HookIsLatched = true;
            PositionOffset = transform.position - ToFollow.position;
        }
    }

    private void OnDestroy()
    {
        PlayerScript.HookPresent = false;
        PlayerScript.HookLatched = false;
    }
}
