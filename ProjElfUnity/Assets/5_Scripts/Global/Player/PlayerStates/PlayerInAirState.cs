using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.PlayerController
{
    public class PlayerInAirState : PlayerState
    {
        private float m_distanceFromGround = 0;
        public override void EnterState()
        {
            base.EnterState();
            m_player.CharacterAnimatorHandler.SetInAir(true);

        }

        public override void UpdateState()
        {
            base.UpdateState();
            ManageInput();
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            UpdateLookAround();
            m_distanceFromGround = m_player.GetDistanceFromGround();
            if (m_distanceFromGround < m_player.InAirDistanceFromGround)
            {
                m_player.CharacterAnimatorHandler.SetInAir(false);
                Debug.Log(m_distanceFromGround);
            }
        }

        

        public override void ExitState()
        {
            base.ExitState();
        }
    }
}