using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // This is only used for ratios.
    public float maxHealth = 100f;
    
    private Slider _health;
    
    void Start()
    {
        _health = GetComponentInChildren<Slider>();
    }

    public void UpdateHealth(float amount)
    {
        _health.value = amount / maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _health.value -= damage / maxHealth;
    }
}
