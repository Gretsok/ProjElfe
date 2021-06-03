using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ProjElf.PlayerController
{
    public class PlayerMovingState : PlayerState
    {
        [SerializeField]
        private float m_jumpDelay = 1f;
        private float m_timeOfLastJump = float.MinValue;
        private float m_lastDashTime = float.MinValue;
        [SerializeField]
        private float m_dashCooldown = 2.5f;
        [SerializeField]
        private float m_velocitySmooth = 10f;
        [SerializeField]
        private Image m_dashClock = null;
        [SerializeField]
        private TMP_Text m_dashCooldownRemaining = null;
        public override void UpdateState()
        {
            base.UpdateState();
            ManageInput();
            if(m_dashCooldown - (Time.time - m_lastDashTime)>0)
            {
                m_dashCooldownRemaining.text = (1 + (int)(m_dashCooldown - (Time.time - m_lastDashTime))).ToString();
                m_dashClock.fillAmount = Mathf.Lerp(0, 1, (Time.time - m_lastDashTime) / m_dashCooldown);
            }
            else
            {
                m_dashCooldownRemaining.text = "";
                m_dashClock.fillAmount = 0;
            }
        }


        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            UpdatePositionInputs();
            UpdateLookAround();
        }

        protected override void ManageInput()
        {
            m_movementInputs = Vector3.Lerp(m_movementInputs, m_moveInputAction.ReadValue<Vector2>(), m_velocitySmooth * Time.deltaTime);
            m_lookAroundInputs = m_lookAroundAction.ReadValue<Vector2>();
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
            if(Time.time - m_lastDashTime > m_dashCooldown)
            {
                m_player.SwitchToState(m_player.SlidingState);
                m_lastDashTime = Time.time;
            }
            
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
            m_player.Actions.FindActionMap("Generic").FindAction("Slide").performed += Slide_performed;
            m_player.Actions.FindActionMap("Generic").FindAction("Jump").performed += Jump_performed;
            m_player.Actions.FindActionMap("Generic").FindAction("PrimaryAttack").performed += PrimaryAttack_performed;
            m_player.Actions.FindActionMap("Generic").FindAction("PrimaryAttack").canceled += PrimaryAttack_canceled;
           /* m_player.Actions.Generic.SecondaryAttack.performed += SecondaryAttack_performed;
            m_player.Actions.Generic.SecondaryAttack.canceled += SecondaryAttack_canceled;*/
            m_player.Actions.FindActionMap("Generic").FindAction("Interact").performed += Interact_performed;
            /*m_player.Actions.Generic.SelectMeleeWeapon.performed += SelectMeleeWeapon_performed;
            m_player.Actions.Generic.SelectBow.performed += SelectBow_performed;
            m_player.Actions.Generic.SelectGrimoire.performed += SelectGrimoire_performed;*/
            m_player.Actions.FindActionMap("Generic").FindAction("SelectNextWeapon").performed += SelectNextWeapon_performed;
            m_player.Actions.FindActionMap("Generic").FindAction("SelectPreviousWeapon").performed += SelectPreviousWeapon_performed;
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
            m_player.Actions.FindActionMap("Generic").FindAction("Slide").performed -= Slide_performed;
            m_player.Actions.FindActionMap("Generic").FindAction("Jump").performed -= Jump_performed;
            m_player.Actions.FindActionMap("Generic").FindAction("PrimaryAttack").performed -= PrimaryAttack_performed;
            m_player.Actions.FindActionMap("Generic").FindAction("PrimaryAttack").canceled -= PrimaryAttack_canceled;
            /* m_player.Actions.Generic.SecondaryAttack.performed -= SecondaryAttack_performed;
             m_player.Actions.Generic.SecondaryAttack.canceled -= SecondaryAttack_canceled;*/
            m_player.Actions.FindActionMap("Generic").FindAction("Interact").performed -= Interact_performed;
            /*m_player.Actions.Generic.SelectMeleeWeapon.performed -= SelectMeleeWeapon_performed;
            m_player.Actions.Generic.SelectBow.performed -= SelectBow_performed;
            m_player.Actions.Generic.SelectGrimoire.performed -= SelectGrimoire_performed;*/
            m_player.Actions.FindActionMap("Generic").FindAction("SelectNextWeapon").performed -= SelectNextWeapon_performed;
            m_player.Actions.FindActionMap("Generic").FindAction("SelectPreviousWeapon").performed -= SelectPreviousWeapon_performed;
            base.CleanUpInputs();
        }
        #endregion
    }
}