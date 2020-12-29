using MOtter;
using MOtter.StatesMachine;
using ProjElf.PlayerController;
using UnityEngine;

public class ProjElfGameMode : PauseableStateMachine, IProjElfMainStateMachine
{
    [SerializeField]
    protected Player m_player = null;
    public Player Player => m_player;

    public PlayerInputsActions Actions => m_player.Actions;

    #region Passing Time
    private float m_timeOfStart = 0;
    #endregion

    internal override void EnterStateMachine()
    {
        base.EnterStateMachine();
        Cursor.visible = false;
        m_timeOfStart = Time.time;
    }
    public override void DoUpdate()
    {
        base.DoUpdate();
    }

    public override void DoFixedUpdate()
    {
        base.DoFixedUpdate();
    }

    public override void DoLateUpdate()
    {
        base.DoLateUpdate();
    }

    public override void Pause()
    {
        base.Pause();
    }

    public override void Unpause()
    {
        base.Unpause();
    }

    internal override void ExitStateMachine()
    {
        float m_timePassed = Time.time - m_timeOfStart;
        MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>().SavedPlayerStats.TimePlayed += (int) m_timePassed;
        MOtterApplication.GetInstance().GAMEMANAGER.SaveDataManager.SaveSaveDataManager();
        m_player.CleanUp();
        base.ExitStateMachine();
    }


}
