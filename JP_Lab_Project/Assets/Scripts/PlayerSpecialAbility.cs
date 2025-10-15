using UnityEngine;

public class PlayerSpecialAbility : MonoBehaviour
{
    enum Abilities
    {
        Dash,
    }
    
    [SerializeField] StaminaBar staminaBar;
    [SerializeField] private Abilities ability = Abilities.Dash;
    
    // DASH ABILITY
    // Speed: the rate at which character dashes forward
    // Cooldown: the time in seconds that the ability is inactive after use
    // Duration: the time in seconds that the ability is used
    private readonly float _dashSpeed = 30f;
    private readonly float _dashCooldown = 1f;
    private readonly float _dashDuration = 0.3f;
    
    // How long before the ability can be used again?
    private float _cooldown;
    private bool _specialActive;
    
    private PlayerController _player;
    private CharacterController _body;

    void Start()
    {
        _body = GetComponent<CharacterController>();
        
        // Find the main controller script so they can talk back and forth.
        _player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    public void DoSpecial()
    {
        if (_cooldown <= 0)
        {
            // Hide the stamina bar.
            staminaBar.transform.gameObject.SetActive(false);
                
            if (_player.controls.Abilities.Special.triggered)
            {
                _specialActive = true;
                _cooldown = 0f;
            }
        }

        if (_specialActive)
        {
            // Use the dash special.
            if (ability == Abilities.Dash)
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
