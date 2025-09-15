using UnityEngine;

public class DetectCollisionsBonus : MonoBehaviour
{
    // New concept: SerializeField to make an editable private variable
    [SerializeField] HealthBarBonus healthBar;
    [SerializeField] private float health = 0;
    [SerializeField] private float maxHealth = 3;

    // New concept: Awake for the beginning of the class's existence
    private void Awake()
    {
        healthBar = GetComponentInChildren<HealthBarBonus>();
    }

// Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Destroy the animal and the steak.
        if (other.gameObject.CompareTag("Steak"))
        {
            // Increase saturation.
            Destroy(other.gameObject);
            health++;
            healthBar.UpdateHealth(health, maxHealth);

            if (health >= maxHealth)
            {
                Destroy(gameObject);
                PlayerControllerBonus.UpdateScore((Mathf.RoundToInt(maxHealth) * 10));
            }
        }

        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("Bird"))
        {
            Destroy(gameObject);
            PlayerControllerBonus.UpdateLives(-1);
        }
    }
}
