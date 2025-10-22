using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private Slider stamina;

    private void Start()
    {
        stamina = GetComponentInChildren<Slider>();
    }

    public void UpdateStamina(float current, float max)
    {
        stamina.value = current / max;
    }
}
