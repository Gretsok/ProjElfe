using MOtter.StatesMachine;
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

    private MainStatesMachine m_GameMode = null ;


    private void Start()
    {
        m_musicVolumeWidget.value = MOtter.MOtterApplication.GetInstance().SOUND.GetVolume(MOtter.SoundManagement.ESoundCategoryName.Music);
        m_sfxVolumeWidget.value = MOtter.MOtterApplication.GetInstance().SOUND.GetVolume(MOtter.SoundManagement.ESoundCategoryName.SFX);
        // GET PlayerState -> m_cameraSensibility
        m_cameraSensibilityWidget.value = MOtter.MOtterApplication.GetInstance().SAVE.CameraSensitivity;

        m_GameMode = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<MainStatesMachine>();

        Debug.Log("cam sensi = " + m_cameraSensibilityWidget.value);
    }


    public void OnMusicVolumeChanged()
    {
        MOtter.MOtterApplication.GetInstance().SOUND.SetVolume(m_musicVolumeWidget.value, MOtter.SoundManagement.ESoundCategoryName.Music);
        if(m_GameMode is ProjElf.MainMenu.MainMenuStateMachine)
        {
            (m_GameMode as ProjElf.MainMenu.MainMenuStateMachine).SoundHandler.PlaySubMoveSound();
        }
    }

    public void OnSFXVolumeChanged()
    {
        MOtter.MOtterApplication.GetInstance().SOUND.SetVolume(m_sfxVolumeWidget.value, MOtter.SoundManagement.ESoundCategoryName.SFX);
        if (m_GameMode is ProjElf.MainMenu.MainMenuStateMachine)
        {
            (m_GameMode as ProjElf.MainMenu.MainMenuStateMachine).SoundHandler.PlaySubMoveSound();
        }
    }

    public void OnCameraSensibilityChanged()
    {
        // SET
        MOtter.MOtterApplication.GetInstance().SAVE.CameraSensitivity = m_cameraSensibilityWidget.value;
        MOtter.MOtterApplication.GetInstance().SAVE.SaveSaveDataManager();
        if(m_GameMode != null && m_GameMode is ProjElfGameMode)
        {
            (m_GameMode as ProjElfGameMode).Player.SetCameraSensitivity(m_cameraSensibilityWidget.value);
        }
        if (m_GameMode is ProjElf.MainMenu.MainMenuStateMachine)
        {
            (m_GameMode as ProjElf.MainMenu.MainMenuStateMachine).SoundHandler.PlaySubMoveSound();
        }

        Debug.Log("cam sensi = " + m_cameraSensibilityWidget.value);
    }

}
