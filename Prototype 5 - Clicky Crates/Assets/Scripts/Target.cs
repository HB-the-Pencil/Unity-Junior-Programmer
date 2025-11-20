using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] int points;
    [SerializeField] ParticleSystem explosionParticles;
    
    private Rigidbody _targetRb;
    private GameManager _gameManager;

    private float _minSpeed = 12;
    private float _maxSpeed = 16;

    private float _maxTorque = 1.5f;
    private float _xRange = 4;
    private float _ySpawnPos = -2;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        _targetRb = GetComponent<Rigidbody>();
        transform.position = RandomSpawn();
        
        _targetRb.AddForce(RandomLaunchForce(), ForceMode.Impulse);
        _targetRb.AddTorque(RandomTorque(), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDrag()
    {
        if (!_gameManager.isGameOver)
        {
            _gameManager.UpdateScore(points);
            Instantiate(explosionParticles, transform.position, explosionParticles.transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Bad"))
        {
            _gameManager.GameOver();
        }
        Destroy(gameObject);
    }

    private Vector3 RandomLaunchForce()
    {
        return Vector3.up * Random.Range(_minSpeed, _maxSpeed);
    }

    private Vector3 RandomTorque()
    {
        return Vector3.one * Random.Range(-_maxTorque, _maxTorque);
    }

    private Vector3 RandomSpawn()
    {
        return new Vector3(Random.Range(-_xRange, _xRange), _ySpawnPos);
    }
}
