using System;
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
    [SerializeField] public GameObject hitbox;
    [Tooltip("How long to display hitbox")]
    [SerializeField] private float displayForSecs;
    
    private float cooldown;
    private float displayTimer;

    private FollowTarget followScript;
    
    private Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        followScript = GetComponent<FollowTarget>();
        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Get the nearest target and whether it is close enough to hit.
        bool close = followScript.close;
        GameObject target = followScript.target;

        if (close && cooldown <= 0)
        {
            DoAttack(target);
        }
        
        // Display the attack if the target is being attacked.
        if (displayTimer <= 0)
        {
            animator.SetBool("Attacking", false);
        }
        
        cooldown -= Time.deltaTime;
        displayTimer -= Time.deltaTime;
    }
    
    private void DoAttack(GameObject target)
    {
        if (target.CompareTag("Player") || target.CompareTag("Crystal"))
        {
            animator.SetBool("Attacking", true);
            animator.Play("Enemy_AttackHitboxGrow");
            displayTimer = displayForSecs;

            cooldown = reloadTime;

            HealthBar healthBar = target.GetComponent<HealthBar>();

            healthBar.TakeDamage(damage);
        }
    }
}
