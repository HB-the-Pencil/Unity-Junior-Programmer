using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;
    
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        // transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        rb.linearVelocity = rb.transform.forward * speed;

        // tilt the plane up/down based on up/down arrow keys
        rb.angularVelocity = Vector3.right * (rotationSpeed * verticalInput * Time.deltaTime);
    }
}
