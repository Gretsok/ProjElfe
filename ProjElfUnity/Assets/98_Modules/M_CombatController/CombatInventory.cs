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
            newGrimoire.InitGrimoire(newGrimoireData);
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
            newBow.InitBow(newBowData);//init les valeurs du bow
            m_bow = newBow;
        }
        public void SelectNextWeapon()
        {
            //On part sur Epee / Grimoire / Arc donc :

            if (selectedWeapon is MeleeWeapon)
            {
                if (m_grimoire != null)
                {
                    //On range le melee
                    ChangeWeaponTransform(m_meleeWeapon, posMelee);
                    //On sort le grimoire
                    ChangeWeaponTransform(m_grimoire, posGrimoireEquip);
                    selectedWeapon = m_grimoire;
                }
                else if (m_bow != null)
                {
                    //On range le melee
                    ChangeWeaponTransform(m_meleeWeapon, posMelee);
                    //On sort le bow
                    ChangeWeaponTransform(m_bow, posBowEquip);
                    selectedWeapon = m_bow;
                }
            }
            else
            {
                if (selectedWeapon is Grimoire)
                {
                    if (m_bow != null)
                    {
                        //On range le grimoire
                        ChangeWeaponTransform(m_grimoire, posGrimoire);
                        //On sort le bow
                        ChangeWeaponTransform(m_bow, posBowEquip);
                        selectedWeapon = m_bow;
                    }
                    else if (m_meleeWeapon != null)
                    {
                        //On range le grimoire
                        ChangeWeaponTransform(m_grimoire, posGrimoire);
                        //On sort le melee
                        ChangeWeaponTransform(m_meleeWeapon, posMeleeEquip);
                        selectedWeapon = m_meleeWeapon;
                    }
                }
                else
                {
                    if (selectedWeapon is Bow)
                    {
                        if (m_meleeWeapon != null)
                        {
                            //On range le bow
                            ChangeWeaponTransform(m_bow, posBow);
                            //On sort le melee
                            ChangeWeaponTransform(m_meleeWeapon, posMeleeEquip);
                            selectedWeapon = m_meleeWeapon;
                        }
                        else if (m_grimoire != null)
                        {
                            //On range le bow
                            ChangeWeaponTransform(m_bow, posBow);
                            //On sort le grimoire
                            ChangeWeaponTransform(m_grimoire, posGrimoireEquip);
                            selectedWeapon = m_grimoire;
                        }
                    }
                }
            }

            //Si encore rien d'équipé
            if(selectedWeapon == null)
            {
                if (m_meleeWeapon != null)
                {
                    //On sort le melee
                    ChangeWeaponTransform(m_meleeWeapon, posMeleeEquip);
                    selectedWeapon = m_meleeWeapon;
                }
                else if (m_grimoire != null)
                {
                    //On sort le grimoire
                    ChangeWeaponTransform(m_grimoire, posGrimoireEquip);
                    selectedWeapon = m_grimoire;
                }
                else if (m_bow != null)
                {
                    //On sort le bow
                    ChangeWeaponTransform(m_bow, posBowEquip);
                    selectedWeapon = m_bow;
                }
            }
                
        }

        public void SelectPreviousWeapon()
        {
            if(selectedWeapon is Bow)
            {
                if(m_grimoire != null)
                {
                    //On range le bow
                    ChangeWeaponTransform(m_bow, posBow);
                    //On sort le grimoire
                    ChangeWeaponTransform(m_grimoire, posGrimoireEquip);
                    selectedWeapon = m_grimoire;
                }
                else if(m_meleeWeapon != null)
                {
                    //On range le bow
                    ChangeWeaponTransform(m_bow, posBow);
                    //On sort le melee
                    ChangeWeaponTransform(m_meleeWeapon, posMeleeEquip);
                    selectedWeapon = m_meleeWeapon;
                }
            }
            else
            {
                if(selectedWeapon is Grimoire)
                {
                    if(m_meleeWeapon != null)
                    {
                        //On range le grimoire
                        ChangeWeaponTransform(m_grimoire, posGrimoire);
                        //On sort le melee
                        ChangeWeaponTransform(m_meleeWeapon, posMeleeEquip);
                        selectedWeapon = m_meleeWeapon;
                    }
                    else if(m_bow != null)
                    {
                        //On range le grimoire
                        ChangeWeaponTransform(m_grimoire, posGrimoire);
                        //On sort le bow
                        ChangeWeaponTransform(m_bow, posBowEquip);
                        selectedWeapon = m_bow;
                    }
                }
                else
                {
                    if (selectedWeapon is MeleeWeapon)
                    {
                        if(m_bow != null)
                        {
                            //On range le melee
                            ChangeWeaponTransform(m_meleeWeapon, posMelee);
                            //On sort le bow
                            ChangeWeaponTransform(m_bow, posBowEquip);
                            selectedWeapon = m_bow;
                        }
                        else if(m_grimoire != null)
                        {
                            //On range le melee
                            ChangeWeaponTransform(m_meleeWeapon, posMelee);
                            //On sort le grimoire
                            ChangeWeaponTransform(m_grimoire, posGrimoireEquip);
                            selectedWeapon = m_grimoire;
                        }
                    }
                }
            }
            //Si encore rien d'équipé
            if (selectedWeapon == null)
            {
                if (m_bow != null)
                {
                    //On sort le bow
                    ChangeWeaponTransform(m_bow, posBowEquip);
                    selectedWeapon = m_bow;
                }
                else if (m_grimoire != null)
                {
                    //On sort le grimoire
                    ChangeWeaponTransform(m_grimoire, posGrimoireEquip);
                    selectedWeapon = m_grimoire;
                }
                else if (m_meleeWeapon != null)
                {
                    //On sort le melee
                    ChangeWeaponTransform(m_meleeWeapon, posMeleeEquip);
                    selectedWeapon = m_meleeWeapon;
                }
            }
        }
        public void UseMeleeWeapon()
        {
            if(selectedWeapon is MeleeWeapon)
            {

            }
            else
            {
                Debug.LogError("UseMeleeWeapon avec mauvaise arme");
            }
        }
        public void UseBowWeapon(Vector3 direction)
        {
            if (selectedWeapon is Bow)
            {
                ((Bow)selectedWeapon).BowAttack(direction);
            }
            else
            {
                Debug.LogError("UseBowWeapon avec mauvaise arme");
            }
        }
        public void UseGrimoireWeapon(Vector3 direction)
        {
            if (selectedWeapon is Grimoire)
            {
                ((Grimoire)selectedWeapon).GrimoireAttack(direction);
            }
            else
            {
                Debug.LogError("UseGrimoireWeapon avec mauvaise arme");
            }
        }

        public AWeapon GetUsedWeapon()
        {
            return selectedWeapon;
        }
    }
}

