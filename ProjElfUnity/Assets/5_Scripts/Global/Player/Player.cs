using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MOtter.StatesMachine;
using ProjElf.Interaction;
using MOtter;
using ProjElf.CombatController;

namespace ProjElf.PlayerController
{
    public class Player : StatesMachine
    {
        private ProjElfGameMode m_gamemode = null;
        [SerializeField]
        private CharacterController m_characterController = null;
        [SerializeField]
        private PlayerCameraController m_cameraController = null;
        [SerializeField]
        private Interactor m_interactor = null;
        [SerializeField]
        private CharacterAnimatorHandler m_characterAnimatorHandler = null;
        [SerializeField]
        private PlayerCombatController m_combatController = null;

        public CharacterController CharacterController => m_characterController;
        public PlayerCameraController CameraController => m_cameraController;
        public Interactor Interactor => m_interactor;
        public CharacterAnimatorHandler CharacterAnimatorHandler => m_characterAnimatorHandler;
        public PlayerCombatController CombatController => m_combatController;

        internal bool IsFalling = false;

        internal Ray Sight = new Ray();
        internal Ray WeaponSight = new Ray();

        [Header("Movement Properties")]
        [SerializeField]
        private float m_gravity = 14f;
        private float m_verticalVelocity = 0f;
        [SerializeField]
        private float m_inAirDistanceFromGround = 0.5f;
        internal float InAirDistanceFromGround => m_inAirDistanceFromGround;

        #region States
        [Header("Player States")]
        [SerializeField]
        private PlayerMovingState m_movingState = null;
        [SerializeField]
        private PlayerInAirState m_inAirState = null;
        [SerializeField]
        private PlayerSlidingState m_slidingState = null;

        public PlayerMovingState MovingState => m_movingState;
        public PlayerInAirState InAirState => m_inAirState;
        public PlayerSlidingState SlidingState => m_slidingState;
        #endregion

        [Header("Position References")]
        [SerializeField]
        private Transform m_camFollowTarget = null;
        public Transform CamFollowTarget => m_camFollowTarget;

        internal Vector3 Direction = Vector3.zero;

        private PlayerInputsActions m_actions = null;
        public PlayerInputsActions Actions => m_actions;

        private void Awake()
        {
            m_actions = new PlayerInputsActions();
        }

        private void Start()
        {
            m_gamemode = MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<ProjElfGameMode>();
        }

        public void Init()
        {
            EnterStateMachine();
            m_cameraController.Zoom(false);
        }


        public void CleanUp()
        {
            ExitStateMachine();
        }

        internal override void EnterStateMachine()
        {
            base.EnterStateMachine();
            SetUpInput();
            m_gamemode.OnPause += CleanUpInput;
            m_gamemode.OnUnpause += SetUpInput;
            
        }

        public override void DoUpdate()
        {
            base.DoUpdate();
            m_combatController.DoUpdate(WeaponSight.direction);
        }


        public override void DoFixedUpdate()
        {
            base.DoFixedUpdate();
            Sight = new Ray(CameraController.CameraTransform.position + CameraController.CameraTransform.forward * (CameraController.CameraTransform.position - transform.position).magnitude, CameraController.CameraTransform.forward);
            m_interactor.ManageSight(Sight);

            UpdateWeaponSight();


            Vector3 verticalMovement = Vector3.up * m_verticalVelocity;
            m_characterController.Move((Direction + verticalMovement) * Time.fixedDeltaTime);
            
            if(m_characterController.isGrounded)
            {
                m_verticalVelocity = -m_gravity * Time.fixedDeltaTime;
                if(m_currentState == m_inAirState)
                {

                    SwitchToState(m_movingState);
                }
            }
            else
            {
                m_verticalVelocity -= m_gravity * Time.fixedDeltaTime; 
                if(m_currentState == m_movingState)
                {
                    if(GetDistanceFromGround() > m_inAirDistanceFromGround)
                    {
                        SwitchToState(m_inAirState);
                    }
                    
                }
            }
        }

        private void UpdateWeaponSight()
        {
            if(m_combatController.UsedWeapon is Bow)
            {
                WeaponSight = Sight;
                if(Physics.Raycast(Sight, out RaycastHit hitInfo, 30))
                {
                    Vector3 arrowStartPosition = m_combatController.CombatInventory.Bow.PosArrow.transform.position;
                    WeaponSight = new Ray(arrowStartPosition, (hitInfo.point - arrowStartPosition));
                } 
            }
            else if(m_combatController.UsedWeapon is Grimoire)
            {
                WeaponSight = Sight;
                if (Physics.Raycast(Sight, out RaycastHit hitInfo, 30))
                {
                    Vector3 projectileStartPosition = m_combatController.CombatInventory.Grimoire.PosMagicSpell.transform.position;
                    WeaponSight = new Ray(projectileStartPosition, (hitInfo.point - projectileStartPosition));
                }
            }
            else if(m_combatController.UsedWeapon is MeleeWeapon)
            {
                WeaponSight = Sight;
            }
        }

        internal override void ExitStateMachine()
        {
            m_gamemode.OnPause -= CleanUpInput;
            m_gamemode.OnUnpause -= SetUpInput;
            CleanUpInput();
            base.ExitStateMachine();
        }

        #region GenericBehaviour
        internal IEnumerator StartJumpRoutine()
        {
            Debug.Log("JUMP");
            m_characterAnimatorHandler.StartJump();
            yield return new WaitForSeconds(0.4f);
            m_verticalVelocity = 10f;
        }



        #endregion

        #region PlayerUtils
        internal float GetDistanceFromGround()
        {
            float distanceFromGround = 10f;
            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo, distanceFromGround))
            {
                distanceFromGround = hitInfo.distance;

            }
            return distanceFromGround;
        }
        #endregion

        #region Inputs
        protected void SetUpInput()
        {
            m_actions.Enable();
            m_actions.UI.Back.performed += Pause_performed;
        }

        private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            m_gamemode.Pause();
        }

        protected void CleanUpInput()
        {
            m_actions.UI.Back.performed -= Pause_performed;
            m_actions.Disable();
        }
        #endregion
    }
}