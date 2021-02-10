using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProjElf.PlayerController
{
    public class PlayerCombatControllerUIManager : CombatController.CombatControllerUIManager
    {
        [SerializeField]
        private Slider m_healthSlider = null;

        internal override void SetHealthRatio(float healthRatio)
        {
            base.SetHealthRatio(healthRatio);
            m_healthSlider.value = healthRatio;
        }
    }
}