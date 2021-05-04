using MOtter.StatesMachine;
using UnityEngine;

namespace ProjElf.PlayerController
{
    public class PlayerState : State
    {
        [SerializeField]
        protected Player m_player = null;

        #region Inputs Attributes
        protected Vector2 m_movementInputs = Vector2.zero;
        protected Vector2 m_lookAroundInputs = Vector2.zero;
        #endregion


        [SerializeField]
        protected float m_cameraSensibility = 15f;

        [SerializeField]
        private Vector2 m_clampedYCAmAngle = Vector2.zero;

        internal virtual void SetUpInputs()
        {
            
        }

        internal virtual void CleanUpInputs()
        {

        }

        protected void ManageInput()
        {
            m_movementInputs = m_player.Actions.Generic.Move.ReadValue<Vector2>();
            m_lookAroundInputs = m_player.Actions.Generic.LookAround.ReadValue<Vector2>();
        }

        protected virtual void UpdatePositionInputs()
        {

        }

        protected virtual void OnStartFalling()
        {
            Debug.Log("StartFalling");
        }

        protected virtual void OnLanding()
        {
            Debug.Log("Landing");
        }

        protected virtual void UpdateLookAround()
        {
            m_player.transform.Rotate(m_player.transform.up * m_lookAroundInputs.x * m_cameraSensibility * Time.fixedDeltaTime);

            Vector3 camFollowTargetEulerRotation = m_player.CamFollowTarget.rotation.eulerAngles;
            camFollowTargetEulerRotation.x -= m_lookAroundInputs.y * m_cameraSensibility * Time.fixedDeltaTime;

            // Clamping x angle
            if (camFollowTargetEulerRotation.x > 180 && camFollowTargetEulerRotation.x < 360 + m_clampedYCAmAngle.x) // m_clampedYCAmAngle.x is negative
            {
                camFollowTargetEulerRotation.x = 360 + m_clampedYCAmAngle.x;
            }
            else if (camFollowTargetEulerRotation.x < 180 && camFollowTargetEulerRotation.x > m_clampedYCAmAngle.y)
            {
                camFollowTargetEulerRotation.x = m_clampedYCAmAngle.y;
            }

            //camFollowTargetEulerRotation.x = Mathf.Clamp(camFollowTargetEulerRotation.x, m_clampedYCAmAngle.x, m_clampedYCAmAngle.y);
            camFollowTargetEulerRotation.z = 0;
            m_player.CamFollowTarget.rotation = Quaternion.Euler(camFollowTargetEulerRotation);
        }

        public override void EnterState()
        {
            base.EnterState();
            SetUpInputs();
            Debug.Log($"Entering {gameObject.name}");
        }

        public override void ExitState()
        {
            CleanUpInputs();
            base.ExitState();
        }
    }
}