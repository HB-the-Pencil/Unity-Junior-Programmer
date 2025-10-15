using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] float followDistance = 2.5f;
    
    private Rigidbody _rb;
    private GameObject _player;

    // Needed:
    // Attack cooldown
    // Attack timer
    // Attack power
    // Rest time? To do nothing?
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
        _player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) >= followDistance)
        {
            transform.LookAt(_player.transform.position);
            _rb.AddForce(transform.forward * (speed * Time.deltaTime), ForceMode.VelocityChange);
        }
    }
}
