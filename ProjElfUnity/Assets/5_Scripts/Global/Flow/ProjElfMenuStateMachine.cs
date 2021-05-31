using MOtter.StatesMachine;
using UnityEngine.InputSystem;

public class ProjElfMenuStateMachine : MainStatesMachine, IProjElfMainStateMachine
{
    protected InputActionAsset m_actions = null;
    public InputActionAsset Actions => m_actions;

    private void OnDestroy()
    {
        MOtter.MOtterApplication.GetInstance().SAVE.SaveSaveDataManager();
    }
}
