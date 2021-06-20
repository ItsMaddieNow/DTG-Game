using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilities : MonoBehaviour
{
    public Items CurrentItem;
    public PlayerMovement PlayerMovementScript;
    
    public Vector2 GrappleDirection;
    [SerializeField]
    private Vector2 GrappleGunDirection;
    
    public float GrappleGunSmoothing = 5f;
    private bool CanGrapple;

    [Header("Grappling Gun")]
    public GameObject GrapplingGun;
    [SerializeField]
    //public Vector2 GunPositionWarp;
    public float GunRadiusScale = 0.75f;
    public Vector2 EllipseDimensions = new Vector2(1,1);
    public Vector2 GunPosition;
    private Vector2 Target;
    
    [Header("Hook")] 
    public GameObject HookSpawn;
    public GameObject Hook;
    public float HookSpeed = 10f;
    [SerializeField]
    private GameObject SpawnedHook;
    public bool HookPresent;
    public bool HookLatched;
    //private NewHookScript GrappleHookSideScript;
    private GrappleHookSide GrappleHookSideScript;
    private DistanceJoint2D Line;
    public float CoilRate = 1f;
    private Vector2 MousePosition;
    private Rigidbody2D GrappleHookRB;
    
    //Hook States
    public bool ReachedTarget;
    public bool HookIsLatched;

    [Header("Hook Distance")]
    public float MaxDistance = 10f;
    public float MinDistance = 1.5f;
    [SerializeField]
    private float DistanceModifier;

    [Header("Line Renderer")]
    public LineRenderer RopeRenderer;
    private Vector3 LineRendererPoints;
    
    private Camera Cam;

    [Header("Torch")]
    public float TorchSmoothing = 1f;
    public GameObject Torch;
    public GameObject TorchAnchor;
    public GameObject TorchContainer;
    public GameObject Flame;
    [Header("Tools")]
    public static bool GrapplingHookAvaliable = false;
    public static bool TorchAvaliable = false;
    public enum Items
    {
        None = 0,
        GrapplingHook,
        Torch
    }
    private void Awake()
    {
        Line = this.GetComponent<DistanceJoint2D>();
        Cam = Camera.main;

        PlayerMovementScript = this.GetComponent<PlayerMovement>();
    }

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Torch
        TorchContainer.transform.eulerAngles = Vector3.zero;
        Torch.SetActive(CurrentItem == Items.Torch);
        //Setting Torch Position
        if (CurrentItem == Items.Torch)
        {
            Torch.transform.position = Vector2.Lerp(Torch.transform.position, TorchAnchor.transform.position, TorchSmoothing/Vector2.Distance(Torch.transform.position, TorchAnchor.transform.position)*Time.deltaTime);
            Torch.transform.eulerAngles = new Vector3(0, 0, Mathf.Lerp(-30f,30f, Mathf.InverseLerp(TorchAnchor.transform.localPosition.x, -TorchAnchor.transform.localPosition.x, Torch.transform.localPosition.x)));
        }
        
        //Grappling Hook
        GrapplingGun.SetActive(CurrentItem == Items.GrapplingHook);
        
        HookSpawn.GetComponent<SpriteRenderer>().enabled = !HookPresent;
        GrappleDirection = transform.position - Cam.ScreenToWorldPoint(MousePosition);
        Vector2 CursorToPlayer = Cam.ScreenToWorldPoint(MousePosition) - transform.position;
        //float tanc = Mathf.Tan(Vector2.Angle(transform.position, Cam.ScreenToWorldPoint(MousePosition))*Mathf.Deg2Rad);
        float tanc = 1/Mathf.Tan(Mathf.Atan2(transform.position.y-Cam.ScreenToWorldPoint(MousePosition).y,transform.position.x-Cam.ScreenToWorldPoint(MousePosition).x));
        float cotc = 1/tanc;
        GunPosition = new Vector2(
            (( CursorToPlayer.x < 0)? -1 : 1) * (PlayerMovementScript.FacingRight? 1 : -1) * (EllipseDimensions.x*EllipseDimensions.y/Mathf.Sqrt(EllipseDimensions.y*EllipseDimensions.y + EllipseDimensions.x*EllipseDimensions.x * cotc*cotc)),
            (( CursorToPlayer.y > 0)? 1 : -1) * (EllipseDimensions.x*EllipseDimensions.y/Mathf.Sqrt(EllipseDimensions.y*EllipseDimensions.y * tanc*tanc +EllipseDimensions.x*EllipseDimensions.x))
        );
        //print("Grapple Gun Angle Degrees: " + Vector2.Angle(transform.position, Cam.ScreenToWorldPoint(MousePosition)) + ", Radians: " + Vector2.Angle(transform.position, Cam.ScreenToWorldPoint(MousePosition))*Mathf.Deg2Rad);
        
        GrappleGunDirection = Vector2.Lerp(GrappleGunDirection, GunPosition, GrappleGunSmoothing/Vector2.Distance(GrappleGunDirection, GunPosition * Time.deltaTime));
        /*if (PlayerMovementScript.FacingRight)
        {
            GrapplingGun.transform.localPosition = new Vector2(-GrappleGunDirection.x, GrappleGunDirection.y) * GunRadiusScale;
        }
        else
        {
            GrapplingGun.transform.localPosition = GrappleGunDirection * GunRadiusScale;
        }*/
        GrapplingGun.transform.localPosition = GrappleGunDirection;
        
        GrapplingGun.transform.rotation = Quaternion.Euler(PlayerMovementScript.FacingRight?0:180, !(PlayerMovementScript.FacingRight ^ GrappleDirection.x<0) ? 0:180,(PlayerMovementScript.FacingRight? 1:-1) * Mathf.Rad2Deg * Mathf.Atan2((GrappleGunDirection * GunRadiusScale).y,(((GrappleDirection.x>0) ? -GrappleGunDirection:GrappleGunDirection) * GunRadiusScale).x));
        
        if (HookPresent)
        {
            Vector2 HookPos = SpawnedHook.transform.position;
            if(!ReachedTarget && !HookIsLatched){
                HookPos = Vector2.Lerp(SpawnedHook.transform.position, Target, HookSpeed / Vector2.Distance(HookPos, Target)*Time.deltaTime);
            } else if (!HookIsLatched) {
                Vector3 PointPos = HookSpawn.transform.position;
                HookPos = Vector2.Lerp(SpawnedHook.transform.position, PointPos, HookSpeed / Vector2.Distance(HookPos, PointPos)*Time.deltaTime);
            }

            SpawnedHook.transform.position = HookPos;
            if (HookPos == Target){
                ReachedTarget = true;
            }

            if (HookPos == new Vector2(HookSpawn.transform.position.x,HookSpawn.transform.position.y) && ReachedTarget)
            {
                Destroy(SpawnedHook);
                HookPresent = false;
            }
        }

        //Line Renderer
        RopeRenderer.enabled = HookPresent;
        RopeRenderer.SetPosition(1, HookSpawn.transform.position);
        if (!HookPresent)
        {
            Line.enabled = false;
        }
        Line.anchor = HookSpawn.transform.position - transform.position;    
        Line.distance -= DistanceModifier * CoilRate * Time.deltaTime;
        Line.distance = Mathf.Clamp(Line.distance, MinDistance, MaxDistance);
        
        //Destroy Hook if Goes Beyond Certain Distance if it Hasn't Latched Yet
        if (HookPresent && Vector2.Distance(HookSpawn.transform.position, SpawnedHook.transform.position) > MaxDistance & !HookLatched)
        {
            Destroy(SpawnedHook);
        }
    }
    public void Grapple()
    {
        if (CurrentItem == Items.GrapplingHook)
        {
            if (HookPresent == false)
            {
                //W.I.P.	
	            SpawnedHook = Instantiate(Hook, HookSpawn.transform.position,Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(-GrappleDirection.y, -GrappleDirection.x)));	
	            GrappleHookSideScript = SpawnedHook.GetComponent<GrappleHookSide>();	
	            GrappleHookSideScript.Direction = GrappleDirection;	
                GrappleHookSideScript.PlayerScript = this;	
	            GrappleHookSideScript.RopeRenderer = RopeRenderer;
                HookPresent = true;
            }
            else
            {
                Destroy(SpawnedHook);
            }
        }
    }

    public void GrappleToggle(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            if (CurrentItem == Items.GrapplingHook)
            {
                CurrentItem = Items.None;
                ItemSwitchCleanup();
            }
            else if(GrapplingHookAvaliable)
            {
                CurrentItem = Items.GrapplingHook;
                ItemSwitchCleanup();
            }
        }
    }

    public void TorchEnable()
    {
        if (!PauseMenu.GameIsPaused){
            if (CurrentItem == Items.Torch)
            {
                CurrentItem = Items.None;
                ItemSwitchCleanup();
            }
            else if(TorchAvaliable)
            {
                CurrentItem = Items.Torch;
                ItemSwitchCleanup();
                Torch.SetActive(true);
                //Flame.SetActive();
                Torch.transform.position = TorchAnchor.transform.position;
            }
        }
    }

    public void Link(Rigidbody2D Hook)
    {
        Line.enabled = true;
        if (Hook != null)
        {
            Line.connectedBody = Hook;
            Line.anchor = HookSpawn.transform.position - transform.position;
            Line.distance = Vector2.Distance(HookSpawn.transform.position, Hook.transform.position);
        }
    }

    public void TorchThrow()
    {
        
    }
    
    public void OnMouseMoved(InputAction.CallbackContext context)
    {
        MousePosition = context.ReadValue<Vector2>();
    }

    private void ItemSwitchCleanup()
    {
        if (CurrentItem != Items.GrapplingHook)
        {
            Destroy(SpawnedHook);
        }
        RopeRenderer.enabled = HookPresent;
    }

    public void GrappleDistanceControl(InputAction.CallbackContext context)
    {
        DistanceModifier = context.ReadValue<float>();
    }
}
