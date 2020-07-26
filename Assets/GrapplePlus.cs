using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePlus : MonoBehaviour
{
    private PlayerControls Controls;
    
    [Header("Line Settings")]
    public float LineLength;
    public float LineDensity = 0.5f;
    private float LengthNoHook;
    public float ClosestLinkLength;
    public int NumberOfLinks;
    
    public GameObject LinkPrefab;
    public LinkData[] Links;
    public Transform LinkSpawnPoint;
    private DistanceJoint2D SpawnPointJoint;
    private Rigidbody2D DeployedHookRB;
    [SerializeField] private bool HookDeployed = false;
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnPointJoint = LinkSpawnPoint.GetComponent<DistanceJoint2D>();
        Controls = new PlayerControls();
        Controls.Gameplay.Enable();
        
        Controls.Gameplay.GrappleDistanceControl.performed += ctx => LineLength += ctx.ReadValue<float>();
        Controls.Gameplay.GrappleDistanceControl.canceled += ctx => LineLength += 0f;
    }

    // Update is called once per frame
    void Update()
    {
        LengthNoHook = LineLength - LineDensity;
        ClosestLinkLength = LineLength % LineDensity;
        NumberOfLinks = Mathf.Max(Mathf.FloorToInt((LengthNoHook - ClosestLinkLength) / LineDensity),0);
        //Links[Mathf.FloorToInt((LengthNoHook) / LineDensity)];
        if (HookDeployed)
        {
            SpawnPointJoint.distance = ClosestLinkLength;
        }

        if (NumberOfLinks > Links.Length)
        {
            NewLink();
        }
        else if (NumberOfLinks > Links.Length)
        {
            RemoveLink();
        }
    }

    private void StartGrapple()
    {
        SpawnPointJoint.enabled = true;
    }
    private void NewLink()
    {
        int FilledLinks = Links.Length;
        Array.Resize(ref Links, NumberOfLinks);
        //Links = new LinkData[NumberOfLinks];
        //for every missing link create a new link
        for (int i = FilledLinks; i < NumberOfLinks; i++)
        {
            GameObject CurrentLink = Instantiate(LinkPrefab);
            CurrentLink.transform.position = LinkSpawnPoint.transform.position;
            Links[i] = CurrentLink.GetComponent<LinkData>();
            Links[i].LinkJoint.connectedBody = 0 > i-1 ? DeployedHookRB : Links[i - 1].LinkRB;
        }
        SpawnPointJoint.connectedBody = Links[Links.Length].LinkRB;
    }

    private void RemoveLink()
    {
        int FilledLinks = Links.Length;
        for (int i = FilledLinks; i > NumberOfLinks; i--)
        {
            Destroy(Links[Links.Length].gameObject);
        }
        Array.Resize(ref Links, NumberOfLinks);
        SpawnPointJoint.connectedBody = Links[Links.Length].LinkRB;
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
    
    private void OnEnable()
    {
        Controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        Controls.Gameplay.Disable();
    }
}
