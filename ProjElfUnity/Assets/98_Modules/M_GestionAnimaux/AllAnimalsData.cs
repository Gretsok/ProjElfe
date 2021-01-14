using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AllAnimalData")]
public class AllAnimalsData : ScriptableObject
{
    [SerializeField]
    private AnimalData[] m_animals = null;

    //fait reference à m_animals 
    public AnimalData[] Animals =>m_animals;
}
