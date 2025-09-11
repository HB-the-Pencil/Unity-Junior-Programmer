using UnityEngine;

public class DestroyOutOfBoundsBonus : MonoBehaviour
{
    private float _topBound = 30;
    private float _bottomBound = -10f;
    private float _leftBound = -25f;
    private float _rightBound = 25f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the steak is above the screen, destroy it.
        if (transform.position.z > _topBound)
        {
            Destroy(gameObject);
        }
        // If the dog is below the screen, destroy it and announce the end of the game.
        else if (transform.position.z < _bottomBound)
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
        
        // If an aggressive animal is off-screen, destroy it.
        if (transform.position.x > _rightBound || transform.position.x < _leftBound)
        {
            Destroy(gameObject);
        }
    }
}
