using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralDataReferences : MonoBehaviour
{
    [SerializeField] private PlayerInputsGeneralData m_playerGeneralData = null;

    public PlayerInputsGeneralData PlayerGeneralData => m_playerGeneralData;
}
