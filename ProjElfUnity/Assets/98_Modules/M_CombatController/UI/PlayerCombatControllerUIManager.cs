using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace ProjElf.PlayerController
{
    public class PlayerCombatControllerUIManager : CombatController.CombatControllerUIManager
    {
        [SerializeField]
        private Image m_healthSlider = null;
        [SerializeField]
        private PlayerWeaponsDisplay m_weaponsDisplay = null;
        public PlayerWeaponsDisplay WeaponsDisplay => m_weaponsDisplay;

        [SerializeField]
        private TMP_Text m_healthRemaining;

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