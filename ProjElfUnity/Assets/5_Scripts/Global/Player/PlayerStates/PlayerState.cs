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
        protected float m_movingSpeed = 5f;

        [SerializeField]
        protected float m_cameraSensibility = 15f;
        [SerializeField]
        private float m_fallSpeed = 10f;


        protected virtual void SetUpInputs()
        {
            
        }

        protected virtual void CleanUpInputs()
        {

        }

        protected void ManageInput()
        {
            m_movementInputs = m_player.Actions.Generic.Move.ReadValue<Vector2>();
            m_lookAroundInputs = m_player.Actions.Generic.LookAround.ReadValue<Vector2>();
        }

        protected virtual void UpdatePosition()
        {
            m_player.CharacterController.Move(Vector3.up * m_fallSpeed * -1 * Time.fixedDeltaTime);
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