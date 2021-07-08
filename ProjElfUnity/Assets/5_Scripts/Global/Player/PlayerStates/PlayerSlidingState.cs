using UnityEngine;

namespace ProjElf.PlayerController
{
    public class PlayerSlidingState : PlayerState
    {
        [SerializeField]
        private float m_dashDistance = 6f;
        [SerializeField]
        private float m_dashSpeedMultiplier = 4f;
        private float m_distanceTraveled = 0;
        private Vector3 m_startingDirection = Vector3.zero;
        public override void EnterState()
        {
            base.EnterState();
            m_distanceTraveled = 0;
            m_player.CharacterAnimatorHandler.StartSlide();
            m_startingDirection = m_player.Velocity.magnitude > 0 ?  m_player.Velocity.normalized : transform.forward;
            m_player.CombatController.IsInvincible = true;
        }

        public override void UpdateState()
        {
            base.UpdateState();
            UpdatePositionInputs();
        }

        protected override void UpdatePositionInputs()
        {
            base.UpdatePositionInputs();
            float distanceToTravel = m_player.MovingSpeed;
            m_player.Velocity = m_player.MovingSpeed * m_dashSpeedMultiplier * m_startingDirection;
            m_distanceTraveled += m_player.Velocity.magnitude * Time.deltaTime;

            if(m_distanceTraveled >= m_dashDistance)
            {
                m_player.SwitchToState(m_player.MovingState);
            }
        }

        public override void ExitState()
        {
            m_player.CharacterAnimatorHandler.StopSlide();
            m_player.CombatController.IsInvincible = false;
            base.ExitState();
        }
    }
}