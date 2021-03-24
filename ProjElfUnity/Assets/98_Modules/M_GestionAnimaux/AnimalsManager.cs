using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MOtter;
using UnityEngine.AddressableAssets;

namespace ProjElf.AnimalManagement
{
    [System.Serializable]
    public class SavedAnimalData
    {

        public AnimalData AnimalData;
        public int Amount;
        //1 
    }
    public class AnimalsManager : MonoBehaviour
    {


        //j'instentie car savedAnimalData ne depend pas ni de monoBehaviour ni de Scriptable objet.
        private List<SavedAnimalData> m_savedAnimals = new List<SavedAnimalData>();
        public List<SavedAnimalData> SavedAnimals => m_savedAnimals;
        // ajouter une methode saveAnamal(AnimalData saveAnimal)
        //check dans la liste SaveAnimal si il y a un saveAnimal 
        public AnimalData saveAnimal(AnimalData saveAnimal)
        {
            //Contains : cherche dans la liste m_saveAnimalData pas ouf 
            //Find(avec predicat)
            //La methode return un bool 
            SavedAnimalData anmial_exist = m_savedAnimals.Find(x => x.AnimalData == saveAnimal);
            Debug.Log(anmial_exist);
            if (anmial_exist == null)
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
            Init();
        }
        public void Init()
        {
            m_savedAnimals = MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>().SavedAnimalDatas;
        }

        public void GetAsyncRandomAnimalData(Action<AnimalData> onAnimalDataGot)
        {
            Addressables.LoadAssetsAsync<AnimalData>("animal", null).Completed += obj =>
            {
                List<AnimalData> m_animalsDataSets = new List<AnimalData>();
                foreach (AnimalData animalData in obj.Result)
                {
                    m_animalsDataSets.Add(animalData);
                }
                onAnimalDataGot.Invoke(GetRandomAnimalData(m_animalsDataSets.ToArray()));
            };
        }

        private AnimalData GetRandomAnimalData(AnimalData[] animalDataSets)
        {
            int rand = UnityEngine.Random.Range(0, animalDataSets.Length);//2nd generation aleatoire
            AnimalData animal = animalDataSets[rand];
            return animal;
        }

        public void SaveSavedAnimalsData()
        {
            MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>().SavedAnimalDatas = m_savedAnimals;
        }

    }
}