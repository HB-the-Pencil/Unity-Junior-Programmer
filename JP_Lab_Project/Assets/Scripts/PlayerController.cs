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
    private float _cooldown;
    private bool _specialActive;

    private void Awake()
    {
        // Get the player's controller.
        _body = GetComponent<CharacterController>();
        _controls = new PlayerActions();
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
            DoMove();
            
            // Attack abilities. (no enemies yet, so no attacks)
            DoAttack();
            
            // Dash abilities. Currently, only dash is available, but this may change.
            DoSpecial("dash");
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

    private void DoMove()
    {
        _moveInput = _controls.Movement.Move.ReadValue<Vector2>();
            
        // Normalize the movement and point it forward.
        Vector3 movement = transform.right * _moveInput.x + transform.forward * _moveInput.y;
        movement = movement.normalized * (_moveSpeed * Time.deltaTime);
            
        _body.Move(movement);
    }
    
    private void DoAttack()
    {
        if (_controls.Abilities.Attack.triggered)
        {
            // do attacky things here
            Debug.Log("bop");
        }
    }

    private void DoSpecial(string special)
    {
        if (_cooldown <= 0)
        {
            // Hide the stamina bar.
            staminaBar.transform.gameObject.SetActive(false);
                
            if (_controls.Abilities.Special.triggered)
            {
                _specialActive = true;
                _cooldown = 0f;
            }
        }

        if (_specialActive)
        {
            // Use the dash special.
            if (special == "dash")
            {
                if (_cooldown < _dashDuration)
                {
                    // Dash forward.
                    _body.Move(transform.forward * (_dashSpeed * Time.deltaTime));
                    _cooldown += Time.deltaTime;
                }
                else
                {
                    _specialActive = false;
                    _cooldown = _dashCooldown;

                    // Make the stamina bar appear.
                    staminaBar.transform.gameObject.SetActive(true);
                }
            }
        }

        if (!_specialActive)
        {
            // Decrease the cooldown.
            _cooldown -= Time.deltaTime;
            staminaBar.UpdateStamina(_cooldown, _dashCooldown);
        }
    }
}
