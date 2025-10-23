using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private Slider _stamina;

    private void Start()
    {
        _stamina = GetComponentInChildren<Slider>();
    }

    public void UpdateStamina(float current, float max)
    {
        _stamina.value = current / max;
    }
}
