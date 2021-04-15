using MOtter.PlayersManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIWidgetTest : MonoBehaviour
{
    [SerializeField]
    private int m_playerIndex = 0;

    [SerializeField]
    private TextMeshProUGUI m_displayText = null;
    // Start is called before the first frame update
    public void Init()
    {
         MOtter.MOtterApplication.GetInstance().PLAYERPROFILES.GetPlayerByIndex(m_playerIndex).OnDeviceTypeChanged += OnDeviceTypeChanged;

    }

    private void OnDeviceTypeChanged(EDeviceType obj)
    {
        if(EDeviceType.Gamepad == obj)
        {
            m_displayText.text = "LE GAMEPAAAAD";
        }
        else if(EDeviceType.MouseAndKeyboard == obj)
        {
            m_displayText.text = "LO CLAVIER ET LO SOURIS";
        }
        else if(EDeviceType.None == obj)
        {
            m_displayText.text = "OH BAH RIEN DU TOUT LOL";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        MOtter.MOtterApplication.GetInstance().PLAYERPROFILES.GetPlayerByIndex(m_playerIndex).OnDeviceTypeChanged -= OnDeviceTypeChanged;
    }
}
