﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.PlayerController
{
    public class PlayerSlidingState : PlayerState
    {
        [SerializeField]
        private float m_dashDistance = 6f;

        private float m_distanceTraveled = 0;

        public override void EnterState()
        {
            base.EnterState();
            m_distanceTraveled = 0;
            m_player.CharacterAnimatorHandler.StartSlide();
            m_player.transform.LookAt(transform.position + m_player.Direction);
        }

        public override void UpdateState()
        {
            base.UpdateState();
            UpdatePositionInputs();
        }

        protected override void UpdatePositionInputs()
        {
            base.UpdatePositionInputs();
            float distanceToTravel = m_movingSpeed;
            m_player.Direction = m_movingSpeed * m_player.transform.forward;
            m_distanceTraveled += m_player.Direction.magnitude * Time.deltaTime;

            if(m_distanceTraveled >= m_dashDistance)
            {
                m_player.SwitchToState(m_player.MovingState);
            }

        }

        public override void ExitState()
        {
            m_player.CharacterAnimatorHandler.StopSlide();
            base.ExitState();
        }
    }
}