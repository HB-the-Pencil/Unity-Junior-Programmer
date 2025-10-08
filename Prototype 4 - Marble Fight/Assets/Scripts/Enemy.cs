using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 10;

    private Rigidbody rb;
    private GameObject player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        rb.AddForce(direction * speed);
    }
}
