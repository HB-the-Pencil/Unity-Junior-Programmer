using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 _offset = new Vector3(0, 7, -12);
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Offset camera so it's not inside the player.
        transform.position = player.transform.position + _offset;
    }
}
