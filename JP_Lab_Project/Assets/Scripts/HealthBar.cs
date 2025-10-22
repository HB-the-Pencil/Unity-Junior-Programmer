using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // This is only used for ratios.
    public float maxHealth = 100f;
    
    private Slider health;
    
    void Start()
    {
        health = GetComponentInChildren<Slider>();
    }

    public void UpdateHealth(float amount)
    {
        health.value = amount / maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health.value -= damage / maxHealth;
    }
}
