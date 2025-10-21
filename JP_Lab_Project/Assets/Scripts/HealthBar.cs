using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider health;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        health.value -= damage;
    }
}
