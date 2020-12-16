using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.PlayerController
{
    public class PlayerJumpingState : PlayerState
    {
        [SerializeField]
        private float m_jumpHeight = 5f;
        [SerializeField]
        private float m_jumpSpeed = 5f;

        private float m_heightTraveled = 0;

        public override void EnterState()
        {
            base.EnterState();
            m_heightTraveled = 0;
        }

        public override void UpdateState()
        {
            base.UpdateState();
            UpdatePosition();
        }

        protected override void UpdatePosition()
        {
            if(m_heightTraveled < m_jumpHeight)
            {
                float heightToTravel = m_jumpSpeed * Time.deltaTime;
                m_player.CharacterController.Move(heightToTravel * m_player.transform.up);
                m_player.CharacterController.Move(m_player.Direction * m_movingSpeed * Time.deltaTime);
                m_heightTraveled += heightToTravel;
            }
            else
            {
                m_player.SwitchToState(m_player.MovingState);
            }
            
        }
    }
}