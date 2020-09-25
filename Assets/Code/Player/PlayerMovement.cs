using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Horizontal Movement")]
    public float MovementSpeed = 10f;
    public Vector2 Direction;
    public bool FacingRight = true;
    
    [Header("Verical Movement")]
    public float JumpSpeed = 15f;
    public float JumpDelay = 0.25f;
    private float JumpTimer;

    [Header("Components")]
    public Rigidbody2D Rb;
    public Animator PlayerAnimator;

    [Header("Physics")]
    public float MaxSpeed = 7f;
    public float LinearDrag = 4f;
    public float GravityScale = 1f;
    public float FallMultiplier = 5f;
    
    [Header("Ground Collision")]
    [SerializeField]
    private bool OnGround;
    public float MaxDistance = 0.6f;
    public LayerMask RaycastLayerDetect;
    public Vector3 ColliderOffset;
    
    [Header("Water Movement")]
    [SerializeField] private bool HeadSubmerged;
    public Vector3 HeadColliderOffset;
    public float HeadDistance;
    
    [SerializeField] private bool FeetSubmerged;
    public Vector3 FootColliderOffset;
    public float FootDistance;
    public LayerMask WaterLayers;

    public float SurfaceForce;
    public float SubmergedForce;
    
    //Controls
    private PlayerControls Controls;
    private bool JumpButtonDown;

    [Header("Bubbling")]
    public Transform Bubble;
    public bool Bubbled;
    public float PullIntensity = 2.5f;

    private void Awake()
    {
        Controls = new PlayerControls();

        Controls.Gameplay.Jump.performed += ctx => JumpCall();
        Controls.Gameplay.Jump.performed += ctx => JumpButtonDown = ctx.ReadValueAsButton();
        Controls.Gameplay.Jump.canceled += ctx => JumpButtonDown = ctx.ReadValueAsButton();
        Controls.Gameplay.Movement.performed += ctx => Direction = ctx.ReadValue<Vector2>();
        Controls.Gameplay.Movement.canceled += ctx => Direction = Vector2.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Checks If The Character is On The Ground
        OnGround = (
            Physics2D.Raycast(transform.position + ColliderOffset, -transform.up, MaxDistance, RaycastLayerDetect) || 
            Physics2D.Raycast(transform.position - ColliderOffset, -transform.up, MaxDistance, RaycastLayerDetect) || 
            Physics2D.Raycast(transform.position, -transform.up, MaxDistance, RaycastLayerDetect)
        );
        FeetSubmerged = (
            Physics2D.Raycast(transform.position + FootColliderOffset, -transform.up, FootDistance, WaterLayers) || 
            Physics2D.Raycast(transform.position - new Vector3(FootColliderOffset.x, -FootColliderOffset.y, FootColliderOffset.z), -transform.up, FootDistance, WaterLayers)
        );
        HeadSubmerged = (
            Physics2D.Raycast(transform.position + HeadColliderOffset, -transform.up, -HeadDistance, WaterLayers) || 
            Physics2D.Raycast(transform.position - new Vector3(HeadColliderOffset.x, -HeadColliderOffset.y, HeadColliderOffset.z), -transform.up, -HeadDistance, WaterLayers)
        );
        if (Bubbled){
            Vector2 ThisPos = transform.position;
            Vector2 BubblePos = Bubble.position;
            this.transform.position = Vector2.Lerp(ThisPos, BubblePos,PullIntensity * Time.deltaTime/(Vector2.Distance(ThisPos, BubblePos)));
        }
    }

    private void FixedUpdate()
    {
        MoveCharacter(Direction.x);
        if (JumpTimer > Time.time)
        {
            if (OnGround && !(HeadSubmerged||FeetSubmerged))
            {
                Jump();
            } else if (HeadSubmerged && FeetSubmerged)
            {
                WaterThrust();
            } else if (!HeadSubmerged && FeetSubmerged)
            {
                Breach();
            }
            
        }
        
        ModifyPhysics();
    }

    void JumpCall()
    {
        JumpTimer = Time.time + JumpDelay;
    }
    
    void Jump()
    {
        Rb.velocity = new Vector2(Rb.velocity.x,0);
        Rb.AddForce(transform.up * JumpSpeed, ForceMode2D.Impulse);
        JumpTimer = 0f;
    }
    
    void Breach()
    {
        Rb.velocity = new Vector2(Rb.velocity.x,0);
        Rb.AddForce(transform.up * SurfaceForce, ForceMode2D.Impulse);
        JumpTimer = 0f;
    }
    
    void WaterThrust()
    {
        Rb.velocity = new Vector2(Rb.velocity.x,0);
        Rb.AddForce(transform.up * SubmergedForce, ForceMode2D.Impulse);
        JumpTimer = 0f;
    }
    
    void MoveCharacter(float Horizontal)
    {
        Rb.AddForce(Vector2.right * Horizontal * MovementSpeed);
        
        PlayerAnimator.SetFloat("Horizontal", Mathf.Abs(Rb.velocity.x));
        if ((Horizontal > 0 && !FacingRight) || (Horizontal < 0 && FacingRight))
        {
            Flip();
        }

        if (Mathf.Abs(Rb.velocity.x) > MaxSpeed)
        {
            Rb.velocity = new Vector2(Mathf.Sign(Rb.velocity.x) * MaxSpeed, Rb.velocity.y);
        }
    }

    void ModifyPhysics()
    {
        bool ChangingDirections = (Direction.x > 0 && Rb.velocity.x < 0) || (Direction.x < 0 && Rb.velocity.x > 0);
        if (OnGround)
        {
            if (Mathf.Abs(Direction.x)<0.4f)
            {
                Rb.drag = LinearDrag;
            }
            else
            {
                Rb.drag = 0f;
            }
            Rb.gravityScale = 0;
        } 
        else if (Bubbled)
        {
            Rb.gravityScale = 0;
            Rb.drag = 1f;
        }
        else
        {
            Rb.gravityScale = GravityScale;
            Rb.drag = LinearDrag * 0.15f;
            if (Rb.velocity.y < 0)
            {
                Rb.gravityScale = GravityScale * FallMultiplier;
            }else if (Rb.velocity.y > 0 && !JumpButtonDown)
            {
                Rb.gravityScale = GravityScale * (FallMultiplier / 2);
            }
        }
    }

    void Flip()
    {
        FacingRight = !FacingRight;
        transform.rotation = Quaternion.Euler(0,FacingRight ? 0:180,0);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bubble")){
            Bubble = other.transform;
            Bubbled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Bubble")){
            Bubbled = false;
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + ColliderOffset, transform.position + ColliderOffset + -transform.up * MaxDistance);
        Gizmos.DrawLine(transform.position - ColliderOffset, transform.position - ColliderOffset + -transform.up * MaxDistance);
        Gizmos.DrawLine(transform.position, transform.position + -transform.up * MaxDistance);
        
        // Water
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position + FootColliderOffset, transform.position + FootColliderOffset + -transform.up * FootDistance);
        Gizmos.DrawLine(transform.position - new Vector3(FootColliderOffset.x, -FootColliderOffset.y, FootColliderOffset.z), transform.position - new Vector3(FootColliderOffset.x, -FootColliderOffset.y, FootColliderOffset.z) + -transform.up * FootDistance);
        
        Gizmos.DrawLine(transform.position + HeadColliderOffset, transform.position + HeadColliderOffset + -transform.up * HeadDistance);
        Gizmos.DrawLine(transform.position - new Vector3(HeadColliderOffset.x, -HeadColliderOffset.y, HeadColliderOffset.z), transform.position - new Vector3(HeadColliderOffset.x, -HeadColliderOffset.y, HeadColliderOffset.z) + -transform.up * HeadDistance);
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
