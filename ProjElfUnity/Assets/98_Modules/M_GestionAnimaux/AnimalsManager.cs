using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MOtter;

[System.Serializable]
public  class SavedAnimalData
{
    
    public AnimalData AnimalData; 
    public int Amount;
    //1 
}
public class AnimalsManager : MonoBehaviour
{
   
    
    //j'instentie car savedAnimalData ne depend pas ni de monoBehaviour ni de Scriptable objet.
    private List<SavedAnimalData> m_savedAnimals = new List<SavedAnimalData>();
    [SerializeField]
    private AllAnimalsData m_allAnimalsData = null;
    public List<SavedAnimalData> SavedAnimals => m_savedAnimals;
    // ajouter une methode saveAnamal(AnimalData saveAnimal)
    //check dans la liste SaveAnimal si il y a un saveAnimal 
    public AnimalData saveAnimal(AnimalData saveAnimal)
    {
        //Contains : cherche dans la liste m_saveAnimalData pas ouf 
        //Find(avec predicat)
        //La methode return un bool 
        SavedAnimalData anmial_exist =  m_savedAnimals.Find(x => x.AnimalData == saveAnimal);
        Debug.Log(anmial_exist);
        if(anmial_exist == null)
        {
            // new save (= j'instancie ) + amount = 1 + AnimalData = newAnimal
            // + j'atoute la class a la list m_savedAnimals 
            SavedAnimalData newAnimal = new SavedAnimalData();
            newAnimal.Amount = 1;
            newAnimal.AnimalData = saveAnimal;
            m_savedAnimals.Add(newAnimal);
            Debug.Log(m_savedAnimals);
        }
                
        else
        {
            anmial_exist.Amount++;
            Console.WriteLine(m_savedAnimals);
        }
        return saveAnimal;
    }

    private void Start()
    {
        m_savedAnimals = MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>().SavedAnimalDatas;
    }

    public AnimalData GetRandomAnimal()
    {
        //retourne AniamalData generer aleatoirement 
        System.Random sysRand = new System.Random(); 
        UnityEngine.Random.InitState(sysRand.Next(0, 100000)); //1ere generation aleatoire
        int rand = UnityEngine.Random.Range(0,m_allAnimalsData.Animals.Length);//2nd generation aleatoire
        AnimalData Animal = m_allAnimalsData.Animals[rand];
        return Animal;
    }

    public void SaveSavedAnimalsData()
    {
        MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>().SavedAnimalDatas = m_savedAnimals;
    }
                            
}
