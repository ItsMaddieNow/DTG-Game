using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrapplePlus : MonoBehaviour
{
    [Header("Controls")] 
    private PlayerControls Controls;
    public Vector2 GrappleDirection;
    private Camera Cam;
    public float LaunchSpeed = 20f;

    [Header("Line Settings")] public float LineLength;
    public float LineDensity = 0.5f;
    private float LengthNoHook;
    private float ClosestLinkLength;
    private int NumberOfLinks;
    public float InitialLinkLeeway;
    public float DeltaLinkLeewayMultiplier;

    [Header("Hook")]
    public LayerMask HookableLayers;
    public float MaxLength = 20f;
    public float DeploySpeed = 20f;
    private Vector2 Target;
    public bool ReachedTarget;
    private bool HookLaunched;
    
    [Header("Rope")] 
    public GameObject HookPrefab;
    private GameObject DeployedHook;
    private Rigidbody2D DeployedHookRB;
    [SerializeField] private string CurrentItem = "Nothing";
    
    public LineRenderer RopeRenderer;
    public GameObject LinkPrefab;
    public LinkData[] Links;
    private Vector3[] LineRendererPoints = new Vector3[1];
    public Transform LinkSpawnPoint;
    public DistanceJoint2D SpawnPointJoint;
    public bool HookIsLatched;

    // Start is called before the first frame update
    void Start()
    {
        RopeRenderer.enabled = false;
        //Temporary Init
        // NewStartGrapple();
        //Initialization
        Cam = Camera.main;
        SpawnPointJoint = LinkSpawnPoint.GetComponent<DistanceJoint2D>();
        //Controls.Gameplay.GrappleDirection.performed += OnMouseMoved;
        Controls = new PlayerControls();
        Controls.Gameplay.Enable();
        Controls.Gameplay.GrappleDistanceControl.performed += ctx => LineLength += ctx.ReadValue<float>();
        Controls.Gameplay.GrappleDistanceControl.canceled += ctx => LineLength += 0f;
        Controls.Gameplay.GrappleButton.performed += ctx => NewGrappleToggle();
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GrappleDirection = Cam.ScreenToWorldPoint(Controls.Gameplay.GrappleDirection.ReadValue<Vector2>());
        if (HookLaunched)
        {
            Vector2 HookPos = DeployedHook.transform.position;
            if (!ReachedTarget && !HookIsLatched)
            {
                HookPos = Vector2.Lerp(DeployedHook.transform.position, Target,
                    DeploySpeed / Vector2.Distance(HookPos, Target) * Time.deltaTime);
            }
            else if (!HookIsLatched)
            {
                HookPos = Vector2.Lerp(DeployedHook.transform.position, LinkSpawnPoint.position,
                    DeploySpeed / Vector2.Distance(HookPos, LinkSpawnPoint.position) * Time.deltaTime);
            }

            DeployedHook.transform.position = HookPos;
            if (HookPos == Target)
            {
                ReachedTarget = true;
            }

            if (HookPos == new Vector2(LinkSpawnPoint.position.x, LinkSpawnPoint.position.y) && ReachedTarget)
            {
                Destroy(DeployedHook);
                LineLength = 0;
                CurrentItem = "Nothing";
                HookLaunched = false;
            }
        }
        
        if (HookIsLatched)
        {
            //Line Length Calculations
            LineLength=Mathf.Max(LineLength, 0);
            //Debug.Log(GrappleDirection);
            LengthNoHook = LineLength;
            ClosestLinkLength = LineLength % LineDensity;
            NumberOfLinks = Mathf.Max(Mathf.FloorToInt((LengthNoHook - ClosestLinkLength) / LineDensity),0);
            SpawnPointJoint.distance = ClosestLinkLength;
            
            //Debug.Log(NumberOfLinks + ", " + Links.Length);
            if (NumberOfLinks > Links.Length)
            {
                NewLink();
            }
            else if (NumberOfLinks <= Links.Length)
            {
                RemoveLink();
            }
            
        }
        if (CurrentItem == "Grapple")
        {
            LineCompose();
        }
    }

    private void FixedUpdate()
    {
        
    }

    void NewGrappleToggle()
    {
        switch (CurrentItem)
        {
            case "Grapple":
                EndGrapple();
                CurrentItem = "Nothing";
                break;
            case "Nothing":
                NewStartGrapple();
                CurrentItem = "Grapple";
                break;
        }
        /*if ()
        {
            EndGrapple();
        }
        else
        {
            NewStartGrapple();
        }*/
    }

    void NewStartGrapple()
    {
        Vector3 CastStartPos = LinkSpawnPoint.position;
        Target = 
            (GrappleDirection - new Vector2(CastStartPos.x,CastStartPos.y))
            / Vector2.Distance(GrappleDirection,CastStartPos)
            * MaxLength;
        DeployedHook = Instantiate(HookPrefab);
        DeployedHookRB = DeployedHook.GetComponent<Rigidbody2D>();
        DeployedHook.transform.position = CastStartPos;
        Vector3 HookAngle = DeployedHookRB.transform.eulerAngles;
        
        DeployedHookRB.transform.eulerAngles = new Vector3(HookAngle.x,HookAngle.y,Mathf.Rad2Deg * Mathf.Atan2(GrappleDirection.y, GrappleDirection.x));
        Debug.Log(Mathf.Rad2Deg * Mathf.Atan2(GrappleDirection.y, GrappleDirection.x));
        
        DeployedHookRB.GetComponent<NewHookScript>().DeployedFrom = this;
        DeployedHookRB.bodyType = RigidbodyType2D.Dynamic;
        DeployedHookRB.gravityScale = 0;
        Debug.Log(Target);

        HookLaunched = true;
        HookIsLatched = false;
        ReachedTarget = false;
        RopeRenderer.enabled = true;
    }

    public void CreateRope(Vector2 HookPosition)
    {
        float Dist = Vector2.Distance(LinkSpawnPoint.position, HookPosition);
        LineLength = Dist;
        int LinksRequired = Mathf.Max(Mathf.FloorToInt((Dist - Dist % LineDensity) / LineDensity),0);
        Debug.Log("Links Required : " + LinksRequired);
        Array.Resize(ref Links, LinksRequired);
        Array.Resize(ref LineRendererPoints, LinksRequired+2);
        for (int i = 0; i < LinksRequired; i++)
        {
            GameObject CurrentLink = Instantiate(LinkPrefab);
            CurrentLink.transform.position = Vector2.Lerp(HookPosition, new Vector2(LinkSpawnPoint.position.x,LinkSpawnPoint.position.y), (i+1)/((float)LinksRequired));
            Links[i] = CurrentLink.GetComponent<LinkData>();
            LineRendererPoints[i + 1] = CurrentLink.transform.position;
            Links[i].LinkJoint.connectedBody = 0 > i-1 ? DeployedHookRB : Links[i - 1].LinkRB;
            Links[i].LinkJoint.distance = LineDensity;
        }
        SpawnPointJoint.enabled = true;
        SpawnPointJoint.connectedBody = Links[LinksRequired-1].LinkRB;
    }
    
    
    //Old Start grapple method that isn't functional
    /*private void StartGrapple()
    {
        //creates hook
        DeployedHook = Instantiate(HookPrefab);
        
        DeployedHookRB = DeployedHook.GetComponent<Rigidbody2D>();
        DeployedHook.GetComponent<NewHookScript>().DeployedFrom = this;
        DeployedHook.transform.position = LinkSpawnPoint.transform.position;
        //amkes space for hook to move
        LineLength = InitialLinkLeeway;
        //adds force to hook
        DeployedHookRB.AddForce(GrappleDirection * LaunchSpeed, ForceMode2D.Impulse);
        //configures the distance joint
        SpawnPointJoint.enabled = true;
        SpawnPointJoint.connectedBody = DeployedHookRB;
        //sets the first point of the line renderer to the spawn point of the hook
        LineRendererPoints[0] = DeployedHookRB.transform.position;
        //enables the line renderer
        RopeRenderer.gameObject.SetActive(true);
        //declares that the hook is active
        HookIsLatched = false;
    }*/
    
    private void EndGrapple()
    {
        //Triggers when a player terminates a grapple
        // Destroys all links
        int i = 0;
        foreach (var LinkData in Links)
        {
            Destroy(Links[i].gameObject,0);
            i++;
        }
        Links = new LinkData[0];
        LineRendererPoints = new Vector3[1];
        // Destroy Hook
        Destroy(DeployedHookRB.gameObject);
        // Disables Joint
        SpawnPointJoint.enabled = false;
        SpawnPointJoint.connectedBody = null;
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
    }

    private void RemoveLink()
    {
        for (int i = Links.Length; i > NumberOfLinks; i--)
        {
            //Debug.Log("Destroyed Object (" + Links[Links.Length - 1] + ")");
            Destroy(Links[i - 1].gameObject);
        }
        Array.Resize(ref Links, NumberOfLinks);
        SpawnPointJoint.connectedBody = (0 == NumberOfLinks) ? DeployedHookRB : Links[Links.Length - 1].LinkRB;
        HookLaunched = false;
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

    private void OnEnable()
    {
        Controls?.Enable();
    }

    private void OnDisable()
    {
        Controls.Disable();
    }
}
