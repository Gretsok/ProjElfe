using MOtter;
using MOtter.StatesMachine;
using TMPro;
using UnityEngine;

public class DemoState : State
{
    [SerializeField] private string txt = "";
    [SerializeField] private TextMeshPro text = null;

    #region waitTime
    [SerializeField] private float timeToWait = 2f;
    private float timeOfStart = 0;
    public bool affectedByTime = true;
    #endregion

    PauseableStateMachine m_mainSM;

    public override void EnterState()
    {
        base.EnterState();
        timeOfStart = Time.time;
        m_mainSM = MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<PauseableStateMachine>();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        text.text = txt;
        if(affectedByTime && Time.time - timeOfStart > timeToWait)
        {
            m_mainSM.SwitchToNextState();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(m_mainSM.IsPaused)
            {
                m_mainSM.Unpause();
            }
            else
            {
                m_mainSM.Pause();
            }
        }
    }
}
