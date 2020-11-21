using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace MOtter.PlayersManagement
{
    public class PlayerProfileManager : MonoBehaviour
    {
        #region Fields
        private PlayerProfile[] m_playerProfiles = new PlayerProfile[0];
        private PlayerDevice[] m_playerDevices = new PlayerDevice[0];

        [SerializeField] private PlayerInputManager m_playerInputManager = null;

        public PlayerProfile[] PlayerProfiles => m_playerProfiles;
        public PlayerDevice[] PlayerDevices => m_playerDevices;

        public Action<PlayerDevice> OnConnectedDevice;
        public Action<PlayerDevice> OnDisconnectedDevice;

        #endregion


        #region Lists Management
        // Create an Array class to do this
        private void AddPlayerDevice(PlayerDevice device)
        {
            PlayerDevice[] tempPlayerDevices = m_playerDevices;
            m_playerDevices = new PlayerDevice[m_playerDevices.Length + 1];
            for (int i = 0; i < tempPlayerDevices.Length; i++)
            {
                m_playerDevices[i] = tempPlayerDevices[i];
            }
            m_playerDevices[m_playerDevices.Length - 1] = device;
        }

        private void RemovePlayerDevice(PlayerDevice device)
        {
            int indexOfDeviceToRemove = -1;
            for (int i = 0; i < m_playerDevices.Length; i++)
            {
                if (m_playerDevices[i] == device)
                {
                    indexOfDeviceToRemove = i;
                }
            }
            if (indexOfDeviceToRemove == -1)
            {
                Debug.LogError("Device to remove not registered !");
                return;
            }
            PlayerDevice[] tempPlayerDevices = m_playerDevices;
            m_playerDevices = new PlayerDevice[m_playerDevices.Length - 1];
            for (int i = 0; i < indexOfDeviceToRemove; i++)
            {
                m_playerDevices[i] = tempPlayerDevices[i];
            }
            for (int i = indexOfDeviceToRemove; i < m_playerDevices.Length; i++)
            {
                m_playerDevices[i] = tempPlayerDevices[i + 1];
            }
        }

        private void AddPlayerProfile(PlayerProfile playerProfile)
        {
            PlayerProfile[] tempPlayerProfiles = m_playerProfiles;
            m_playerProfiles = new PlayerProfile[m_playerProfiles.Length + 1];
            for (int i = 0; i < tempPlayerProfiles.Length; i++)
            {
                m_playerProfiles[i] = tempPlayerProfiles[i];
            }
            m_playerProfiles[m_playerProfiles.Length - 1] = playerProfile;
        }

        private void RemovePlayerProfile(PlayerProfile playerProfile)
        {
            int indexOfProfileToRemove = -1;
            for (int i = 0; i < m_playerProfiles.Length; i++)
            {
                if (m_playerProfiles[i] == playerProfile)
                {
                    indexOfProfileToRemove = i;
                }
            }
            if (indexOfProfileToRemove == -1)
            {
                Debug.LogError("Device to remove not registered !");
                return;
            }
            PlayerProfile[] tempPlayerProfiles = m_playerProfiles;
            m_playerProfiles = new PlayerProfile[m_playerProfiles.Length - 1];
            for (int i = 0; i < indexOfProfileToRemove; i++)
            {
                m_playerProfiles[i] = tempPlayerProfiles[i];
            }
            for (int i = indexOfProfileToRemove; i < m_playerProfiles.Length; i++)
            {
                m_playerProfiles[i] = tempPlayerProfiles[i + 1];
            }
        }
        #endregion

        #region Inputs
        public T GetPlayerInputAction<T>(int playerIndex) where T : PlayerInputsActions
        {
            return (T)m_playerProfiles[playerIndex].Actions;
        }

        public void AssociateNotAssociatedDevicesToNotAssociatedProfiles()
        {
            Debug.Log("try to associate");
            foreach (PlayerDevice device in m_playerDevices)
            {
                if (!device.IsAffectedToAProfile)
                {
                    for (int i = 0; i < m_playerProfiles.Length; i++)
                    {
                        Debug.Log("index : " + i);
                        if (m_playerProfiles[i].Device == null)
                        {
                            m_playerProfiles[i].ChangePlayerDevice(device);
                            Debug.Log("PROFILE ASSOCIATED TO DEVICE " + device.name);
                            break;
                        }
                    }

                }
            }
        }

        #endregion

        #region LifeTime Methods
        private void Awake()
        {
            m_playerInputManager.onPlayerJoined += ConnectDevice;
            m_playerInputManager.onPlayerLeft += DisconnectDevice;
        }

        private void OnDestroy()
        {
            m_playerInputManager.onPlayerJoined -= ConnectDevice;
            m_playerInputManager.onPlayerLeft -= DisconnectDevice;
            for (int i = 0; i < m_playerProfiles.Length; i++)
            {
                m_playerProfiles[i].CleanUpActions();
            }
        }
        #endregion
        #region DevicesConnection
        /// <summary>
        /// Do not use this
        /// </summary>
        /// <param name="input"></param>
        public void ConnectDevice(PlayerInput input)
        {
            PlayerDevice newPlayerDevice = input.GetComponent<PlayerDevice>();
            newPlayerDevice.transform.SetParent(transform);
            newPlayerDevice.name = input.devices[0].ToString();
            AddPlayerDevice(newPlayerDevice);
            OnConnectedDevice?.Invoke(newPlayerDevice);

            Debug.Log("ASSOCIATING PROFILE TO DEVICE");
            bool deviceAssociated = false;
            for (int i = 0; i < m_playerProfiles.Length; i++)
            {
                Debug.Log("index : " + i);
                if (m_playerProfiles[i].Device == null)
                {
                    m_playerProfiles[i].ChangePlayerDevice(newPlayerDevice);
                    Debug.Log("PROFILE ASSOCIATED TO DEVICE");
                    deviceAssociated = true;
                    break;
                }
            }
            if (!deviceAssociated)
            {
                Debug.Log("Couldn't find free profile, creating new one ");
                var PlayerData = MOtterApplication.GetInstance().DATA.PlayerGeneralData.PlayersData[m_playerProfiles.Length];
                CreateNewProfile(
                    PlayerData.name,
                    PlayerData.color,
                    newPlayerDevice
                    );
            }
        }

        /// <summary>
        /// Do not use this
        /// </summary>
        /// <param name="input"></param>
        public void DisconnectDevice(PlayerInput input)
        {
            Debug.Log("DECO");
            PlayerDevice playerDeviceDisconnected = input.GetComponent<PlayerDevice>();
            RemovePlayerDevice(playerDeviceDisconnected);
            OnDisconnectedDevice?.Invoke(playerDeviceDisconnected);
        }
        #endregion
        #region ProfilesManagement
        public PlayerProfile CreateNewProfile(string name, Color color, PlayerDevice device)
        {
            PlayerProfile newProfile = new PlayerProfile(name, color, device);
            AddPlayerProfile(newProfile);
            return newProfile;
        }

        #endregion

    }
}
