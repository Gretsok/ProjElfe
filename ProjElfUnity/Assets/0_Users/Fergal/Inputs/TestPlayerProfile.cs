using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPlayerProfile : MonoBehaviour
{
    [SerializeField]
    private PlayerInput m_playerInput = null;
    [SerializeField]
    private TextMeshProUGUI m_displayControlScheme = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_displayControlScheme.text = m_playerInput.currentControlScheme;
    }
}
