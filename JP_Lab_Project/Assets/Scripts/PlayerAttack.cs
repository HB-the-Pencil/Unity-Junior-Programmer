using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Thanks to a tutorial by Bobsi Tutorials.
    [SerializeField] float bulletSpeed;
    [SerializeField] float reloadTime;
    [SerializeField] float damage;
    
    [SerializeField] Transform bulletSpawn;
    [SerializeField] GameObject bulletPrefab;
    
    private PlayerController _player;
    private float _cooldown;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find the player so the scripts can interact.
        _player = GetComponent<PlayerController>();
    }
    
    public void DoAttack()
    {
        if (_player.Controls.Abilities.Attack.triggered && _cooldown <= 0)
        {
            Shoot();
        }
        
        _cooldown -= Time.deltaTime;
    }

    private void Shoot()
    {
        // Spawn a new bullet.
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, 
            bulletSpawn.rotation, GameObject.FindWithTag("Player").transform);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed,
            ForceMode.Impulse);
        
        _cooldown = reloadTime;
    }
}
