using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using MOtter.Utils;

namespace ProjElf.AI
{
    public class EnnemyCombatControllerUIManager : ProjElf.CombatController.CombatControllerUIManager
    {
        [SerializeField]
        private Image m_healthSlider = null;

        [SerializeField]
        private TMP_Text m_healthRemaining = null;

        [SerializeField]
        private Billboard m_billboard = null;

        internal override void InitWithGamemode(ProjElfGameMode a_gamemode)
        {
            base.InitWithGamemode(a_gamemode);
            m_billboard.SetCamera(a_gamemode.Player.CameraController.CameraTransform);
        }

        internal override void SetHealthRatio(float healthRatio)
        {
            base.SetHealthRatio(healthRatio);
            m_healthSlider.fillAmount = healthRatio;
        }
        internal override void SetHealthRemaining(float healthRemaining)
        {
            base.SetHealthRemaining(healthRemaining);
            m_healthRemaining.text = healthRemaining.ToString();
        }
    }
}