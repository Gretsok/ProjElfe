﻿using Cinemachine;
using UnityEngine;

namespace ProjElf.PlayerController
{
    public class PlayerCameraController : MonoBehaviour
    {
        [SerializeField]
        private Transform m_cameraTransform = null;
        [SerializeField]
        private CinemachineVirtualCamera m_cameraZoomOut = null;
        [SerializeField]
        private CinemachineVirtualCamera m_cameraZoomIn = null;

        public Transform CameraTransform => m_cameraTransform;

        public void Zoom(bool zoomIn)
        {
            m_cameraZoomIn.gameObject.SetActive(zoomIn);
            m_cameraZoomOut.gameObject.SetActive(!zoomIn);
        }
    }
}