using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.PlayerController
{
    public class PlayerMovingState : PlayerState
    {
        public override void UpdateState()
        {
            base.UpdateState();
            ManageInput();
            UpdatePosition();
            UpdateLookAround();
        }


        protected override void UpdatePosition()
        {
            base.UpdatePosition();
            m_player.Direction = transform.TransformDirection(new Vector3(m_movementInputs.x, 0, m_movementInputs.y)).normalized;
            m_player.CharacterController.Move(m_player.Direction * m_movingSpeed * Time.deltaTime);
        }

        protected override void UpdateLookAround()
        {
            m_player.transform.Rotate(m_player.transform.up * m_lookAroundInputs.x * m_cameraSensibility * Time.deltaTime);

            Vector3 camFollowTargetEulerRotation = m_player.CamFollowTarget.rotation.eulerAngles;
            camFollowTargetEulerRotation.x -= m_lookAroundInputs.y * m_cameraSensibility * Time.deltaTime;
            camFollowTargetEulerRotation.z = 0;
            m_player.CamFollowTarget.rotation = Quaternion.Euler(camFollowTargetEulerRotation);
        }
    

        #region Actions
        private void SecondaryAttack_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            throw new System.NotImplementedException();
        }

        private void PrimaryAttack_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            throw new System.NotImplementedException();
        }

        private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            m_player.SwitchToState(m_player.JumpingState);
        }

        private void Slide_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            m_player.SwitchToState(m_player.SlidingState);
        }
        #endregion

        #region Inputs
        protected override void SetUpInputs()
        {
            base.SetUpInputs();
            m_player.Actions.Generic.Slide.performed += Slide_performed;
            m_player.Actions.Generic.Jump.performed += Jump_performed;
            m_player.Actions.Generic.PrimaryAttack.performed += PrimaryAttack_performed;
            m_player.Actions.Generic.SecondaryAttack.performed += SecondaryAttack_performed;
        }

        protected override void CleanUpInputs()
        {
            m_player.Actions.Generic.Slide.performed -= Slide_performed;
            m_player.Actions.Generic.Jump.performed -= Jump_performed;
            m_player.Actions.Generic.PrimaryAttack.performed -= PrimaryAttack_performed;
            m_player.Actions.Generic.SecondaryAttack.performed -= SecondaryAttack_performed;
            base.CleanUpInputs();
        }
        #endregion
    }
}