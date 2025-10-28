using UnityEngine;
using UnityEngine.Rendering.Universal;

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
    
    private float _cooldown;
    private float _displayTimer;

    private FollowTarget _followScript;
    
    private Animator _animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _followScript = GetComponent<FollowTarget>();
        
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Get the nearest target and whether it is close enough to hit.
        bool close = _followScript.close;
        GameObject target = _followScript.target;

        if (close && _cooldown <= 0)
        {
            DoAttack(target);
        }
        
        // Display the attack if the target is being attacked.
        if (_displayTimer <= 0)
        {
            _animator.SetBool("Attacking", false);
        }
        
        _cooldown -= Time.deltaTime;
        _displayTimer -= Time.deltaTime;
    }
    
    private void DoAttack(GameObject target)
    {
        if (target.CompareTag("Player") || target.CompareTag("Crystal"))
        {
            _animator.SetBool("Attacking", true);
            _animator.Play("Enemy_AttackHitboxGrow");
            _displayTimer = displayForSecs;

            _cooldown = reloadTime;
            
            HealthBar healthBar = target.GetComponentInChildren<HealthBar>();

            healthBar.TakeDamage(damage);
        }
    }
}
