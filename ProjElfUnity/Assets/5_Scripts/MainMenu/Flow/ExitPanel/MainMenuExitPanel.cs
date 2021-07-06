using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.MainMenu
{
    public class MainMenuExitPanel : MonoBehaviour
    {
        private int SELECTED = Animator.StringToHash("Selected");

        [SerializeField]
        private Animator m_yesAnimator = null;
        [SerializeField]
        private Animator m_noAnimator = null;

        private MainMenu.MainMenuStateMachine m_gamemode = null;

        private void Start()
        {
            m_gamemode = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<MainMenu.MainMenuStateMachine>();
        }

        public void SelectYes()
        {
            m_yesAnimator.SetBool(SELECTED, true);
            m_noAnimator.SetBool(SELECTED, false);
            m_gamemode?.SoundHandler.PlaySubMoveSound();
        }

        public void SelectNo()
        {
            m_yesAnimator.SetBool(SELECTED, false);
            m_noAnimator.SetBool(SELECTED, true);
            m_gamemode?.SoundHandler.PlaySubMoveSound();
        }

        public void UnselectAll()
        {
            m_yesAnimator.SetBool(SELECTED, false);
            m_noAnimator.SetBool(SELECTED, false);
        }

    }
}