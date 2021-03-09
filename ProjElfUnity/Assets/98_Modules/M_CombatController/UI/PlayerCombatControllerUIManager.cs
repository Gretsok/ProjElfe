using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProjElf.PlayerController
{
    public class PlayerCombatControllerUIManager : CombatController.CombatControllerUIManager
    {
        [SerializeField]
        private Image m_healthSlider = null;
        [SerializeField]
        private PlayerWeaponsDisplay m_weaponsDisplay = null;
        public PlayerWeaponsDisplay WeaponsDisplay => m_weaponsDisplay;

        internal override void SetHealthRatio(float healthRatio)
        {
            base.SetHealthRatio(healthRatio);
            m_healthSlider.fillAmount = healthRatio;
        }
    }
}