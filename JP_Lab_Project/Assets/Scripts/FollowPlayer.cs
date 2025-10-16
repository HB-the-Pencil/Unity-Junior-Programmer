using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public bool following = true;
    
    [SerializeField] float speed = 10.0f;
    [SerializeField] float followDistance = 3.0f;
    [SerializeField] string targetTag = "Player";
    
    private Rigidbody _rb;
    private GameObject _target;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
        _target = GameObject.FindWithTag(targetTag);
    }

    // Update is called once per frame
    void Update()
    {
        // Turn to face the target (this also prevents it from rolling around all over).
        transform.LookAt(_target.transform.position);
        float distance = Vector3.Distance(transform.position, _target.transform.position);
        
        if (distance >= followDistance && following)
        {
            _rb.AddForce(transform.forward * (speed * Time.deltaTime), ForceMode.VelocityChange);
        }
    }
}
