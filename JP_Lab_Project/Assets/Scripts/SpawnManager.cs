using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int enemyCount;

    [SerializeField] GameObject enemyPrefab;

    private float _spawnRadius = 9f;
    private int _wave = 1;

    void Update()
    {
        if (enemyCount <= 0)
        {
            SpawnEnemies(_wave);
        }
    }

    void SpawnEnemies(int howMany)
    {
        for (int i = 0; i < howMany; i++)
        {
            Vector3 spawnLocation = new Vector3(
                Random.Range(-_spawnRadius, _spawnRadius),
                0f, 
                Random.Range(-_spawnRadius, _spawnRadius));

            Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);

            enemyCount++;
        }

        _wave++;
    }
}
