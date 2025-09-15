using UnityEngine;
using UnityEngine.UI;

public class HealthBarBonus : MonoBehaviour
{
    [SerializeField] Slider slider;

    public void UpdateHealth(float current, float max)
    {
        slider.value = current / max;
    }
}
