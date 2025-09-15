using UnityEngine;

public class PlayerControllerBonus : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10f;
    public float xRange = 10f;
    public float zRange = 5f;

    public GameObject projectilePrefab;
    
    private static int _lives = 3;
    private static int _score = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateLives();
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
    
    // New concept: static methods to allow access by other classes.
    public static void UpdateLives(int amount = 0)
    {
        _lives += amount;
        // New concept: ternary if to condense code.
        Debug.Log(_lives > 0 ? $"Lives remaining: {_lives}" : $"Game Over! Your score: {_score}");
    }
    
    public static void UpdateScore(int amount = 0)
    {
        _score += amount;
        Debug.Log($"Score: {_score}");
    }
}
