using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] MeshRenderer Renderer;
    private Material _material;

    private float _time;
    
    // Speed to bob and spin.
    private float _speed;
    private float _rotateSpeed;
    
    // Modifies which directions the cube spins in.
    private Vector3 _rotVector;
    
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * Random.Range(1f, 3f);
        
        _speed = Random.Range(1f, 5f);
        _rotateSpeed = Random.Range(30f, 90f);
        
        _rotVector = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        
        _material = Renderer.material;
    }
    
    void Update()
    {
        // Bob and spin the cube.
        transform.position = new Vector3(0, Mathf.Sin(_time * _speed) + 4, 0);
        transform.Rotate(_rotVector * (_rotateSpeed * Time.deltaTime));
        
        // Now the cube twists!
        _rotVector.y = Mathf.Cos(_time * _speed) * 2;
        
        // Change the color of the cube.
        Color color = Color.HSVToRGB((_time % 10) / 10, 1, 1);
        _material.color = new Color(color.r, color.g, color.b, 0.2f);
        
        _time += Time.deltaTime;
    }
}
