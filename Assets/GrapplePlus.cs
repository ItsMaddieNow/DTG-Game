using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePlus : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        SpawnPointJoint = LinkSpawnPoint.GetComponent<DistanceJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        LengthNoHook = LineLength - LineDensity;
        ClosestLinkLength = LineLength % LineDensity;
        NumberOfLinks = Mathf.Max(Mathf.FloorToInt((LengthNoHook - ClosestLinkLength) / LineDensity),0);
        //Links[Mathf.FloorToInt((LengthNoHook) / LineDensity)];
    }

    private void StartGrapple()
    {
        SpawnPointJoint.enabled = true;
    }
    private void NewLink()
    {
        int FilledLinks = Links.Length;
        Links = new LinkData[NumberOfLinks];
        //for every missing link create a new link
        for (int i = FilledLinks; i < NumberOfLinks; i++)
        {
            GameObject CurrentLink = Instantiate(LinkPrefab);
            CurrentLink.transform.position = LinkSpawnPoint.transform.position;
            Links[i] = CurrentLink.GetComponent<LinkData>();
            Links[i].LinkJoint.connectedBody = 0 > i-1 ? DeployedHookRB : Links[i - 1].LinkRB;
        }
    }

    private void EndGrapple()
    {
        int i = 0;
        foreach (var linkData in Links)
        {
            Destroy(Links[0].gameObject,0);
        }
        Destroy(DeployedHookRB.gameObject);
        SpawnPointJoint.enabled = false;
    }
}
