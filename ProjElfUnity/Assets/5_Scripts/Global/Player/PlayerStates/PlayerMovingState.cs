using UnityEngine;

namespace ProjElf.PlayerController
{
    public class PlayerMovingState : PlayerState
    {
        [SerializeField]
        private float m_jumpDelay = 1f;
        private float m_timeOfLastJump = float.MinValue;

        public override void UpdateState()
        {
            base.UpdateState();
            ManageInput();
        }


        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            UpdatePositionInputs();
            UpdateLookAround();
        }

        protected override void UpdatePositionInputs()
        {
            base.UpdatePositionInputs();
            m_player.Velocity = m_player.transform.TransformDirection(new Vector3(m_movementInputs.x, 0, m_movementInputs.y));
            m_player.Velocity *= m_player.MovingSpeed;
            m_player.CharacterAnimatorHandler.SetForwardSpeed(m_player.transform.InverseTransformDirection(m_player.Velocity).z);
            m_player.CharacterAnimatorHandler.SetRightSpeed(m_player.transform.InverseTransformDirection(m_player.Velocity).x);
        }
    

        #region Actions
        private void SecondaryAttack_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            throw new System.NotImplementedException();
        }

        private void PrimaryAttack_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            m_player.CombatController.StartUseWeapon(m_player.WeaponSight.direction);
        }

        private void SecondaryAttack_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            throw new System.NotImplementedException();
        }

        private void PrimaryAttack_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            m_player.CombatController.StopUseWeapon();
        }

        private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if(Time.time - m_timeOfLastJump > m_jumpDelay)
            {
                StartCoroutine(m_player.StartJumpRoutine());
                m_timeOfLastJump = Time.time;
            }
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
        internal override void SetUpInputs()
        {
            base.SetUpInputs();
            m_player.Actions.Generic.Slide.performed += Slide_performed;
            m_player.Actions.Generic.Jump.performed += Jump_performed;
            m_player.Actions.Generic.PrimaryAttack.performed += PrimaryAttack_performed;
            m_player.Actions.Generic.PrimaryAttack.canceled += PrimaryAttack_canceled;
           /* m_player.Actions.Generic.SecondaryAttack.performed += SecondaryAttack_performed;
            m_player.Actions.Generic.SecondaryAttack.canceled += SecondaryAttack_canceled;*/
            m_player.Actions.Generic.Interact.performed += Interact_performed;
            /*m_player.Actions.Generic.SelectMeleeWeapon.performed += SelectMeleeWeapon_performed;
            m_player.Actions.Generic.SelectBow.performed += SelectBow_performed;
            m_player.Actions.Generic.SelectGrimoire.performed += SelectGrimoire_performed;*/
            m_player.Actions.Generic.SelectNextWeapon.performed += SelectNextWeapon_performed;
            m_player.Actions.Generic.SelectPreviousWeapon.performed += SelectPreviousWeapon_performed;
        }

        private void SelectPreviousWeapon_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            m_player.CombatController.SelectPreviousWeapon();
        }

        private void SelectNextWeapon_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            m_player.CombatController.SelectNextWeapon();
        }

        private void SelectGrimoire_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            throw new System.NotImplementedException();
        }

        private void SelectBow_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            throw new System.NotImplementedException();
        }

        private void SelectMeleeWeapon_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            throw new System.NotImplementedException();
        }

        internal override void CleanUpInputs()
        {
            m_player.Actions.Generic.Slide.performed -= Slide_performed;
            m_player.Actions.Generic.Jump.performed -= Jump_performed;
            m_player.Actions.Generic.PrimaryAttack.performed -= PrimaryAttack_performed;
            m_player.Actions.Generic.PrimaryAttack.canceled -= PrimaryAttack_canceled;
            /*m_player.Actions.Generic.SecondaryAttack.performed -= SecondaryAttack_performed;
            m_player.Actions.Generic.SecondaryAttack.canceled -= SecondaryAttack_canceled;*/
            m_player.Actions.Generic.Interact.performed -= Interact_performed;

            /*m_player.Actions.Generic.SelectMeleeWeapon.performed -= SelectMeleeWeapon_performed;
            m_player.Actions.Generic.SelectBow.performed -= SelectBow_performed;
            m_player.Actions.Generic.SelectGrimoire.performed -= SelectGrimoire_performed;*/
            m_player.Actions.Generic.SelectNextWeapon.performed -= SelectNextWeapon_performed;
            m_player.Actions.Generic.SelectPreviousWeapon.performed -= SelectPreviousWeapon_performed;
            base.CleanUpInputs();
        }
        #endregion
    }
}