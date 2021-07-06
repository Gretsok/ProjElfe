using MOtter.StatesMachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LanguageModule : Selectable
{

    private MainStatesMachine m_GameMode = null;
    protected override void Start()
    {
        base.Start();
        m_GameMode = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<MainStatesMachine>();
    }

    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);
        if (m_GameMode is ProjElf.MainMenu.MainMenuStateMachine)
        {
            (m_GameMode as ProjElf.MainMenu.MainMenuStateMachine).SoundHandler.PlaySubMoveSound();
        }
    }

    public void GoRight()
    {
        Debug.Log("Go right");
        MOtter.MOtterApplication.GetInstance().LOCALIZATION.SwitchToNextLanguage();
        if (m_GameMode is ProjElf.MainMenu.MainMenuStateMachine)
        {
            (m_GameMode as ProjElf.MainMenu.MainMenuStateMachine).SoundHandler.PlaySubMoveSound();
        }
    }

    public void GoLeft()
    {
        Debug.Log("Go left");
        MOtter.MOtterApplication.GetInstance().LOCALIZATION.SwitchToPreviousLanguage();
        if (m_GameMode is ProjElf.MainMenu.MainMenuStateMachine)
        {
            (m_GameMode as ProjElf.MainMenu.MainMenuStateMachine).SoundHandler.PlaySubMoveSound();
        }
    }

    public override void OnMove(AxisEventData eventData)
    {
        base.OnMove(eventData);
        if(eventData.moveDir == MoveDirection.Left)
        {
            GoLeft();
        }
        else if(eventData.moveDir == MoveDirection.Right)
        {
            GoRight();
        }

        
    }
}
