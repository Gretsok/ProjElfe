using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="AnimalData")]
public class AnimalData : ScriptableObject
{
    [SerializeField]
    private EPlayerStats m_statsToIncrease = EPlayerStats.Force;
    [SerializeField]
    private int m_statsToIncreaseAmount = 0;
    [SerializeField]
    private Animal m_animalPrefab = null;

    public int StatToIncreaseAmount=> m_statsToIncreaseAmount;
    public EPlayerStats StatsToIncrease => m_statsToIncrease;
    public Animal AnimalPrefab => m_animalPrefab;
}
