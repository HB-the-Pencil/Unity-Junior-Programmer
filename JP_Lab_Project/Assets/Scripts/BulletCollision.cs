using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float damage;
    public float knockback;
    
    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Bug":
                HealthBar healthBar = other.gameObject.GetComponent<HealthBar>();
                healthBar.TakeDamage(damage);
                
                Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * knockback, ForceMode.Impulse);
                break;
        }
        
        Destroy(gameObject);
    }
}
