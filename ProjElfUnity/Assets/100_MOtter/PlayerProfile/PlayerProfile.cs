using UnityEngine;
using UnityEngine.InputSystem;


namespace MOtter.PlayersManagement
{
    public class PlayerProfile
    {
        #region InstantiatedFields
        private static int numberOfPlayers = 0;
        private int m_id;
        private PlayerDevice m_playerDevice = null;

        internal PlayerDevice Device => m_playerDevice;

        private PlayerInputsActions m_actions;
        public PlayerInputsActions Actions => m_actions;

        #endregion
        #region SavedField
        private string m_name;
        private Color m_color;
        #endregion

        #region Accessors
        public string Name => m_name;
        public Color Color => m_color;

        public void ChangeName(string name)
        {
            m_name = name;
        }

        public void ChangeColor(Color color)
        {
            m_color = color;
        }
        #endregion

        public PlayerProfile(string name, Color color, PlayerDevice device)
        {
            m_name = name;
            m_color = color;
            m_id = numberOfPlayers;
            InitActions();
            if (!device.IsAffectedToAProfile)
                ChangePlayerDevice(device);
            numberOfPlayers++;
        }

        ~PlayerProfile()
        {
            numberOfPlayers--;
        }


        #region InputsManagement
        public void RemovePlayerDevice(PlayerInput input)
        {
            PlayerDevice device = input.GetComponent<PlayerDevice>();
            device.IsAffectedToAProfile = false;
            m_playerDevice = null;
            input.onDeviceLost -= RemovePlayerDevice;

        }

        public void ChangePlayerDevice(PlayerDevice device)
        {
            m_playerDevice = device;
            device.Input.onDeviceLost += RemovePlayerDevice;
            device.IsAffectedToAProfile = true;
            ChangeActionsDevice();
        }

        public void InitActions()
        {
            CleanUpActions();
            m_actions = new PlayerInputsActions();
            m_actions.Enable();
        }

        public void ChangeActionsDevice()
        {
            m_actions.devices = Device.Input.devices;
        }

        public void CleanUpActions()
        {
            m_actions?.Dispose();
            m_actions?.Disable();
        }
        #endregion


    }
}