using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_AnimalManager : MonoBehaviour
{
    //Le but est d'afficher un bob aleatoire 
    // Start is called before the first frame update
    [SerializeField]
    AnimalsManager newAnimalManager = null;


    void Start()
    {
        Instantiate<Animal>(newAnimalManager.GetRandomAnimal().AnimalPrefab);
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
