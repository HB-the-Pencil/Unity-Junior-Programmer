using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool hasPowerup;
        
    [SerializeField] private float speed = 5;
    
    // Easier to serialize than to use Find() and risk having no focal point (or many).
    [SerializeField] private GameObject focalPoint;
    [SerializeField] private GameObject powerupIndicator;
    
    private Rigidbody rb;
    private float powerupStrength = 15f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        rb.AddForce(focalPoint.transform.forward * (forwardInput * speed));

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        
        // Activate the indicator if the powerup is active.
        powerupIndicator.gameObject.SetActive(hasPowerup);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 away = collision.gameObject.transform.position - transform.position;
            
            rb.AddForce(away.normalized * powerupStrength, ForceMode.Impulse);
        }
    }
}
