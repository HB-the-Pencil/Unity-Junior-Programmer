using UnityEngine;

public class PlayerControllerBonus : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10f;
    public float xRange = 10f;
    public float zRange = 5f;

    public GameObject projectilePrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player horizontally.
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * (Time.deltaTime * horizontalInput * speed));
        
        // Move the player vertically.
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * (Time.deltaTime * verticalInput * speed));
        
        // Keep the player in-bounds.
        transform.position =  new Vector3(
            Mathf.Clamp(transform.position.x, -xRange, xRange),
            transform.position.y,
            Mathf.Clamp(transform.position.z, -zRange + 4, zRange + 4));
        
        // Throw projectiles! whoosh!
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
