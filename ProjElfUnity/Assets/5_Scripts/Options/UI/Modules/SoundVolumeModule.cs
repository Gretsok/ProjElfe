using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeModule : OptionsMenuModule
{
    [SerializeField]
    private Slider m_volumeSlider = null;

    public Slider VolumeSlider => m_volumeSlider;
}
