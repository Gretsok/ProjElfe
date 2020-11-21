using UnityEngine;
using UnityEngine.InputSystem;


namespace MOtter.PlayersManagement
{
    public class PlayerDevice : MonoBehaviour
    {
        [SerializeField] private PlayerInput m_playerInput = null;

        public PlayerInput Input => m_playerInput;
        public bool IsAffectedToAProfile { get; set; } = false;

        private float m_timeOfDisconnection = 0;
        private bool m_connected = false;

        public bool Connected => m_connected;

        private void Awake()
        {
            Input.onDeviceLost += OnDeviceLostEvent;
            Input.onDeviceRegained += OnDeviceRegainedEvent;
            m_connected = true;
            Debug.Log("New Device connected : " + m_playerInput.devices[0].ToString() + " devices count on this PlayerDevice : " + m_playerInput.devices.Count);
        }

        private void OnDeviceLostEvent(PlayerInput input)
        {
            m_timeOfDisconnection = Time.time;
            m_connected = false;
            Destroy(gameObject);
            //StartCoroutine(DestroyAfterDeviceLostAndNotReconnected(MOtterApplication.GetInstance().DATA.PlayerGeneralData.TimeBeforeDeletingDisconnectedDevice));
        }

        private void OnDeviceRegainedEvent(PlayerInput input)
        {
            m_connected = true;
        }

        /* private IEnumerator DestroyAfterDeviceLostAndNotReconnected(float timeToWait)
         {
             yield return new WaitForSeconds(timeToWait);
             Debug.Log("DESTROY (not really but its just a debug.log, TO DO)");
             Destroy(gameObject);
             MOtterApplication.GetInstance().PLAYERPROFILES.AssociateNotAssociatedDevicesToNotAssociatedProfiles();
             yield return 0;
         }*/

        private void OnDestroy()
        {
            Input.onDeviceLost -= OnDeviceLostEvent;
            Input.onDeviceRegained -= OnDeviceRegainedEvent;
            Debug.Log("Device disconnected");
        }
    }
}