using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("Health Bar Settings")]
    [SerializeField] Slider healthSlider;
    // This is only used for ratios.
    public float maxHealth = 100f;
    public float currentHealth;
    
    [Header("Invulnerability")]
    public bool invulnerable;
    [SerializeField] float invulnerabilityTime = 1f;

    private float _cooldown;

    public HealthBar(bool invulnerable)
    {
        this.invulnerable = invulnerable;
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Decrease the invulnerability timer.
        _cooldown -= Time.deltaTime;
        invulnerable = _cooldown > 0;
        
        // Update the current health.
        currentHealth = healthSlider.value;
    }

    public void UpdateHealth(float amount)
    {
        healthSlider.value = amount / maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (_cooldown <= 0)
        {
            healthSlider.value -= damage / maxHealth;
            _cooldown = invulnerabilityTime;
        }
    }
}
