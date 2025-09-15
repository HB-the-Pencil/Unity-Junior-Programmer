using UnityEngine;
using UnityEngine.UI;

public class HealthBarBonus : MonoBehaviour
{
    private Slider _slider;

    public void UpdateHealth(float current, float max)
    {
        _slider.value = current / max;
    }
}
