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

        public CharacterController CharacterController => m_characterController;
        public PlayerCameraController CameraController => m_cameraController;
        public Interactor Interactor => m_interactor;

        #region States
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

        private Vector3 m_direction = Vector3.zero;
        public Vector3 Direction => m_direction;

        private PlayerInputsActions m_actions = new PlayerInputsActions();
        public PlayerInputsActions Actions => m_actions;



        #region Inputs
        protected void SetUpInput()
        {

        }

        protected void CleanUpInput()
        {

        }
        #endregion
    }
}