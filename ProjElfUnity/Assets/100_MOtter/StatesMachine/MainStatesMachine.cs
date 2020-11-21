

namespace MOtter.StatesMachine
{
    public class MainStatesMachine : StatesMachine
    {
        private void Start()
        {
            MOtterApplication.GetInstance().GAMEMANAGER.RegisterNewMainStateMachine(this);
        }
    }
}