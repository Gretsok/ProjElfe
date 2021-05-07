using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuPanel : Panel
{
    [SerializeField]
    private SoundVolumeModule m_musicVolumeWidget = null;
    [SerializeField]
    private SoundVolumeModule m_sfxVolumeWidget = null;

    public SoundVolumeModule MusicVolumeWidget => m_musicVolumeWidget;

    private void Start()
    {
        m_musicVolumeWidget.value = MOtter.MOtterApplication.GetInstance().SOUND.GetVolume(MOtter.SoundManagement.ESoundCategoryName.Music);
        m_sfxVolumeWidget.value = MOtter.MOtterApplication.GetInstance().SOUND.GetVolume(MOtter.SoundManagement.ESoundCategoryName.SFX);
        // GET
    }


    public void OnMusicVolumeChanged()
    {
        MOtter.MOtterApplication.GetInstance().SOUND.SetVolume(m_musicVolumeWidget.value, MOtter.SoundManagement.ESoundCategoryName.Music);
    }

    public void OnSFXVolumeChanged()
    {
        MOtter.MOtterApplication.GetInstance().SOUND.SetVolume(m_sfxVolumeWidget.value, MOtter.SoundManagement.ESoundCategoryName.SFX);
    }

    public void OnCameraSensibilityChanged()
    {
        // SET
            // Set sensibility in save data
            // directly apply sensibility to player
    }

}
