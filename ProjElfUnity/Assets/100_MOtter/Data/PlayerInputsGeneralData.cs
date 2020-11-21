using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerGeneralData", menuName = "ScriptableObject/GeneralData")]
public class PlayerInputsGeneralData : ScriptableObject
{
    [System.Serializable]
    public struct PlayerData
    {
        public string name;
        public Color color;
    }

    [SerializeField] private PlayerData[] m_playersData = null;

    [Header("Inputs")]
    [SerializeField] private float m_timeBeforeDeletingDisconnectedDevice = 20f;



    public List<PlayerData> PlayersData => m_playersData.ToList();
    public float TimeBeforeDeletingDisconnectedDevice => m_timeBeforeDeletingDisconnectedDevice;
}
