

using System.Collections;

namespace MOtter.StatesMachine
{
    public class MainStatesMachine : StatesMachine
    {
        private void Awake()
        {
            MOtterApplication.GetInstance().GAMEMANAGER.RegisterNewMainStateMachine(this);
        }

        
    }
}