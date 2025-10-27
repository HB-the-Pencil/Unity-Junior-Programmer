using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] Slider staminaSlider;

    public void UpdateStamina(float current, float max)
    {
        staminaSlider.value = current / max;
    }
}
