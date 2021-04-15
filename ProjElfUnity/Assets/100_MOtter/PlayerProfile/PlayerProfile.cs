using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

namespace MOtter.PlayersManagement
{
    public class PlayerProfile : MonoBehaviour
    {
        [SerializeField]
        private PlayerInput m_playerInput = null;


        private int m_index = 0;

        public int Index => m_index;

        public Action<EDeviceType> OnDeviceTypeChanged = null;

        public IInputActionCollection Actions => m_playerInput.user.actions;

        public void Init(int index)
        {
            m_index = index;

        }

        private void Update()
        {
           // Debug.Log(GetCurrentDeviceType());
        }

        public EDeviceType GetCurrentDeviceType()
        {
            switch(m_playerInput.currentControlScheme)
            {
                case "MouseAndKeyboard":
                    return EDeviceType.MouseAndKeyboard;
                case "Gamepad":
                    return EDeviceType.Gamepad;
                default:
                    return EDeviceType.None;
            }
        }

        public void Clear()
        {
        }

    }

    public enum EDeviceType
    {
        None,
        MouseAndKeyboard,
        Gamepad
    }
}