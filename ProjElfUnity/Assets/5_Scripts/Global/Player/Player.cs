using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MOtter.StatesMachine;
using ProjElf.Interaction;

namespace ProjElf.PlayerController
{
    public class Player : StatesMachine
    {
        [SerializeField]
        private CharacterController m_characterController = null;
        [SerializeField]
        private PlayerCameraController m_cameraController = null;
        [SerializeField]
        private Interactor m_interactor = null;
        [SerializeField]
        private CharacterAnimatorHandler m_characterAnimatorHandler = null;

        public CharacterController CharacterController => m_characterController;
        public PlayerCameraController CameraController => m_cameraController;
        public Interactor Interactor => m_interactor;
        public CharacterAnimatorHandler CharacterAnimatorHandler => m_characterAnimatorHandler;

        internal bool IsFalling = false;

        #region States
        [Header("Player States")]
        [SerializeField]
        private PlayerMovingState m_movingState = null;
        [SerializeField]
        private PlayerJumpingState m_jumpingState = null;
        [SerializeField]
        private PlayerSlidingState m_slidingState = null;

        public PlayerMovingState MovingState => m_movingState;
        public PlayerJumpingState JumpingState => m_jumpingState;
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

        public void Init()
        {
            EnterStateMachine();
            m_cameraController.Zoom(false);
        }


        public void CleanUp()
        {
            ExitStateMachine();
        }

        protected override void EnterStateMachine()
        {
            base.EnterStateMachine();
            SetUpInput();
        }

        protected override void ExitStateMachine()
        {
            CleanUpInput();
            base.ExitStateMachine();
        }

        #region Inputs
        protected void SetUpInput()
        {
            m_actions.Enable();
        }

        protected void CleanUpInput()
        {
            m_actions.Disable();
            m_actions.Dispose();
        }
        #endregion
    }
}