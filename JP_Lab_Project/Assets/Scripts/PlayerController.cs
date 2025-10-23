using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public bool playing;
    
    [SerializeField] GameObject cam;
    
    public PlayerActions Controls;
    public CharacterController body;
    private PlayerSpecialAbility specialHandler;
    // private PlayerAttack attackHandler; // not yet implemented

    private float _camInput;
    private Vector2 _moveInput;

    private readonly float _camSpeed = 30f;
    private readonly float _moveSpeed = 10f;

    private void Awake()
    {
        // Get the player's controller.
        body = GetComponent<CharacterController>();
        
        // Find the Special and Attack controller scripts so they can talk back and forth.
        specialHandler = GetComponent<PlayerSpecialAbility>();
        // attackHandler = GetComponent<PlayerAttack>(); // not yet implemented
        
        // Get the controls.
        Controls = new PlayerActions();
    }

    private void OnEnable()
    {
        Controls.Enable();
    }
    
    private void OnDisable()
    {
        Controls.Disable();
    }

    private void Start()
    {
        // Lock the cursor and begin.
        Unpause();
    }

    private void Update()
    {
        // Turn the camera.
        _camInput = Controls.Camera.TurnCam.ReadValue<float>();
        transform.Rotate(0, _camInput * _camSpeed * Time.deltaTime, 0);
        
        // Move the player.
        DoMove();
        
        // Attack abilities. (no enemies yet, so no attacks)
        DoAttack();
        
        specialHandler.DoSpecial();

        if (Controls.UI.Pause.triggered)
        {
            Pause();
        }
    }

    private void Pause()
    {
        // Unlock the cursor.
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Unpause()
    {
        // Lock the cursor.
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void DoMove()
    {
        _moveInput = Controls.Movement.Move.ReadValue<Vector2>();
            
        // Normalize the movement and point it forward.
        Vector3 movement = transform.right * _moveInput.x + transform.forward * _moveInput.y;
        movement = movement.normalized * (_moveSpeed * Time.deltaTime);
            
        body.Move(movement);
    }
    
    private void DoAttack()
    {
        if (Controls.Abilities.Attack.triggered)
        {
            // do attacky things here
            Debug.Log("bop");
        }
    }
}
