using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public bool following = true;
    public bool close;
    public GameObject target;
    
    [Tooltip("How fast the RigidBody moves in units/second")]
    [SerializeField] float speed = 10.0f;
    [Tooltip("How close to get to the target")]
    [SerializeField] float targetDistance = 3.0f;
    [Tooltip("When to stop following the target")]
    [SerializeField] float awakeDistance = 15.0f;
    [Tooltip("Which tags to target")]
    [SerializeField] string[] targetTags;
    
    private Rigidbody _rb;
    private List<GameObject> _targets = new();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
        foreach (string t in targetTags)
        {
            _targets = _targets.Union(GameObject.FindGameObjectsWithTag(t)).ToList();
        }
    }

    // Update is called once per frame
    void Update()
    {
        target = GetNearestTarget(_targets);
        
        // Turn to face the target (this also prevents it from rolling around all over).
        float distance = Vector3.Distance(transform.position, target.transform.position);
        
        // Determine whether the target is close by (mainly used for enemy attacks).
        close = distance <= targetDistance;
        
        // If the target is near enough, then start following. Otherwise, don't.
        following = (awakeDistance <= 0  || distance <= awakeDistance) && !close;

        if (following)
        {
            // Turn to look at target.
            transform.LookAt(target.transform.position);
            if (distance > targetDistance)
            {
                _rb.AddForce(transform.forward * (speed * Time.deltaTime), ForceMode.VelocityChange);
            }
        }
        else
        {
            // Reset the rotation and such so the body doesn't tip over.
            transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
            _rb.linearVelocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
        }
    }

    private GameObject GetNearestTarget(List<GameObject> gameObjects)
    {
        // Created by edwardrowe on Unity Discussions
        GameObject nearestTarget = null;
        float nearestDistance = float.MaxValue;
        
        Vector3 currentPos = transform.position;

        foreach (GameObject obj in gameObjects)
        {
            Vector3 direction = obj.transform.position - currentPos;
            float distance = direction.sqrMagnitude;

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestTarget = obj;
            }
        }
        
        return nearestTarget;
    }
}
