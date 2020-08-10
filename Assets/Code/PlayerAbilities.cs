using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    [Header("Controls")]
    private PlayerControls Controls;
    private Camera Cam;
    [Header("Grappling Hook")]
    public float HookLaunchSpeed = 20f;
    public Vector2 GrappleDirection;
    public LayerMask LatchableLayers;
    public float MaxLength = 20f;
    public float DeploySpeed = 20f;
    private Vector2 Target;
    //Hook States
    public bool ReachedTarget;
    private bool HookLaunched;
    public bool HookIsLatched;

    [Header("Grappling Line Setting")]
    public float LineLength;
    public float LineDensity = 0.5f;
    private float LengthNoHook;
    private float ClosestLinkLength;
    private int NumberOfLinks;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Controls need to be started in awake or warnings will occur
    void Awake()
    {
        Controls = new PlayerControls();
        Controls.Gameplay.Enable();
        Controls.Gameplay.GrappleDistanceControl.performed += ctx => LineLength += ctx.ReadValue<float>();
        Controls.Gameplay.GrappleDistanceControl.canceled += ctx => LineLength += 0f;
        Controls.Gameplay.GrappleButton.performed += ctx => NewGrappleToggle();
    }
    private void OnEnable()
    {
        Controls.Enable();
    }

    private void OnDisable()
    {
        Controls.Disable();
    }
}
