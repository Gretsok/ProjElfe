using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    public class CombatInventory : MonoBehaviour
    {
        //Var
        private MeleeWeapon m_meleeWeapon;
        private Grimoire m_grimoire;
        private Bow m_bow;
        //private AWeapon[] m_weapons = new AWeapon[3];
        private AWeapon selectedWeapon;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ChangeMeleeWeapon(MeleeWeaponData newMeleeWeaponData)
        {
            MeleeWeapon newMeleeWeapon;
            newMeleeWeapon = Instantiate<MeleeWeapon>((MeleeWeapon)newMeleeWeaponData.WeaponPrefab);
            m_meleeWeapon = newMeleeWeapon;
        }
        public void ChangeGrimoire(GrimoireData newGrimoireData)
        {
            Grimoire newGrimoire;
            newGrimoire = Instantiate<Grimoire>((Grimoire)newGrimoireData.WeaponPrefab);
            m_grimoire = newGrimoire;
        }
        public void ChangeBow(BowData newBowData)
        {
            Bow newBow;
            newBow = Instantiate<Bow>((Bow)newBowData.WeaponPrefab);
            m_bow = newBow;
        }
        public void SelectNextWeapon()
        {
            //On part sur Epee / Grimoire / Arc donc :
            if(selectedWeapon is MeleeWeapon)
            {
                selectedWeapon = m_grimoire;
            }
            else
            {
                if(selectedWeapon is Grimoire)
                {
                    selectedWeapon = m_bow;
                }
                else
                {
                    selectedWeapon = m_meleeWeapon;
                }
            }
        }
        public void SelectPreviousWeapon()
        {
            if (selectedWeapon is Bow)
            {
                selectedWeapon = m_grimoire;
            }
            else
            {
                if (selectedWeapon is Grimoire)
                {
                    selectedWeapon = m_meleeWeapon;
                }
                else
                {
                    selectedWeapon = m_bow;
                }
            }
        }
        public void UseSelectedWeapon()
        {
            //Aucune idée
            //on utilise cette methode ou CombatController.UseWeapon() plutot nan ? Ou même AWeapon.Use() ?
        }
    }
}

