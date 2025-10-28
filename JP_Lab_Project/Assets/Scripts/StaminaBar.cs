using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private Slider _staminaSlider;

    void Start()
    {
       _staminaSlider = GetComponentInChildren<Slider>();
    }

public void UpdateStamina(float current, float max)
    {
        _staminaSlider.value = current / max;
    }
}
