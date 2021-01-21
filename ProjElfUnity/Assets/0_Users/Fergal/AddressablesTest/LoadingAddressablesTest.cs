using ProjElf.CombatController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LoadingAddressablesTest : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        Addressables.LoadAssetsAsync<AWeaponData>("bow", null).Completed += obj =>
        {
            foreach (AWeaponData weaponData in obj.Result)
            {
                Instantiate(weaponData.WeaponPrefab);
            }
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
