using UnityEngine;

namespace ProjElf.PlayerController
{
    public class PlayerInAirState : PlayerState
    {
        private float m_distanceFromGround = 0;
        private Vector3 m_startingVelocity = Vector3.zero;
        private Vector3 m_directionToAim = Vector3.zero;
        private float m_inAirSpeed = 0f;
        [SerializeField]
        private float m_inAirMovementFactor = 100f;
        public override void EnterState()
        {
            base.EnterState();
            m_player.CharacterAnimatorHandler.SetInAir(true);
            m_startingVelocity = m_player.Velocity;
            m_inAirSpeed = m_startingVelocity.magnitude;
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
            }
            m_inAirSpeed = m_player.Velocity.magnitude;

            m_directionToAim = m_player.transform.TransformDirection(new Vector3(m_movementInputs.x, 0, m_movementInputs.y));
            m_player.Velocity = Vector3.Lerp(m_player.Velocity,
                m_directionToAim.normalized,
                m_directionToAim.sqrMagnitude * m_inAirMovementFactor * Time.fixedDeltaTime).normalized
                * m_inAirSpeed;
        }

        

        public override void ExitState()
        {
            base.ExitState();
        }
    }
}