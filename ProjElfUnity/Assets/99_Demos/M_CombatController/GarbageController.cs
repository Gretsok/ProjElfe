using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjElf.CombatController;

public class GarbageController : MonoBehaviour
{
    //Var
    [SerializeField] private MeleeWeaponData meleeData = null;
    [SerializeField] private GrimoireData grimoireData = null;
    [SerializeField] private BowData bowData = null;
    [SerializeField] private CombatController combatCont = null;
    [SerializeField] private CombatInventory combatInv = null;

    // Update is called once per frame
    void Update()
    {
        combatCont.DoUpdate();
        //Pour equiper les armes
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            combatCont.ChangeWeapon(meleeData);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            combatCont.ChangeWeapon(grimoireData);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            combatCont.ChangeWeapon(bowData);
        }
        //Pour changer d'arme
        if(Input.GetKeyDown(KeyCode.Alpha4))//Next
        {
            combatCont.SelectNextWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))//Previous
        {
            combatCont.SelectPreviousWeapon();
        }
        //Pour attaquer
        if (Input.GetKeyDown(KeyCode.Alpha6))//ATK
        {
            combatCont.StartUseWeapon(Vector3.zero);//Mettre le point visé
        }
        //Pour attaquer
        if (Input.GetKeyUp(KeyCode.Alpha6))//ATK
        {
            combatCont.StopUseWeapon();//Mettre le point visé
        }
    }
}
