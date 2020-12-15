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
        //Ref transform quand équipé
        [SerializeField] private Transform posMelee;
        [SerializeField] private Transform posGrimoire;
        [SerializeField] private Transform posBow;
        //Ref transform quand rangé
        [SerializeField] private Transform posMeleeEquip;
        [SerializeField] private Transform posGrimoireEquip;
        [SerializeField] private Transform posBowEquip;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        /// <summary>
        /// Change le parent et la position de l'arme.
        /// </summary>
        /// <param name="changePosOf"></param>
        /// <param name="wantedPos"></param>
        private void ChangeWeaponTransform(AWeapon changePosOf, Transform wantedPos)
        {
            changePosOf.transform.SetParent(wantedPos); //On change le parent
            changePosOf.transform.localPosition = Vector3.zero; //Position à 0
            changePosOf.transform.localRotation = Quaternion.identity; //Rotation à 0
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
                //On range le melee
                ChangeWeaponTransform(m_meleeWeapon, posMelee);
                //On sort le grimoire
                ChangeWeaponTransform(m_grimoire, posGrimoireEquip);
                selectedWeapon = m_grimoire;
            }
            else
            {
                if((selectedWeapon is Grimoire) && (m_bow != null))
                {
                    //On range le grimoire
                    ChangeWeaponTransform(m_grimoire, posGrimoire);
                    //On sort le bow
                    ChangeWeaponTransform(m_bow, posBowEquip);
                    selectedWeapon = m_bow;
                }
                else
                {
                    if((selectedWeapon is Bow) && (m_meleeWeapon != null))
                    {
                        //On range le bow
                        ChangeWeaponTransform(m_bow, posBow);
                        //On sort le melee
                        ChangeWeaponTransform(m_meleeWeapon, posMeleeEquip);
                        selectedWeapon = m_meleeWeapon;
                    }
                    else //cas où on a pas d'arme, on équipe melee
                    {
                        ChangeWeaponTransform(m_meleeWeapon, posMeleeEquip);
                        selectedWeapon = m_meleeWeapon;
                    }
                }
            }
        }
        public void SelectPreviousWeapon()
        {
            if((selectedWeapon is Bow) && (m_grimoire != null))
            {
                //On range le bow
                ChangeWeaponTransform(m_bow,posBow);
                //On sort le grimoire
                ChangeWeaponTransform(m_grimoire, posGrimoireEquip);
                selectedWeapon = m_grimoire;
            }
            else
            {
                if((selectedWeapon is Grimoire) && (m_meleeWeapon != null))
                {
                    //On range le grimoire
                    ChangeWeaponTransform(m_grimoire, posGrimoire);
                    //On sort le melee
                    ChangeWeaponTransform(m_meleeWeapon, posMeleeEquip);
                    selectedWeapon = m_meleeWeapon;
                }
                else
                {
                    if ((selectedWeapon is MeleeWeapon) && (m_bow != null))
                    {
                        //On range le melee
                        ChangeWeaponTransform(m_meleeWeapon, posMelee);
                        //On sort le bow
                        ChangeWeaponTransform(m_bow, posBowEquip);
                        selectedWeapon = m_bow;
                    }
                    else //cas où on a pas d'arme, on équipe melee
                    {
                        ChangeWeaponTransform(m_meleeWeapon, posMeleeEquip);
                        selectedWeapon = m_meleeWeapon;
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

