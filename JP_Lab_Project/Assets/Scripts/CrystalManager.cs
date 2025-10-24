using UnityEngine;

public class CrystalManager : MonoBehaviour
{
    private HealthBar _healthBar;
    private PlayerController _player;

    void Start()
    {
        _healthBar = GetComponent<HealthBar>();
        _player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (_healthBar.currentHealth <= 0)
        {
            _player.GameOver();
            Destroy(gameObject);
        }
    }
}
