using UnityEngine;
using UnityEngine.AI;

public class SpawnManager : MonoBehaviour
{
    private Vector3 spawnPosition = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    
    [SerializeField] private GameObject spawnPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void SpawnObstacle()
    {
        Instantiate(spawnPrefab, spawnPosition, spawnPrefab.transform.rotation);
    }
}
