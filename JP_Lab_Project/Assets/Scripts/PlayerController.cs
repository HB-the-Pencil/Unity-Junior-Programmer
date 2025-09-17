using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool playing;
    
    [SerializeField] GameObject cam;
    [SerializeField] StaminaBar staminaBar;
    
    private PlayerActions _controls;
    private CharacterController _body;

    private float _camInput;
    private Vector2 _moveInput;

    private readonly float _camSpeed = 30f;
    private readonly float _moveSpeed = 10f;
    private readonly float _attackSpeed = 1f;
    
    // Speed: the rate at which character dashes forward
    // Cooldown: the time in seconds that the ability is inactive after use
    // Duration: the time in seconds that the ability is used
    // Time: how long the player has been using the ability
    // Dashing: whether the player is using the ability
    private readonly float _dashSpeed = 30f;
    private readonly float _dashCooldown = 1f;
    private readonly float _dashDuration = 0.3f;
    private float _dashTime;
    private bool _dashing;

    private void Awake()
    {
        // Get the player's controller.
        _body = GetComponent<CharacterController>();
        _controls = new PlayerActions();
        
        // Set up the UI bars.
        staminaBar = GetComponentInChildren<StaminaBar>();
    }

    private void OnEnable()
    {
        _controls.Enable();
    }
    
    private void OnDisable()
    {
        _controls.Disable();
    }

    private void Start()
    {
        // Lock the cursor and begin.
        Unpause();
    }

    private void Update()
    {
        if (playing)
        {
            // Turn the camera.
            _camInput = _controls.Camera.TurnCam.ReadValue<float>();
            transform.Rotate(0, _camInput * _camSpeed * Time.deltaTime, 0);
            
            // Move the player.
            _moveInput = _controls.Movement.Move.ReadValue<Vector2>();
            
            // Normalize the movement and point it forward.
            Vector3 movement = transform.right * _moveInput.x + transform.forward * _moveInput.y;
            movement = movement.normalized * (_moveSpeed * Time.deltaTime);
            
            _body.Move(movement);
            
            // Attack abilities. (no enemies yet, so no attacks)
            if (_controls.Abilities.Attack.triggered)
            {
                // do attacky things here
                Debug.Log("bop");
            }
            
            // Dash abilities.
            if (_dashTime <= 0)
            {
                // Hide the stamina bar.
                staminaBar.transform.gameObject.SetActive(false);
                
                if (_controls.Abilities.Special.triggered)
                {
                    _dashing = true;
                    _dashTime = 0f;
                }
            }

            if (_dashing)
            {
                if (_dashTime < _dashDuration)
                {
                    // Dash forward.
                    _body.Move(transform.forward * (_dashSpeed * Time.deltaTime));
                    _dashTime += Time.deltaTime;
                }
                else
                {
                    _dashing = false;
                    _dashTime = _dashCooldown;
                    
                    // Make the stamina bar appear.
                    staminaBar.transform.gameObject.SetActive(true);
                }
            }

            if (!_dashing)
            {
                // Decrease the cooldown.
                _dashTime -= Time.deltaTime;
                staminaBar.UpdateStamina(_dashTime, _dashCooldown);
            }
        }

        if (_controls.UI.Pause.triggered)
        {
            Pause();
        }
    }

    public void Pause()
    {
        // Unlock the cursor.
        playing = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Unpause()
    {
        // Lock the cursor.
        playing = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
