using UnityEngine;

public class NewHookScript : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector3 PositionOffset;
    private Vector3 RotationOffset;
    private Transform ToFollow;
    private Transform ThisTransform;
    public bool HooksIsLatched;

    public PlayerAbilities DeployedFrom;
    // Start is called before the first frame update
    void Start()
    {
        ThisTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (HooksIsLatched)
        {
            ThisTransform.position = ToFollow.position + PositionOffset;
            ThisTransform.eulerAngles = ToFollow.eulerAngles + RotationOffset;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Terrain") && !HooksIsLatched)
        {
            //makes sure it isn't effected by gravity or collisions
            rb.bodyType = RigidbodyType2D.Static;
            // Communicates to the main script that it has hit terrain
            DeployedFrom.HookIsLatched = true;
            Vector3 Pos = transform.position;
            DeployedFrom.CreateRope(Pos);
            // makes sure the hook stays latched to the object
            HooksIsLatched = true;
            ToFollow = other.transform;
            PositionOffset = Pos-other.transform.position;
            RotationOffset = transform.eulerAngles - other.transform.eulerAngles;
        }
    }
}
