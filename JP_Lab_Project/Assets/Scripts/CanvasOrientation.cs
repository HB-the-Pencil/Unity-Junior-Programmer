using UnityEngine;

public class CanvasOrientation : MonoBehaviour
{
    private GameObject _cam;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _cam = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = _cam.transform.rotation;
    }
}
