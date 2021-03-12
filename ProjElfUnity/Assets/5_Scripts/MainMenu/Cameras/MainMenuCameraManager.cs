using Cinemachine;
using UnityEngine;

namespace ProjElf.MainMenu
{
    public class MainMenuCameraManager : MonoBehaviour
    {
        [SerializeField]
        private CinemachineVirtualCamera m_characterCamera = null;
        [SerializeField]
        private CinemachineVirtualCamera m_optionsCamera = null;
        [SerializeField]
        private CinemachineVirtualCamera m_homeCamera = null;
        [SerializeField]
        private CinemachineVirtualCamera m_creditsCamera = null;
        [SerializeField]
        private CinemachineVirtualCamera m_quitCamera = null;

        private CinemachineVirtualCamera m_activeCamera = null;

        private void Awake()
        {
            DisactivateAllCameras();
        }

        private void DisactivateAllCameras()
        {
            m_characterCamera.gameObject.SetActive(false);
            m_optionsCamera.gameObject.SetActive(false);
            m_homeCamera.gameObject.SetActive(false);
            m_creditsCamera.gameObject.SetActive(false);
            m_quitCamera.gameObject.SetActive(false);
        }

        private void SetActiveCamera(CinemachineVirtualCamera camera)
        {
            if(m_activeCamera != null)
            {
                m_activeCamera.gameObject.SetActive(false);
            }
            m_activeCamera = camera;
            m_activeCamera.gameObject.SetActive(true);
        }

        public void SetCharacterCamera()
        {
            SetActiveCamera(m_characterCamera);
        }

        public void SetOptionsCamera()
        {
            SetActiveCamera(m_optionsCamera);
        }

        public void SetHomeCamera()
        {
            SetActiveCamera(m_homeCamera);
        }

        public void SetCreditsCamera()
        {
            SetActiveCamera(m_creditsCamera);
        }

        public void SetQuitCamera()
        {
            SetActiveCamera(m_quitCamera);
        }
    }
}