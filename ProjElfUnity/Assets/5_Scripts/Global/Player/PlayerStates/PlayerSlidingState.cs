using System.Collections;
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
        }

        public override void UpdateState()
        {
            base.UpdateState();
            UpdatePosition();
        }

        protected override void UpdatePosition()
        {
            base.UpdatePosition();
            float distanceToTravel = m_movingSpeed * Time.deltaTime;
            m_player.CharacterController.Move(distanceToTravel * m_player.transform.forward);
            m_distanceTraveled += distanceToTravel;

            if(m_distanceTraveled >= m_dashDistance)
            {
                m_player.SwitchToState(m_player.MovingState);
            }

        }
    }
}