using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuPanel : Panel
{
    [SerializeField]
    private SoundVolumeModule m_musicVolumeWidget = null;
    [SerializeField]
    private SoundVolumeModule m_sfxVolumeWidget = null;
    [SerializeField]
    private CameraSensibilityModule m_cameraSensibilityWidget = null;
    public SoundVolumeModule MusicVolumeWidget => m_musicVolumeWidget;

    private ProjElfGameMode m_GameMode = null ;


    private void Start()
    {
        m_musicVolumeWidget.value = MOtter.MOtterApplication.GetInstance().SOUND.GetVolume(MOtter.SoundManagement.ESoundCategoryName.Music);
        m_sfxVolumeWidget.value = MOtter.MOtterApplication.GetInstance().SOUND.GetVolume(MOtter.SoundManagement.ESoundCategoryName.SFX);
        // GET PlayerState -> m_cameraSensibility
        m_cameraSensibilityWidget.value = MOtter.MOtterApplication.GetInstance().SAVE.CameraSensitivity;

        m_GameMode = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<ProjElfGameMode>();

        Debug.Log("cam sensi = " + m_cameraSensibilityWidget.value);
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
        MOtter.MOtterApplication.GetInstance().SAVE.CameraSensitivity = m_cameraSensibilityWidget.value;
        MOtter.MOtterApplication.GetInstance().SAVE.SaveSaveDataManager();
        if(m_GameMode != null)
        {
            m_GameMode.Player.SetCameraSensitivity(m_cameraSensibilityWidget.value);
        }
        
        Debug.Log("cam sensi = " + m_cameraSensibilityWidget.value);
    }

}
