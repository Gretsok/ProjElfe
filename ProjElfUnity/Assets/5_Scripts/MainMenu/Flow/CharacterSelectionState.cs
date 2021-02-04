﻿using MOtter;
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
                m_savedProfilesManager.Inflate(MOtterApplication.GetInstance().GAMEMANAGER.SaveDataManager.SaveDataList.ToArray());
                m_hasInflate = true;
            }
            m_positionIndex = m_savedProfilesManager.NumberOfNavigationPositions;
            m_savedProfilesManager.UnselectCurrentSelection();
        }

       

        protected override void GoUp()
        {
            base.GoUp();
            /*if (m_positionIndex == m_savedProfilesManager.NumberOfNavigationPositions)
            {
                m_positionIndex = 0;
                m_savedProfilesManager.SelectPosition(m_positionIndex);
            }
            else*/ if(m_positionIndex > 0)
            {
                m_positionIndex--;
                m_savedProfilesManager.SelectPosition(m_positionIndex);
            }
            else if(m_positionIndex == 0)
            {
                m_positionIndex = m_savedProfilesManager.NumberOfNavigationPositions;
                // back to navigation bar
                m_savedProfilesManager.UnselectCurrentSelection();
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
                m_savedProfilesManager.UnselectCurrentSelection();
            }
        }

        protected override void Confirm()
        {
            base.Confirm();
            if(m_positionIndex < m_savedProfilesManager.NumberOfNavigationPositions)
            {
                if(m_savedProfilesManager.IsCurrentSelectionCreateCharacterButton())
                {
                    m_mainStateMachine.SwitchToCreateCharacterState();
                }
                else
                {
                    // Load Game with correct Save Data
                    Debug.Log("TRYING TO LOAD A SAVE");
                    m_mainStateMachine.LoadHub(m_savedProfilesManager.GetSaveDataByPositionIndex(m_positionIndex));
                }
            }
           
        }

    }
}