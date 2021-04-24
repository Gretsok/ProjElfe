using ProjElf.AnimalManagement;
using ProjElf.ProceduraleGeneration;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Demo_AnimalManager : MonoBehaviour
{
    //Le but est d'afficher un bob aleatoire 
    // Start is called before the first frame update
    [SerializeField]
    AnimalsManager newAnimalManager = null;

    private List<Animal> m_spawnedAnimals = new List<Animal>();

    private List<TestRandomAnimal> m_testList = new List<TestRandomAnimal>();

    [System.Serializable]
    class TestRandomAnimal
    {
        public AnimalData animalData;
        public int numberSpawned;
    }

    void Start()
    {
        for(int i =0; i < 100; i++)
        {
            newAnimalManager.GetAsyncRandomAnimalData(OnAnimalDataGot, EDunjeonDifficulty.RescuerI);
        }
        
    }

    private void OnAnimalDataGot(AnimalData animalData)
    {
        Vector3 randomPosition =
            new Vector3(UnityEngine.Random.Range(-20, 20),
            UnityEngine.Random.Range(-20, 20),
            UnityEngine.Random.Range(-20, 20));
        m_spawnedAnimals.Add(animalData.InstantiateAnimal(randomPosition, Quaternion.identity));

        TestRandomAnimal test = m_testList.Find(x => x.animalData == animalData);
        if (test != null)
        {
            test.numberSpawned++;
        }
        else
        {
            test = new TestRandomAnimal();
            test.animalData = animalData;
            test.numberSpawned = 1;
            m_testList.Add(test);
        }
    }
}
