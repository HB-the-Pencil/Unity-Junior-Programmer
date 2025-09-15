using UnityEngine;

public class DetectCollisionsBonus : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Destroy the animal and the steak.
        if (other.gameObject.CompareTag("Steak"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            PlayerControllerBonus.UpdateScore(10);
        }

        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("Bird"))
        {
            Destroy(gameObject);
            PlayerControllerBonus.UpdateLives(-1);
        }
    }
}
