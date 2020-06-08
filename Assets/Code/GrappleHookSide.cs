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
    
    // Start is called before the first frame update
    void Start()
    {
        Rb.AddForce(-Direction * InitialForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        RopeRenderer.SetPosition(0, transform.position);
    }

    private void OnCollisionEnter2D(Collision2D CollisionInfo)
    {
        if (!CollisionInfo.collider.CompareTag("Player") && !CollisionInfo.collider.CompareTag("Hook"))
        {
            Rb.bodyType = RigidbodyType2D.Static;
            PlayerScript.HookLatched = true;
            PlayerScript.Link(Rb);
        }
    }

    private void OnDestroy()
    {
        PlayerScript.HookPresent = false;
        PlayerScript.HookLatched = false;
    }
}
