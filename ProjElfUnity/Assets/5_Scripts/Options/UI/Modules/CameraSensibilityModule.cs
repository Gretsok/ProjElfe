using UnityEngine;
using UnityEngine.UI;

public class CameraSensibilityModule : OptionsMenuModule
{
    [SerializeField]
    private Slider m_sensibilitySlider = null;

    public Slider SensibilitySlider => m_sensibilitySlider;
}
