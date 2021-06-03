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
        private Image m_backHealthSlider = null;

        [SerializeField]
        private TMP_Text m_healthRemaining = null;

        [SerializeField]
        private TMP_Text m_floatingDamage = null;

        [SerializeField]
        private Billboard m_billboard = null;

        private float slideDuration = 20f;
        private Coroutine m_healthCoRoutine;

        internal override void InitWithGamemode(ProjElfGameMode a_gamemode)
        {
            base.InitWithGamemode(a_gamemode);
            m_billboard.SetCamera(a_gamemode.Player.CameraController.CameraTransform);
        }

        internal override void SetHealthRatio(float healthRatio)
        {
            base.SetHealthRatio(healthRatio);
            if (m_healthCoRoutine != null)
            {
                StopCoroutine(m_healthCoRoutine);
            }
            m_healthCoRoutine = StartCoroutine(SetHealthRoutine(healthRatio));
        }
        internal override void SetHealthRemaining(float healthRemaining)
        {
            base.SetHealthRemaining(healthRemaining);
            m_healthRemaining.text = healthRemaining.ToString();
        }

        internal IEnumerator SetHealthRoutine(float healthRatio)
        {
            m_healthSlider.fillAmount = healthRatio;

            float beginAt = Time.time;
            while (Time.time - beginAt < slideDuration)
            {
                m_backHealthSlider.fillAmount = Mathf.Lerp(m_backHealthSlider.fillAmount, healthRatio, ((Time.time - beginAt) / slideDuration));
                yield return null;
            }

        }

        internal override void DisplayFloatingDamage(int damage)
        {
            base.DisplayFloatingDamage(damage);
            m_floatingDamage.text = damage.ToString();
        }
    }
}