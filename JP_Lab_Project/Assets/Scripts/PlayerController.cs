using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool playing;
    public PlayerActions Controls;
    public CharacterController body;
    
    private PlayerSpecialAbility _specialHandler;
    private PlayerAttack _attackHandler;
    
    public HealthBar healthBar;
    // private Animator _animator;

    private float _camInput;
    private Vector2 _moveInput;

    private readonly float _camSpeed = 30f;
    private readonly float _moveSpeed = 10f;

    private void Awake()
    {
        // Get the player's controller.
        body = GetComponent<CharacterController>();
        
        // Find the Special and Attack controller scripts so they can talk back and forth.
        _specialHandler = GetComponent<PlayerSpecialAbility>();
        _attackHandler = GetComponent<PlayerAttack>();
        
        healthBar = GetComponentInChildren<HealthBar>();
        // _animator = GetComponent<Animator>();
        
        // Get the controls.
        Controls = new PlayerActions();
        
        // Lock the cursor and begin.
        Unpause();
    }
    
    private void OnEnable()
    {
        Controls.Enable();
    }
    
    private void OnDisable()
    {
        Controls.Disable();
    }

    private void Update()
    {
        // Turn the camera.
        _camInput = Controls.Camera.TurnCam.ReadValue<float>();
        transform.Rotate(0, _camInput * _camSpeed * Time.deltaTime, 0);
        
        // Move the player.
        DoMove();
        
        // Attack and special abilities.
        _attackHandler.DoAttack();
        _specialHandler.DoSpecial();

        // _animator.SetBool("Invulnerable", _healthBar.invulnerable);

        if (Controls.UI.Pause.triggered)
        {
            Pause();
        }

        if (healthBar.currentHealth <= 0)
        {
            GameOver();
        }
    }

    private void Pause()
    {
        // Unlock the cursor.
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Controls.Disable();
    }

    public void Unpause()
    {
        // Lock the cursor.
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Controls.Enable();
    }

    public void GameOver()
    {
        // this will be fancier later
        Pause();
        print("Game Over");
    }

    private void DoMove()
    {
        _moveInput = Controls.Movement.Move.ReadValue<Vector2>();
            
        // Normalize the movement and point it forward.
        Vector3 movement = transform.right * _moveInput.x + transform.forward * _moveInput.y;
        movement = movement.normalized * (_moveSpeed * Time.deltaTime);
            
        body.Move(movement);
    }
}
