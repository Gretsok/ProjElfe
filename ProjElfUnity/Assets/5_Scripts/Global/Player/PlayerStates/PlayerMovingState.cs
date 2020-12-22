using UnityEngine;

namespace ProjElf.PlayerController
{
    public class PlayerMovingState : PlayerState
    {
        [SerializeField]
        private Vector2 m_clampedYCAmAngle = Vector2.zero;
        public override void UpdateState()
        {
            base.UpdateState();
            ManageInput();


        }


        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            m_player.Interactor.ManageSight(m_player.Sight);
            UpdatePosition();
            UpdateLookAround();
        }

        protected override void UpdatePosition()
        {
            base.UpdatePosition();
            m_player.Direction = m_player.transform.TransformDirection(new Vector3(m_movementInputs.x, 0, m_movementInputs.y)).normalized;
            m_player.CharacterController.Move(m_player.Direction * m_movingSpeed * Time.fixedDeltaTime);
            m_player.CharacterAnimatorHandler.SetForwardSpeed(m_player.transform.InverseTransformDirection(m_player.Direction).z);
            m_player.CharacterAnimatorHandler.SetRightSpeed(m_player.transform.InverseTransformDirection(m_player.Direction).x);
            Debug.Log("coucou");
        }

        protected override void UpdateLookAround()
        {
            m_player.transform.Rotate(m_player.transform.up * m_lookAroundInputs.x * m_cameraSensibility * Time.fixedDeltaTime);

            Vector3 camFollowTargetEulerRotation = m_player.CamFollowTarget.rotation.eulerAngles;
            camFollowTargetEulerRotation.x -= m_lookAroundInputs.y * m_cameraSensibility * Time.fixedDeltaTime;

            // Clamping x angle
            if(camFollowTargetEulerRotation.x > 180 && camFollowTargetEulerRotation.x < 360 + m_clampedYCAmAngle.x) // m_clampedYCAmAngle.x is negative
            {
                camFollowTargetEulerRotation.x = 360 + m_clampedYCAmAngle.x;
            }
            else if(camFollowTargetEulerRotation.x < 180 && camFollowTargetEulerRotation.x > m_clampedYCAmAngle.y)
            {
                camFollowTargetEulerRotation.x = m_clampedYCAmAngle.y;
            }

            //camFollowTargetEulerRotation.x = Mathf.Clamp(camFollowTargetEulerRotation.x, m_clampedYCAmAngle.x, m_clampedYCAmAngle.y);
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

        private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            m_player.Interactor.Interact();
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
            m_player.Actions.Generic.Interact.performed += Interact_performed;
        }

        

        protected override void CleanUpInputs()
        {
            m_player.Actions.Generic.Slide.performed -= Slide_performed;
            m_player.Actions.Generic.Jump.performed -= Jump_performed;
            m_player.Actions.Generic.PrimaryAttack.performed -= PrimaryAttack_performed;
            m_player.Actions.Generic.SecondaryAttack.performed -= SecondaryAttack_performed;
            m_player.Actions.Generic.Interact.performed -= Interact_performed;
            base.CleanUpInputs();
        }
        #endregion
    }
}