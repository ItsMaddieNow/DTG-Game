using System;
using System.Drawing;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    [Header("General")]
    public string CurrentItem;
    
    [Header("Controls")]
    private PlayerControls Controls;
    private Camera Cam;
    
    [Header("Grappling Hook")]
    public GameObject GrapplingGun;
    public Vector2 GunPositionWarp;
    public float HookLaunchSpeed = 20f;
    public GameObject HookPrefab;
    public GameObject LinkPrefab;
    private Vector2 GrappleDirection;
    public LayerMask LatchableLayers;
    public float MaxLength = 20f;
    public float DeploySpeed = 20f;
    private Vector2 Target;
    public Transform LinkSpawnPoint;
    public DistanceJoint2D SpawnPointJoint;

    // Hook States
    public bool ReachedTarget;
    private bool HookLaunched;
    public bool HookIsLatched;
    
    // Line
    private LinkData[] Links;
    private Vector3[] LineRendererPoints = new Vector3[1];
    private GameObject DeployedHook;
    private Rigidbody2D DeployedHookRB;
    public LineRenderer RopeRenderer;
    
    [Header("Grappling Line Setting")]
    public float LineLength;
    public float LineDensity = 0.5f;
    private float LengthNoHook;
    private float ClosestLinkLength;
    private int NumberOfLinks;

    [Header("Torch")]
    public float TorchSmoothing = 1f;
    public GameObject Torch;
    public GameObject TorchAnchor;
    public GameObject TorchContainer;
    public GameObject Flame;
    
    // Controls need to be started in awake or warnings will occur
    void Awake()
    {
        Controls = new PlayerControls();
        Controls.Gameplay.Enable();
        Controls.Gameplay.GrappleDistanceControl.performed += ctx => LineLength += ctx.ReadValue<float>();
        Controls.Gameplay.GrappleDistanceControl.canceled += ctx => LineLength += 0f;
        Controls.Gameplay.GrappleToggle.performed += ctx => GrappleToggle();
        Controls.Gameplay.GrappleButton.performed += ctx => Grapple();
        
        Controls.Gameplay.TorchEnable.performed += ctx => TorchToggle();
        Controls.Gameplay.TorchThrow.performed += ctx => TorchThrow();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        RopeRenderer.enabled = false;
        Cam = Camera.main;
        SpawnPointJoint = LinkSpawnPoint.GetComponent<DistanceJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Torch
        TorchContainer.transform.eulerAngles = Vector3.zero;
        Torch.SetActive(CurrentItem == "Torch");
        
        if (CurrentItem == "Torch")
        {
            Transform TorchTransform = Torch.transform;
            Vector3 TorchPos = TorchTransform.position;
            Vector3 AnchorPos = TorchAnchor.transform.position;
            Vector3 AnchorLocalPos = TorchAnchor.transform.localPosition;
            TorchTransform.position = Vector2.Lerp(TorchPos, AnchorPos, TorchSmoothing/Vector2.Distance(Torch.transform.position, AnchorPos) * Time.deltaTime);
            TorchTransform.eulerAngles = new Vector3(0, 0, Mathf.Lerp(-30f,30f, Mathf.InverseLerp(AnchorLocalPos.x, -AnchorLocalPos.x, Torch.transform.localPosition.x)));
        }
        //Grappling hook
        GrapplingGun.SetActive(CurrentItem == "Grappling Hook");        
        LinkSpawnPoint.GetComponent<SpriteRenderer>().enabled = !HookLaunched;
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
                Vector3 PointPos = LinkSpawnPoint.position;
                HookPos = Vector2.Lerp(DeployedHook.transform.position, PointPos,
                    DeploySpeed / Vector2.Distance(HookPos, PointPos) * Time.deltaTime);
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
                CreateNewLinks();
            }
            else if (NumberOfLinks <= Links.Length)
            {
                RemoveLinks();
            }
            
        }
        if (CurrentItem == "Grapple")
        {
            LineCompose();
        }
    }
    void Grapple()
    {
        if (CurrentItem == "Grappling Hook")
        {
            if (HookLaunched == false)
            {
                StartGrapple();
            }
            else
            {
                EndGrapple();
            }
        }
    }
    // May Need Revision
    void GrappleToggle()
    {
        void GrappleToggle()
        {
            if (CurrentItem == "Grappling Hook")
            {
                CurrentItem = null;
                ItemSwitchCleanup();
            }
            else
            {
                CurrentItem = "Grappling Hook";
                ItemSwitchCleanup();
            }
        }
    }
    void TorchToggle()
    {
        if (CurrentItem == "Torch")
        {
            CurrentItem = null;
            ItemSwitchCleanup();
        }
        else
        {
            CurrentItem = "Torch";
            ItemSwitchCleanup();
            Torch.SetActive(true);
            //Flame.SetActive();
            Torch.transform.position = TorchAnchor.transform.position;
        }
    }
    void StartGrapple()
    {
        GrappleDirection = Cam.ScreenToWorldPoint(Controls.Gameplay.GrappleDirection.ReadValue<Vector2>());
        
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
            Vector3 Pos = LinkSpawnPoint.position;
            CurrentLink.transform.position = Vector2.Lerp(HookPosition, new Vector2(Pos.x,Pos.y), (i+1)/((float)LinksRequired));
            Links[i] = CurrentLink.GetComponent<LinkData>();
            LineRendererPoints[i + 1] = CurrentLink.transform.position;
            Links[i].LinkJoint.connectedBody = 0 > i-1 ? DeployedHookRB : Links[i - 1].LinkRB;
            Links[i].LinkJoint.distance = LineDensity;
        }
        SpawnPointJoint.enabled = true;
        SpawnPointJoint.connectedBody = Links[LinksRequired-1].LinkRB;
    }
    
    private void CreateNewLinks()
    {
        int FilledLinks = Links.Length;
        Array.Resize(ref Links, NumberOfLinks);
        Array.Resize(ref LineRendererPoints, NumberOfLinks+2);
        // For every missing link create a new link
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
    }
    
    private void RemoveLinks()
    {
        for (int i = Links.Length; i > NumberOfLinks; i--)
        {
            Destroy(Links[i - 1].gameObject);
        }
        Array.Resize(ref Links, NumberOfLinks);
        SpawnPointJoint.connectedBody = (0 == NumberOfLinks) ? DeployedHookRB : Links[Links.Length - 1].LinkRB;
        HookLaunched = false;
    }
    
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
    
    private void TorchThrow()
    {
        
    } 
    
    private void ItemSwitchCleanup()
    {
        if (CurrentItem != "Grappling Hook")
        {
            EndGrapple();
        }
        RopeRenderer.enabled = HookLaunched;
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
