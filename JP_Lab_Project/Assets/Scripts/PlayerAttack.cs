using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float damage;
    public float knockback;
    
    [Header("Speed Settings")]
    // Thanks to a tutorial by Bobsi Tutorials.
    public float reloadTime;
    [SerializeField] float bulletSpeed;
    
    [Header("Bullet Spawning Setup")]
    [SerializeField] Transform bulletSpawn;
    [SerializeField] GameObject bulletPrefab;
    
    private PlayerController _player;
    private float _cooldown;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find the player so the scripts can interact.
        _player = GetComponent<PlayerController>();
        
        // Change the bullet settings.
        BulletCollision bullet = bulletPrefab.GetComponent<BulletCollision>();
        bullet.damage = damage;
        bullet.knockback = knockback;
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
