using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField]
    private AnimalData m_animalData = null;
 
    public AnimalData AnimalData=>m_animalData;
}
