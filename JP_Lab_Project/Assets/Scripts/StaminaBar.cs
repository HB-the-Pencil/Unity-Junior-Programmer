using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] Slider slider;

    public void UpdateStamina(float current, float max)
    {
        slider.value = current / max;
    }
}
