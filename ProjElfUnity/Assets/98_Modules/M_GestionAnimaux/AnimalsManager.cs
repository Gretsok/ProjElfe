﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MOtter;
using UnityEngine.AddressableAssets;

namespace ProjElf.AnimalManagement
{
    [System.Serializable]
    public class RescuedAnimalData
    {
        public int AnimalDataIndex;
        [NonSerialized]
        public AnimalData AnimalData;
        public int Amount;

        public void Unserialize()
        {
            Addressables.LoadAssetsAsync<AnimalData>("animal",
                null).Completed += obj =>
                {
                    foreach (AnimalData animalData in obj.Result)
                    {
                        if (animalData.AnimalDataID == AnimalDataIndex)
                        {
                            AnimalData = animalData;
                        }
                    }
                };
        }
    }
    public class AnimalsManager : MonoBehaviour
    {
        private static AnimalsManager s_instance = null;

        public static AnimalsManager GetInstance()
        {
            if(s_instance == null)
            {
                GameObject appGO = new GameObject();
                s_instance = appGO.AddComponent<AnimalsManager>();
                s_instance.Init();
            }

            return s_instance;
        }



        //j'instentie car savedAnimalData ne depend pas ni de monoBehaviour ni de Scriptable objet.
        private List<RescuedAnimalData> m_rescuedAnimals = new List<RescuedAnimalData>();
        public List<RescuedAnimalData> SavedAnimals => m_rescuedAnimals;
        // ajouter une methode saveAnamal(AnimalData saveAnimal)
        //check dans la liste SaveAnimal si il y a un saveAnimal 
        public AnimalData RescueAnimal(AnimalData saveAnimal)
        {
            //Contains : cherche dans la liste m_saveAnimalData pas ouf 
            //Find(avec predicat)
            //La methode return un bool 
            RescuedAnimalData anmial_exist = m_rescuedAnimals.Find(x => x.AnimalData == saveAnimal);
            Debug.Log(anmial_exist);
            if (anmial_exist == null)
            {
                // new save (= j'instancie ) + amount = 1 + AnimalData = newAnimal
                // + j'atoute la class a la list m_savedAnimals 
                RescuedAnimalData newAnimal = new RescuedAnimalData();
                newAnimal.Amount = 1;
                newAnimal.AnimalData = saveAnimal;
                newAnimal.AnimalDataIndex = saveAnimal.AnimalDataID;
                m_rescuedAnimals.Add(newAnimal);
                Debug.Log(m_rescuedAnimals);
            }

            else
            {
                anmial_exist.Amount++;
                Console.WriteLine(m_rescuedAnimals);
            }
            return saveAnimal;
        }

        public void Init()
        {
            m_rescuedAnimals = MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>().RescuedAnimalDatas;
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

        public void SaveRescuedAnimalsData()
        {
            MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>().RescuedAnimalDatas = m_rescuedAnimals;
        }

        public void SacrificeRescuedAnimal(AnimalData animalData)
        {
            RescuedAnimalData rescuedAnimalData = SavedAnimals.Find(x => x.AnimalData == animalData);
            if(rescuedAnimalData != null)
            {
                if(rescuedAnimalData.Amount == 1)
                {
                    SavedAnimals.Remove(rescuedAnimalData);
                }
                else
                {
                    rescuedAnimalData.Amount--;
                }
                SaveRescuedAnimalsData();
            }
            else
            {
                Debug.LogError("AnimalData not rescued !");
            }
        }

        private void OnDestroy()
        {
            SaveRescuedAnimalsData();
        }
    }
}