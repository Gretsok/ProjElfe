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

        public void SelectYes()
        {
            m_yesAnimator.SetBool(SELECTED, true);
            m_noAnimator.SetBool(SELECTED, false);
        }

        public void SelectNo()
        {
            m_yesAnimator.SetBool(SELECTED, false);
            m_noAnimator.SetBool(SELECTED, true);
        }

        public void UnselectAll()
        {
            m_yesAnimator.SetBool(SELECTED, false);
            m_noAnimator.SetBool(SELECTED, false);
        }

    }
}