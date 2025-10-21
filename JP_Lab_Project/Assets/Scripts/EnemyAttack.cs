using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Attack Details")]
    [Tooltip("Damage out of 100%")]
    [SerializeField] private float damage;
    [Tooltip("Delay between attacks")]
    [SerializeField] private float reloadTime;
    
    [Header("Hitbox")]
    [Tooltip("Game object for hitbox display")]
    [SerializeField] private GameObject hitbox;
    [Tooltip("How long to display hitbox")]
    [SerializeField] private float displayForSecs;
    
    private float cooldown;
    private MeshRenderer hitboxRenderer;
    private float displayTimer;

    private FollowTarget followScript;
    
    private Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hitboxRenderer = hitbox.GetComponent<MeshRenderer>();
        hitboxRenderer.enabled = false;

        followScript = GetComponent<FollowTarget>();
        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Get the nearest target and whether it is close enough to hit.
        bool close = followScript.close;
        GameObject target = followScript.target;

        if (close)
        {
            DoAttack(target);
        }
        
        // Display the attack if the target is being attacked.
        if (displayTimer <= 0)
        {
            hitboxRenderer.enabled = false;
            animator.SetBool("Attacking", false);
        }
        
        cooldown -= Time.deltaTime;
        displayTimer -= Time.deltaTime;
    }
    
    void DoAttack(GameObject target)
    {
        if (cooldown <= 0)
        {
            animator.SetBool("Attacking", true);
            animator.Play("Enemy_AttackHitboxGrow");
            hitboxRenderer.enabled = true;
            displayTimer = displayForSecs;
            
            cooldown = reloadTime;

            if (target.CompareTag("Player") || target.CompareTag("Programmer"))
            {
                HealthBar healthBar = target.GetComponent<HealthBar>();

                healthBar.TakeDamage(damage / 100);
            }
        }
    }
}
