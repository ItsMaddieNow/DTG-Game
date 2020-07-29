using System;
using UnityEngine;

public class GrapplePlus : MonoBehaviour
{
    private PlayerControls Controls;

    [Header("Line Settings")] public float LineLength;
    public float LineDensity = 0.5f;
    private float LengthNoHook;
    public float ClosestLinkLength;
    public int NumberOfLinks;

    [Header("Rope")] 
    [SerializeField] private LineRenderer RopeRenderer;
    public GameObject LinkPrefab;
    public LinkData[] Links;
    private Vector3[] LineRendererPoints = new Vector3[1];
    public Transform LinkSpawnPoint;
    [SerializeField] private DistanceJoint2D SpawnPointJoint;
    [SerializeField] private Rigidbody2D DeployedHookRB;
    [SerializeField] private bool HookDeployed = false;
    

    // Start is called before the first frame update
    void Start()
    {
        StartGrapple();
        SpawnPointJoint = LinkSpawnPoint.GetComponent<DistanceJoint2D>();
        Controls = new PlayerControls();
        Controls.Gameplay.Enable();
        
        Controls.Gameplay.GrappleDistanceControl.performed += ctx => LineLength += ctx.ReadValue<float>();
        Controls.Gameplay.GrappleDistanceControl.canceled += ctx => LineLength += 0f;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPointJoint.enabled = HookDeployed;
        LengthNoHook = LineLength - LineDensity;
        ClosestLinkLength = LineLength % LineDensity;
        NumberOfLinks = Mathf.Max(Mathf.FloorToInt((LengthNoHook - ClosestLinkLength) / LineDensity),0);
        //Links[Mathf.FloorToInt((LengthNoHook) / LineDensity)];
        if (HookDeployed)
        {
            SpawnPointJoint.distance = ClosestLinkLength;
        }

        //Debug.Log(NumberOfLinks + ", " + Links.Length);
        if (NumberOfLinks > Links.Length)
        {
            NewLink();
        }
        else if (NumberOfLinks < Links.Length)
        {
            RemoveLink();
        }
        LineCompose();
    }

    private void StartGrapple()
    {
        SpawnPointJoint.enabled = true;
        LineRendererPoints[0] = DeployedHookRB.transform.position;
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
        Debug.Log(Links.Length + ", " + Links[Links.Length - 1].LinkRB);
        
    }

    private void RemoveLink()
    {
        for (int i = Links.Length; i > NumberOfLinks; i--)
        {
            Debug.Log("Destroyed Object (" + Links[Links.Length - 1] + ")");
            Destroy(Links[Links.Length - 1].gameObject);
        }
        Array.Resize(ref Links, NumberOfLinks);
        SpawnPointJoint.connectedBody = Links[Links.Length-1].LinkRB;
    }

    private void EndGrapple()
    {
        foreach (var LinkData in Links)
        {
            Destroy(Links[0].gameObject,0);
        }
        Destroy(DeployedHookRB.gameObject);
        SpawnPointJoint.enabled = false;
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
        Controls.Enable();
    }

    private void OnDisable()
    {
        Controls.Disable();
    }
}
