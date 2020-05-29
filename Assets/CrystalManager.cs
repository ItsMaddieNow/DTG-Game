using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CrystalManager : MonoBehaviour
{
    public GameObject ParticleBurst;
    //private ParticleSystem CurrentParticleBurst;
    private Animator CrystalAnimator;
    [SerializeField]
    private bool CreatedBurst = false;
    // Start is called before the first frame update
    
    void Start()
    {
        CrystalAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyThis()
    {
        //CurrentParticleBurst.Stop();
        Destroy(gameObject);
    }

    public void CreateParticleBurst()
    {
        if (!CreatedBurst)
        {
            CreatedBurst = true;
            Instantiate(ParticleBurst);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            CrystalAnimator.SetBool("Destroying", true);
        }
    }
}
