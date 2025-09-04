using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 30f;
    public float turnSpeed = 20f;
    public float horizontalInput;
    public float verticalInput;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get user input.
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        // Move the vehicle!
        transform.Translate(Vector3.forward * (Time.deltaTime * speed * verticalInput));
        transform.Rotate(Vector3.up * (Time.deltaTime * turnSpeed * horizontalInput));
    }
}
