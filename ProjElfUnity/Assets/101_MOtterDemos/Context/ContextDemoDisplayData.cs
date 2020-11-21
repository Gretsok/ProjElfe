using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContextDemoDisplayData : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_tileName = null;
    [SerializeField] private TextMeshProUGUI m_detectionGround = null;

    public void ChangeZoneName(string zoneName)
    {
        m_tileName.text = "zone: " + zoneName;
    }

    public void ChangeDetectionGroundDisplay(bool detected)
    {
        m_detectionGround.text = "Detecting ground : " + detected;
    }
}
