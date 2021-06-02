﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using MOtter.Localization;

namespace ProjElf.PlayerController
{
    public class PlayerCombatControllerUIManager : CombatController.CombatControllerUIManager
    {
        [SerializeField]
        private Image m_healthSlider = null;
        [SerializeField]
        private Image m_backHealthSlider = null;
        [SerializeField]
        private PlayerWeaponsDisplay m_weaponsDisplay = null;
        public PlayerWeaponsDisplay WeaponsDisplay => m_weaponsDisplay;
        private float slideDuration = 20f;
        private Coroutine m_healthCoRoutine;

        [SerializeField]
        private TMP_Text m_healthRemaining;


        private void Awake()
        {
            HidePossibleInteraction();
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
            while(Time.time - beginAt < slideDuration)
            {
                m_backHealthSlider.fillAmount = Mathf.Lerp(m_backHealthSlider.fillAmount, healthRatio, ((Time.time - beginAt) / slideDuration));
                yield return null;
            }
        }



        [SerializeField]
        private TextLocalizer m_interactText = null;
        [SerializeField]
        private GameObject m_interactionUI = null;

        public void ShowPossibleInteraction(string interactionKey, Action<string, TextLocalizer> format)
        {
            m_interactText.SetKey(interactionKey);
            m_interactText.SetFormatter(format);
            m_interactionUI.SetActive(true);
        }

        public void HidePossibleInteraction()
        {
            m_interactionUI.SetActive(false);
        }

    }
}