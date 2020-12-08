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
        //Ref transform
        [SerializeField] private Transform posMelee;
        [SerializeField] private Transform posGrimoire;
        [SerializeField] private Transform posBow;

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
            if(m_meleeWeapon != null)
            {
                Destroy(m_meleeWeapon.gameObject);
            }
            MeleeWeapon newMeleeWeapon;
            newMeleeWeapon = Instantiate<MeleeWeapon>((MeleeWeapon)newMeleeWeaponData.WeaponPrefab, posMelee.position, posMelee.rotation ,posMelee);
            m_meleeWeapon = newMeleeWeapon;
        }
        public void ChangeGrimoire(GrimoireData newGrimoireData)
        {
            if (m_grimoire != null)
            {
                Destroy(m_grimoire.gameObject);
            }
            Grimoire newGrimoire;
            newGrimoire = Instantiate<Grimoire>((Grimoire)newGrimoireData.WeaponPrefab, posGrimoire.position, posGrimoire.rotation, posGrimoire);
            m_grimoire = newGrimoire;
        }
        public void ChangeBow(BowData newBowData)
        {
            if (m_bow != null)
            {
                Destroy(m_bow.gameObject);
            }
            Bow newBow;
            newBow = Instantiate<Bow>((Bow)newBowData.WeaponPrefab, posBow.position, posBow.rotation, posBow);
            m_bow = newBow;
        }
        public void SelectNextWeapon()
        {
            //On part sur Epee / Grimoire / Arc donc :
            if((selectedWeapon is MeleeWeapon) && (m_grimoire != null))
            {
                selectedWeapon = m_grimoire;
            }
            else
            {
                if((selectedWeapon is Grimoire) && (m_bow != null))
                {
                    selectedWeapon = m_bow;
                }
                else
                {
                    if(m_meleeWeapon != null)
                    {
                        selectedWeapon = m_meleeWeapon;
                    }
                }
            }
        }
        public void SelectPreviousWeapon()
        {
            if((selectedWeapon is Bow) && (m_grimoire != null))
            {
                selectedWeapon = m_grimoire;
            }
            else
            {
                if((selectedWeapon is Grimoire) && (m_meleeWeapon != null))
                {
                    selectedWeapon = m_meleeWeapon;
                }
                else
                {
                    if (m_bow != null)
                    {
                        selectedWeapon = m_bow;
                    }
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

