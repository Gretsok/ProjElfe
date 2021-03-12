using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.MainMenu
{ 
    public class CreateCharacterButtonNavigationPosition : ButtonNavigationPosition
    {
        protected override void Start()
        {
            base.Start();

            m_state = m_mainStatesMachine.CreateCharacterState;
        }
    }
}