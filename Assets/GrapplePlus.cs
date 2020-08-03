using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrapplePlus : MonoBehaviour
{
    [Header("Controls")]
    private PlayerControls Controls;
    private Vector2 GrappleDirection;
    private Camera Cam;
    
    [Header("Line Settings")] public float LineLength;
    public float LineDensity = 0.5f;
    private float LengthNoHook;
    private float ClosestLinkLength;
    private int NumberOfLinks;
    [SerializeField]private float InitialLinkLeeway;
    [SerializeField]private float DeltaLinkLeewayMultiplier;

    [Header("Rope")]
    [SerializeField] private GameObject HookPrefab;
    private Rigidbody2D DeployedHookRB;
    private bool HookDeployed = false;
    
    [SerializeField] private LineRenderer RopeRenderer;
    [SerializeField] private GameObject LinkPrefab;
    public LinkData[] Links;
    private Vector3[] LineRendererPoints = new Vector3[1];
    public Transform LinkSpawnPoint;
    [SerializeField] private DistanceJoint2D SpawnPointJoint;
    public bool HookIsLatched;

        // Start is called before the first frame update
    void Start()
    {
        RopeRenderer.enabled = false;
        //Temporary Init
        StartGrapple();
        //Initialization
        Cam = Camera.main;
        SpawnPointJoint = LinkSpawnPoint.GetComponent<DistanceJoint2D>();
        Controls = new PlayerControls();
        Controls.Gameplay.Enable();
        
        Controls.Gameplay.GrappleDistanceControl.performed += ctx => LineLength += ctx.ReadValue<float>();
        Controls.Gameplay.GrappleDistanceControl.canceled += ctx => LineLength += 0f;
        Controls.Gameplay.GrappleButton.performed += ctx => GrappleToggle();
        //Controls.Gameplay.GrappleDirection.performed += OnMouseMoved;
    }

    // Update is called once per frame
    void Update()
    {
        if (!HookIsLatched)
        {
            FlyingLineDistanceCalculator();
        }
        if (HookDeployed)
        {
            //Line Length Calculations
            LineLength=Mathf.Max(LineLength, 0);
            GrappleDirection  = transform.position - Cam.ScreenToWorldPoint(Controls.Gameplay.GrappleDirection.ReadValue<Vector2>());
            //Debug.Log(GrappleDirection);
            SpawnPointJoint.enabled = HookDeployed;
            LengthNoHook = LineLength;
            ClosestLinkLength = LineLength % LineDensity;
            NumberOfLinks = Mathf.Max(Mathf.FloorToInt((LengthNoHook - ClosestLinkLength) / LineDensity),0);
            SpawnPointJoint.distance = ClosestLinkLength;
        }

        //Debug.Log(NumberOfLinks + ", " + Links.Length);
        if (NumberOfLinks > Links.Length)
        {
            NewLink();
        }
        else if (NumberOfLinks <= Links.Length)
        {
            RemoveLink();
        }
        LineCompose();
    }

    private void GrappleToggle()
    {
        if (HookDeployed)
        {
            EndGrapple();
        }
        else
        {
            StartGrapple();
        }
    }
    
    private void StartGrapple()
    {
        //creates hook
        DeployedHookRB = Instantiate(HookPrefab).GetComponent<Rigidbody2D>();
        //amkes space for hook to move
        LineLength = InitialLinkLeeway;
        //adds force to hook
        DeployedHookRB.AddForce(GrappleDirection, ForceMode2D.Impulse);
        //configures the distance joint
        SpawnPointJoint.enabled = true;
        SpawnPointJoint.connectedBody = DeployedHookRB;
        //sets the first point of the line renderer to the spawn point of the hook
        LineRendererPoints[0] = DeployedHookRB.transform.position;
        //enables the line renderer
        RopeRenderer.enabled = true;
        //declares that the hook is active
        HookDeployed = true;
    }
    
    private void EndGrapple()
    {
        //Triggers when a player terminates a grapple
        foreach (var LinkData in Links)
        {
            Destroy(Links[0].gameObject,0);
        }
        Destroy(DeployedHookRB.gameObject);
        SpawnPointJoint.enabled = false;
        HookDeployed = false;
        RopeRenderer.enabled = false;
        LineLength = 0;
    }
    
    private void NewLink()
    {
        int FilledLinks = Links.Length;
        Array.Resize(ref Links, NumberOfLinks);
        Array.Resize(ref LineRendererPoints, NumberOfLinks+2);
        //for every missing link create a new link
        for (int i = FilledLinks; i < NumberOfLinks; i++)
        {
            GameObject CurrentLink = Instantiate(LinkPrefab);
            CurrentLink.transform.position = LinkSpawnPoint.transform.position;
            Links[i] = CurrentLink.GetComponent<LinkData>();
            LineRendererPoints[i + 1] = CurrentLink.transform.position;
            Links[i].LinkJoint.connectedBody = 0 > i-1 ? DeployedHookRB : Links[i - 1].LinkRB;
            Links[i].LinkJoint.distance = LineDensity;
        }
        
        LineRendererPoints[NumberOfLinks + 1] = SpawnPointJoint.transform.position;
        SpawnPointJoint.connectedBody = Links[Links.Length-1].LinkRB;
        //Debug.Log(Links.Length + ", " + Links[Links.Length - 1].LinkRB);

        HookIsLatched = false;
    }

    private void RemoveLink()
    {
        for (int i = Links.Length; i > NumberOfLinks; i--)
        {
            //Debug.Log("Destroyed Object (" + Links[Links.Length - 1] + ")");
            Destroy(Links[i - 1].gameObject);
        }
        Array.Resize(ref Links, NumberOfLinks);
        SpawnPointJoint.connectedBody = (0 == NumberOfLinks) ? DeployedHookRB : Links[Links.Length-1].LinkRB;
    }
    // Composes an Array of Vector3s for use in the line renderer 
    private void LineCompose()
    {
        Array.Resize(ref LineRendererPoints, Links.Length+2);
        LineRendererPoints[0] = DeployedHookRB.transform.position;
        int i = 0;
        foreach (var LinkData in Links)
        {
            LineRendererPoints[i + 1] = Links[i].transform.position;
            i++;
        }
        LineRendererPoints[LineRendererPoints.Length - 1] = LinkSpawnPoint.position;
        RopeRenderer.positionCount = LineRendererPoints.Length;
        RopeRenderer.SetPositions(LineRendererPoints);
    }

    private void FlyingLineDistanceCalculator()
    {
        float CurrentLineDistance;
        for (int i = 0; i < Links.Length ;i++)
        {
            //CurrentLineDistance += Vector2.Distance((i <= 0) ? LinkSpawnPoint.transform.position : Links[i - 1].transform.position , (i >= Links.Length) ? DeployedHookRB.transform.position : Links[i].transform.position);
            Debug.Log("Calculating distance between" + ((i <= 0) ? LinkSpawnPoint.transform.position : Links[i - 1].transform.position) + "and" + ((i >= Links.Length) ? DeployedHookRB.transform.position : Links[i].transform.position));
        }
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
