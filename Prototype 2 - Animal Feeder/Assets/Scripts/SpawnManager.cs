using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    
    private float _spawnRangeX = 15;
    private float _spawnRangeZ = 20;

    private float _startDelay = 2;
    private float _spawnInterval = 1.5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", _startDelay, _spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 animalPosition = new Vector3(
            Random.Range(-_spawnRangeX, _spawnRangeX), 0, _spawnRangeZ);
        Instantiate(animalPrefabs[animalIndex], animalPosition, 
            animalPrefabs[animalIndex].transform.rotation);
    }
}
