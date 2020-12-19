using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public  class SavedAnimalData
{
    
    public AnimalData AnimalData; 
    public int Amount;

    //1 
}
public class AnimalsManager : MonoBehaviour
{
    // ajouter une methode saveAnamal(AnimalData saveAnimal)
        //check dans la liste SaveAnimal si il y a un saveAnimal 
    //j'instentie car savedAnimalData ne depend pas ni de monoBehaviour ni de Scriptable objet.
    private List<SavedAnimalData> m_savedAnimals = new List<SavedAnimalData>();
    [SerializeField]
    private AllAnimalsData m_allAnimalsData = null;
    public List<SavedAnimalData> SavedAnimals => m_savedAnimals;

    public AnimalData GetRandomAnimal()
    {
        //retourne AniamalData generer aleatoirement 
        System.Random sysRand = new System.Random(); 
        UnityEngine.Random.InitState(sysRand.Next(0, 100000)); //1ere generation aleatoire
        int rand = UnityEngine.Random.Range(0,m_allAnimalsData.Animals.Length);//2nd generation aleatoire
        AnimalData Animal = m_allAnimalsData.Animals[rand];
        return Animal;
    }
                            
}
