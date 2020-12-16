using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjElf.CombatController;

public class GarbageController : MonoBehaviour
{
    //Var
    [SerializeField] private MeleeWeaponData meleeData;
    [SerializeField] private GrimoireData grimoireData;
    [SerializeField] private BowData bowData;
    [SerializeField] private CombatController combatCont;
    [SerializeField] private CombatInventory combatInv;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Pour equiper les armes
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            combatInv.ChangeMeleeWeapon(meleeData);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            combatInv.ChangeGrimoire(grimoireData);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            combatInv.ChangeBow(bowData);
        }
        //Pour changer d'arme
        if(Input.GetKeyDown(KeyCode.Alpha4))//Next
        {
            combatInv.SelectNextWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))//Previous
        {
            combatInv.SelectPreviousWeapon();
        }
        //Pour attaquer
        if (Input.GetKeyDown(KeyCode.Alpha6))//Bow
        {
            combatInv.UseBowWeapon(Vector3.zero);//Mettre le point visé
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))//Bow
        {
            combatInv.UseGrimoireWeapon(Vector3.zero);//Mettre le point visé
        }
    }
}
