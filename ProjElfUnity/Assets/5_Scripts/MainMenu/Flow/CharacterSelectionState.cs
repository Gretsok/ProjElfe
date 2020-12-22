using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.MainMenu
{
    public class CharacterSelectionState : MainMenuNavigationState
    {
        [SerializeField]
        private SavedProfilesManager m_savedProfilesManager = null;

        private int m_positionIndex = 0;

        private bool m_hasInflate = false;

        public override void EnterState()
        {
            base.EnterState();
            if(!m_hasInflate)
            {
                m_savedProfilesManager.Inflate();
            }
            m_positionIndex = m_savedProfilesManager.NumberOfNavigationPositions;
            
        }

        protected override void GoLeft()
        {
            base.GoLeft();

            if (m_positionIndex == m_savedProfilesManager.NumberOfNavigationPositions)
            {
                m_mainStateMachine.SwitchToOptionsState();
            }
        }

        protected override void GoRight()
        {
            base.GoRight();

            if (m_positionIndex == m_savedProfilesManager.NumberOfNavigationPositions)
            {
                m_mainStateMachine.SwitchToCreditsState();
            }   
        }

        protected override void GoUp()
        {
            base.GoUp();

            if (m_positionIndex == m_savedProfilesManager.NumberOfNavigationPositions)
            {
                m_positionIndex = 0;
                m_savedProfilesManager.SelectPosition(m_positionIndex);
            }
            else if(m_positionIndex > 0)
            {
                m_positionIndex--;
                m_savedProfilesManager.SelectPosition(m_positionIndex);
            }
            else if(m_positionIndex == 0)
            {
                m_positionIndex = m_savedProfilesManager.NumberOfNavigationPositions;
                // back to navigation bar
            }

        }

        protected override void GoDown()
        {
            base.GoDown();

            if (m_positionIndex == m_savedProfilesManager.NumberOfNavigationPositions)
            {
                m_positionIndex = 0;
                m_savedProfilesManager.SelectPosition(m_positionIndex);
            }
            else if (m_positionIndex < m_savedProfilesManager.NumberOfNavigationPositions - 1)
            {
                m_positionIndex++;
                m_savedProfilesManager.SelectPosition(m_positionIndex);
            }
            else if (m_positionIndex == m_savedProfilesManager.NumberOfNavigationPositions - 1)
            {
                m_positionIndex = m_savedProfilesManager.NumberOfNavigationPositions;
                // back to navigation bar
            }
        }

    }
}