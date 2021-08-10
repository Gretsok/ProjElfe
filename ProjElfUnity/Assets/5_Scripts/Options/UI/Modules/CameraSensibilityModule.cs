﻿using MOtter.StatesMachine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraSensibilityModule : Slider
{
    private MainStatesMachine m_GameMode = null;
    protected override void Start()
    {
        base.Start();
    }

    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);
        if (m_GameMode == null)
            m_GameMode = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<MainStatesMachine>();
        if (m_GameMode is ProjElf.MainMenu.MainMenuStateMachine)
        {
            (m_GameMode as ProjElf.MainMenu.MainMenuStateMachine).SoundHandler.PlaySubMoveSound();
        }
    }
}
