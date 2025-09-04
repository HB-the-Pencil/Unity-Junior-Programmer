using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed = 40f;
    private float _turnSpeed = 45f;
    private float _horizontalInput;
    private float _verticalInput;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get user input.
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        
        // Move the vehicle!
        transform.Translate(Vector3.forward * (Time.deltaTime * _speed * _verticalInput));
        transform.Rotate(Vector3.up * (Time.deltaTime * _turnSpeed * _horizontalInput));
    }
}
