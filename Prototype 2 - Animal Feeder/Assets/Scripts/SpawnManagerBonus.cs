using UnityEngine;

public class SpawnManagerBonus : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public GameObject[] aggressiveAnimalPrefabs;
    
    // For spawning top animals.
    private float _spawnRangeX = 15;
    private float _spawnDistZ = 20;
    
    // For spawning side animals.
    private float _spawnRangeZ = 5;
    private float _spawnDistX = 25;

    private float _startDelay = 2;
    private float _spawnInterval = 2;
    
    private float _aggressiveDelay = 5f;
    private float _aggressiveInterval = 2;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Spawn the animal on a repeating timer.
        InvokeRepeating(
            "SpawnRandomAnimal", _startDelay, _spawnInterval);
        
        InvokeRepeating(
            "SpawnRandomAggressiveAnimal", _aggressiveDelay, 
            _aggressiveInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimal()
    {
        // Pick a random animal to spawn and spawn it at a random location.
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        
        _spawnInterval = Random.Range(2, 5);
        
        Vector3 animalPosition = new Vector3(
            Random.Range(-_spawnRangeX, _spawnRangeX), 0, _spawnDistZ);
        Instantiate(animalPrefabs[animalIndex], animalPosition, 
            animalPrefabs[animalIndex].transform.rotation);
    }
    
    void SpawnRandomAggressiveAnimal()
    {
        // Pick a random animal to spawn and spawn it at a random location.
        int aggressiveIndex = Random.Range(0, aggressiveAnimalPrefabs.Length);
        int side = Random.Range(0, 2) * 2 - 1;

        _aggressiveInterval = Random.Range(2, 4);

        Quaternion rotation = Quaternion.Euler(0, -90f * side, 0);
        
        Vector3 animalPosition = new Vector3(
            _spawnDistX * side, 0, Random.Range(-_spawnRangeZ, _spawnRangeZ) + 5);
        Instantiate(aggressiveAnimalPrefabs[aggressiveIndex], animalPosition, rotation);
    }
}
