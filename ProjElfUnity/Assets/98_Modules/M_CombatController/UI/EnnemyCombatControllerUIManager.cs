﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProjElf.AI
{
    public class EnnemyCombatControllerUIManager : ProjElf.CombatController.CombatControllerUIManager
    {
        [SerializeField]
        private Image m_healthSlider = null;
        internal override void SetHealthRatio(float healthRatio)
        {
            base.SetHealthRatio(healthRatio);
            m_healthSlider.fillAmount = healthRatio;
        }
    }
}