using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool gameOver;
    
    // SerializeField is more secure than the tutorial's use of public.
    [Header("Physics")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityModifier;
    
    [Header("Particles")]
    [SerializeField] private ParticleSystem explosionParticles;
    [SerializeField] private ParticleSystem dirtParticles;
    
    [Header("Sounds")]
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;
    
    private bool isGrounded;
    
    // Components
    private Rigidbody rb;
    private Animator animator;
    private AudioSource audioPlayer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the rigid body and animation components.
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
        
        // Set the gravity.
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !gameOver)
        {
            // Make the player jump.
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            
            //Stop the dirt particles since they're no longer on the ground.
            dirtParticles.Stop();
            
            // Play audio and an animation.
            audioPlayer.PlayOneShot(jumpSound, 0.6f);
            animator.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Play the dirt particles again.
            isGrounded = true;
            dirtParticles.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            
            // Explode at the player. Crash!
            explosionParticles.Play();
            dirtParticles.Stop();
            audioPlayer.PlayOneShot(crashSound, 1.0f);
            
            // Play a death animation.
            Debug.Log("Game Over!");
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 1);
        }
    }
}
