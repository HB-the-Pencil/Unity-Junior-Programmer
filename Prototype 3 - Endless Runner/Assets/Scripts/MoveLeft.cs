using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 20f;
    private float leftBound = -15f;
    private PlayerController player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the obstacle left while the game is continuing.
        if (!player.gameOver)
        {
            transform.Translate(Vector3.left * (Time.deltaTime * speed));
        }
        
        // If an obstacle is off-screen, destroy it.
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
