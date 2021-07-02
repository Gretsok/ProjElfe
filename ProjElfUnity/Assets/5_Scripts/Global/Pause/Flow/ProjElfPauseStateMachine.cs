using MOtter;
using MOtter.StatesMachine;
using ProjElf.SceneData;
using UnityEngine;

public class ProjElfPauseStateMachine : StatesMachine
{
    private ProjElfGameMode m_gamemode = null;
    [SerializeField]
    private State m_pauseMenuState = null;
    [SerializeField]
    private State m_pauseOptionsState = null;
    [SerializeField]
    private SceneData m_mainMenuSceneData = null;

    private void Start()
    {
        m_gamemode = MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<ProjElfGameMode>();
    }

    internal override void EnterStateMachine()
    {
        base.EnterStateMachine();
        m_gamemode.Player.CombatController.UIManager.Hide();
    }

    internal override void ExitStateMachine()
    {
        m_gamemode.Player.CombatController.UIManager.Show();
        base.ExitStateMachine();
    }

    public void UnPause()
    {
        m_gamemode.Unpause();
    }

    public void GoToOptions()
    {
        SwitchToState(m_pauseOptionsState);
    }

    public void GoToPauseMenu()
    {
        SwitchToState(m_pauseMenuState);
    }

    public void GoToMainMenu(bool save)
    {
        if(save)
        {
            m_gamemode.SaveData();
            m_gamemode.SavePlayerWeapons();
        }
        m_gamemode.Unpause();
        m_mainMenuSceneData.LoadLevel();
    }

    public void QuitGame(bool save)
    {
        if (save)
        {
            m_gamemode.SaveData();
            m_gamemode.SavePlayerWeapons();
        }
        Application.Quit();
    }
}
