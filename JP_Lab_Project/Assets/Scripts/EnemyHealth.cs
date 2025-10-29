using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private HealthBar _healthBar;

    void Start()
    {
        _healthBar = GetComponentInChildren<HealthBar>();
    }

    void Update()
    {
        if (_healthBar.currentHealth <= 0)
        {
            Destroy(gameObject);
            GameObject.FindWithTag("SpawnManager").GetComponent<SpawnManager>().enemyCount--;
        }
    }
}
