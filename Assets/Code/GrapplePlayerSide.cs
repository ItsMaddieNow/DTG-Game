using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrapplePlayerSide : MonoBehaviour
{
    public string CurrentItem;
    public PlayerMovement PlayerMovementScript;
    
    public Vector2 GrappleDirection;
    [SerializeField]
    private Vector2 GrappleGunDirection;
    
    public float GrappleGunSmoothing = 5f;
    private bool CanGrapple;
    private PlayerControls Controls;

    [Header("Grappling Gun")]
    public GameObject GrapplingGun;
    [SerializeField]
    public Vector2 GunPositionWarp;
    
    [Header("Hook")] 
    public GameObject HookSpawn;
    public GameObject Hook;
    [SerializeField]
    private GameObject SpawnedHook;
    public bool HookPresent;
    public bool HookLatched;
    private GrappleHookSide GrappleHookSideScript;
    private DistanceJoint2D Line;
    public float CoilRate = 1f;
    
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

    private void Awake()
    {
        Line = this.GetComponent<DistanceJoint2D>();
        Cam = Camera.main;
        Controls = new PlayerControls();
        Controls.Gameplay.Enable();
        PlayerMovementScript = this.GetComponent<PlayerMovement>();
        
        Controls.Gameplay.GrappleButton.performed += ctx => Grapple();
        Controls.Gameplay.GrappleToggle.performed += ctx => GrappleToggle();
        Controls.Gameplay.GrappleDirection.performed += OnMouseMoved;
        
        Controls.Gameplay.GrappleDistanceControl.performed += ctx => DistanceModifier = ctx.ReadValue<float>();
        Controls.Gameplay.GrappleDistanceControl.canceled += ctx => DistanceModifier = 0f;

        Controls.Gameplay.TorchEnable.performed += ctx => TorchEnable();
        Controls.Gameplay.TorchThrow.performed += ctx => TorchThrow();
    }

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TorchContainer.transform.eulerAngles = Vector3.zero;
        Torch.SetActive(CurrentItem == "Torch");

        if (CurrentItem == "Torch")
        {
            Torch.transform.position = Vector2.Lerp(Torch.transform.position, TorchAnchor.transform.position, TorchSmoothing/Vector2.Distance(Torch.transform.position, TorchAnchor.transform.position)*Time.deltaTime);
            Torch.transform.eulerAngles = new Vector3(0, 0, Mathf.Lerp(-30f,30f, Mathf.InverseLerp(TorchAnchor.transform.localPosition.x, -TorchAnchor.transform.localPosition.x, Torch.transform.localPosition.x)));
        }
        
        GrapplingGun.SetActive(CurrentItem == "Grappling Hook");
        RopeRenderer.enabled = HookPresent;
        HookSpawn.GetComponent<SpriteRenderer>().enabled = !HookPresent;
        
        //grapple gun direction
        GrappleDirection = transform.position - Cam.ScreenToWorldPoint(Controls.Gameplay.GrappleDirection.ReadValue<Vector2>());
        
        
        GrappleGunDirection = Vector2.Lerp(GrappleGunDirection, new Vector2(GrappleDirection.x, Mathf.Abs(GrappleDirection.y)).normalized, GrappleGunSmoothing/Vector2.Distance(GrappleGunDirection, (new Vector2(GrappleDirection.x, Mathf.Abs(GrappleDirection.y))).normalized * Time.deltaTime));
        if (PlayerMovementScript.FacingRight)
        {
            GrapplingGun.transform.localPosition = new Vector2(-GrappleGunDirection.x, GrappleGunDirection.y) * GunPositionWarp;
        }
        else
        {
            GrapplingGun.transform.localPosition = GrappleGunDirection * GunPositionWarp;
        }
        
        GrapplingGun.transform.rotation = Quaternion.Euler(0, (GrappleDirection.x<0) ? 0:180,Mathf.Rad2Deg * Mathf.Atan2((GrappleGunDirection * GunPositionWarp).y,(((GrappleDirection.x<0) ? -GrappleGunDirection:GrappleGunDirection) * GunPositionWarp).x));
            
        RopeRenderer.SetPosition(1, HookSpawn.transform.position);
        if (!HookPresent)
        {
            Line.enabled = false;
        }

        Line.anchor = HookSpawn.transform.position - transform.position;    
        Line.distance -= DistanceModifier * CoilRate * Time.deltaTime;
        
        Line.distance = Mathf.Clamp(Line.distance, MinDistance, MaxDistance);
        
        
        if (HookPresent && Vector2.Distance(HookSpawn.transform.position, SpawnedHook.transform.position) > MaxDistance & !HookLatched)
        {
            Destroy(SpawnedHook);
        }
    }
    void Grapple()
    {
        if (CurrentItem == "Grappling Hook")
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

    void GrappleToggle()
    {
        if (CurrentItem == "Grappling Hook")
        {
            Destroy(SpawnedHook);

            CurrentItem = null;
        }
        else
        {
            CurrentItem = "Grappling Hook";
        }
    }

    void TorchEnable()
    {
        if (CurrentItem == "Torch")
        {
            CurrentItem = null;
        }
        else
        {
            CurrentItem = "Torch";
            Torch.SetActive(true);
            Torch.transform.position = TorchAnchor.transform.position;
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

    private void TorchThrow()
    {
        
    }
    
    private void OnMouseMoved(InputAction.CallbackContext context)
    {
        //callback
        //Debug.Log(context.ReadValue<Vector2>());
    }
}
