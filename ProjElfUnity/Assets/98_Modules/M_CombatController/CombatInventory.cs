using MOtter;
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

        public MeleeWeapon MeleeWeapon => m_meleeWeapon;
        public Grimoire Grimoire => m_grimoire;
        public Bow Bow => m_bow;

        private CombatController m_combatController = null;

        //private AWeapon[] m_weapons = new AWeapon[3];
        private AWeapon m_selectedWeapon;
        //Ref transform quand équipé
        [SerializeField] private Transform m_posMelee;
        [SerializeField] private Transform m_posGrimoire;
        [SerializeField] private Transform m_posBow;
        //Ref transform quand rangé
        [SerializeField] private Transform m_posMeleeEquip;
        [SerializeField] private Transform m_posGrimoireEquip;
        [SerializeField] private Transform m_posBowEquip;

        private List<AWeaponData.AWeaponSaveData> m_holdedWeapons = new List<AWeaponData.AWeaponSaveData>();
        public List<AWeaponData.AWeaponSaveData> HoldedWeapons => m_holdedWeapons;

        internal void RegisterCombatController(CombatController thisCombatController)
        {
            m_combatController = thisCombatController;
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

        public void ChangeWeapon(AWeaponData.AWeaponSaveData weaponSaveData)
        {
            if(weaponSaveData is MeleeWeaponData.MeleeWeaponSaveData)
            {
                ChangeMeleeWeapon(weaponSaveData as MeleeWeaponData.MeleeWeaponSaveData);
            }
            else if(weaponSaveData is GrimoireData.GrimoireSaveData)
            {
                ChangeGrimoire(weaponSaveData as GrimoireData.GrimoireSaveData);
            }
            else if(weaponSaveData is BowData.BowSaveData)
            {
                ChangeBow(weaponSaveData as BowData.BowSaveData);
            }
        }

        public void ChangeMeleeWeapon(MeleeWeaponData.MeleeWeaponSaveData newMeleeWeaponData)
        {
            if(newMeleeWeaponData != null)
            {
                if(newMeleeWeaponData.WeaponData != null)
                {
                    if (m_meleeWeapon != null)
                    {
                        Destroy(m_meleeWeapon.gameObject);
                    }
                    MeleeWeapon newMeleeWeapon;
                    newMeleeWeapon = Instantiate<MeleeWeapon>((MeleeWeapon)newMeleeWeaponData.WeaponData.WeaponPrefab, m_posMelee.position, m_posMelee.rotation, m_posMelee);
                    newMeleeWeapon.InitMeleeWeapon(newMeleeWeaponData, m_combatController);
                    m_meleeWeapon = newMeleeWeapon;
                    Debug.Log("Equipped new MeleeWeapon : " + newMeleeWeapon.name);
                }
            }
        }
        public void ChangeGrimoire(GrimoireData.GrimoireSaveData newGrimoireData)
        {
            if(newGrimoireData != null)
            {
                if(newGrimoireData.WeaponData != null)
                {
                    if (m_grimoire != null)
                    {
                        Destroy(m_grimoire.gameObject);
                    }
                    Grimoire newGrimoire;
                    newGrimoire = Instantiate<Grimoire>((Grimoire)newGrimoireData.WeaponData.WeaponPrefab, m_posGrimoire.position, m_posGrimoire.rotation, m_posGrimoire);
                    newGrimoire.InitGrimoire(newGrimoireData, m_combatController);
                    m_grimoire = newGrimoire;
                    Debug.Log("Equipped new Grimoire : " + newGrimoire.name);
                }
            }
        }
        public void ChangeBow(BowData.BowSaveData newBowData)
        {
            if(newBowData != null)
            {
                if(newBowData.WeaponData != null)
                {
                    if (m_bow != null)
                    {
                        Destroy(m_bow.gameObject);
                    }
                    Bow newBow;
                    newBow = Instantiate<Bow>((Bow)newBowData.WeaponData.WeaponPrefab, m_posBow.position, m_posBow.rotation, m_posBow);
                    newBow.InitBow(newBowData, m_combatController);//init les valeurs du bow
                    m_bow = newBow;
                    Debug.Log("Equipped new Bow : " + newBow.name);
                }
            }
        }
        public void SelectNextWeapon()
        {
            //On part sur Epee / Grimoire / Arc donc :

            if (m_selectedWeapon is MeleeWeapon)
            {
                if (m_grimoire != null)
                {
                    //On range le melee
                    ChangeWeaponTransform(m_meleeWeapon, m_posMelee);
                    //On sort le grimoire
                    ChangeWeaponTransform(m_grimoire, m_posGrimoireEquip);
                    m_selectedWeapon = m_grimoire;
                }
                else if (m_bow != null)
                {
                    //On range le melee
                    ChangeWeaponTransform(m_meleeWeapon, m_posMelee);
                    //On sort le bow
                    ChangeWeaponTransform(m_bow, m_posBowEquip);
                    m_selectedWeapon = m_bow;
                }
            }
            else
            {
                if (m_selectedWeapon is Grimoire)
                {
                    if (m_bow != null)
                    {
                        //On range le grimoire
                        ChangeWeaponTransform(m_grimoire, m_posGrimoire);
                        //On sort le bow
                        ChangeWeaponTransform(m_bow, m_posBowEquip);
                        m_selectedWeapon = m_bow;
                    }
                    else if (m_meleeWeapon != null)
                    {
                        //On range le grimoire
                        ChangeWeaponTransform(m_grimoire, m_posGrimoire);
                        //On sort le melee
                        ChangeWeaponTransform(m_meleeWeapon, m_posMeleeEquip);
                        m_selectedWeapon = m_meleeWeapon;
                    }
                }
                else
                {
                    if (m_selectedWeapon is Bow)
                    {
                        if (m_meleeWeapon != null)
                        {
                            //On range le bow
                            ChangeWeaponTransform(m_bow, m_posBow);
                            //On sort le melee
                            ChangeWeaponTransform(m_meleeWeapon, m_posMeleeEquip);
                            m_selectedWeapon = m_meleeWeapon;
                        }
                        else if (m_grimoire != null)
                        {
                            //On range le bow
                            ChangeWeaponTransform(m_bow, m_posBow);
                            //On sort le grimoire
                            ChangeWeaponTransform(m_grimoire, m_posGrimoireEquip);
                            m_selectedWeapon = m_grimoire;
                        }
                    }
                }
            }

            //Si encore rien d'équipé
            if(m_selectedWeapon == null)
            {
                if (m_meleeWeapon != null)
                {
                    //On sort le melee
                    ChangeWeaponTransform(m_meleeWeapon, m_posMeleeEquip);
                    m_selectedWeapon = m_meleeWeapon;
                }
                else if (m_grimoire != null)
                {
                    //On sort le grimoire
                    ChangeWeaponTransform(m_grimoire, m_posGrimoireEquip);
                    m_selectedWeapon = m_grimoire;
                }
                else if (m_bow != null)
                {
                    //On sort le bow
                    ChangeWeaponTransform(m_bow, m_posBowEquip);
                    m_selectedWeapon = m_bow;
                }
            }
                
        }

        public void SelectPreviousWeapon()
        {
            if(m_selectedWeapon is Bow)
            {
                if(m_grimoire != null)
                {
                    //On range le bow
                    ChangeWeaponTransform(m_bow, m_posBow);
                    //On sort le grimoire
                    ChangeWeaponTransform(m_grimoire, m_posGrimoireEquip);
                    m_selectedWeapon = m_grimoire;
                }
                else if(m_meleeWeapon != null)
                {
                    //On range le bow
                    ChangeWeaponTransform(m_bow, m_posBow);
                    //On sort le melee
                    ChangeWeaponTransform(m_meleeWeapon, m_posMeleeEquip);
                    m_selectedWeapon = m_meleeWeapon;
                }
            }
            else
            {
                if(m_selectedWeapon is Grimoire)
                {
                    if(m_meleeWeapon != null)
                    {
                        //On range le grimoire
                        ChangeWeaponTransform(m_grimoire, m_posGrimoire);
                        //On sort le melee
                        ChangeWeaponTransform(m_meleeWeapon, m_posMeleeEquip);
                        m_selectedWeapon = m_meleeWeapon;
                    }
                    else if(m_bow != null)
                    {
                        //On range le grimoire
                        ChangeWeaponTransform(m_grimoire, m_posGrimoire);
                        //On sort le bow
                        ChangeWeaponTransform(m_bow, m_posBowEquip);
                        m_selectedWeapon = m_bow;
                    }
                }
                else
                {
                    if (m_selectedWeapon is MeleeWeapon)
                    {
                        if(m_bow != null)
                        {
                            //On range le melee
                            ChangeWeaponTransform(m_meleeWeapon, m_posMelee);
                            //On sort le bow
                            ChangeWeaponTransform(m_bow, m_posBowEquip);
                            m_selectedWeapon = m_bow;
                        }
                        else if(m_grimoire != null)
                        {
                            //On range le melee
                            ChangeWeaponTransform(m_meleeWeapon, m_posMelee);
                            //On sort le grimoire
                            ChangeWeaponTransform(m_grimoire, m_posGrimoireEquip);
                            m_selectedWeapon = m_grimoire;
                        }
                    }
                }
            }
            //Si encore rien d'équipé
            if (m_selectedWeapon == null)
            {
                if (m_bow != null)
                {
                    //On sort le bow
                    ChangeWeaponTransform(m_bow, m_posBowEquip);
                    m_selectedWeapon = m_bow;
                }
                else if (m_grimoire != null)
                {
                    //On sort le grimoire
                    ChangeWeaponTransform(m_grimoire, m_posGrimoireEquip);
                    m_selectedWeapon = m_grimoire;
                }
                else if (m_meleeWeapon != null)
                {
                    //On sort le melee
                    ChangeWeaponTransform(m_meleeWeapon, m_posMeleeEquip);
                    m_selectedWeapon = m_meleeWeapon;
                }
            }
        }

        public void UnEquipWeapon()
        {
            if (m_selectedWeapon is MeleeWeapon)
            {
                //On range le melee
                ChangeWeaponTransform(m_meleeWeapon, m_posMelee);
                m_selectedWeapon = null;
            }

            if (m_selectedWeapon is Bow)
            {
                //On range le bow
                ChangeWeaponTransform(m_bow, m_posBow);
                m_selectedWeapon = null;
            }

            if (m_selectedWeapon is Grimoire)
            {
                //On range le grimoire
                ChangeWeaponTransform(m_grimoire, m_posGrimoire);
                m_selectedWeapon = null;
            }
        }

        public void SelectGrimoire()
        {
            UnEquipWeapon(); //On enleve l'arme actuelle
            ChangeWeaponTransform(m_grimoire, m_posGrimoireEquip);
            m_selectedWeapon = m_grimoire;
        }

        public void SelectBow()
        {
            UnEquipWeapon(); //On enleve l'arme actuelle
            ChangeWeaponTransform(m_bow, m_posBowEquip);
            m_selectedWeapon = m_bow;
        }

        public void SelectMeleeWeapon()
        {
            UnEquipWeapon(); //On enleve l'arme actuelle
            ChangeWeaponTransform(m_meleeWeapon, m_posMeleeEquip);
            m_selectedWeapon = m_meleeWeapon;
        }

        public void UseMeleeWeapon()
        {
            if(m_selectedWeapon is MeleeWeapon)
            {

            }
            else
            {
                Debug.LogError("UseMeleeWeapon avec mauvaise arme");
            }
        }
        public void UseBowWeapon(Vector3 direction)
        {
            if (m_selectedWeapon is Bow)
            {
                ((Bow)m_selectedWeapon).BowAttack(direction);
            }
            else
            {
                Debug.LogError("UseBowWeapon avec mauvaise arme");
            }
        }
        public void UseGrimoireWeapon(Vector3 direction)
        {
            if (m_selectedWeapon is Grimoire)
            {
                ((Grimoire)m_selectedWeapon).GrimoireAttack(direction);
            }
            else
            {
                Debug.LogError("UseGrimoireWeapon avec mauvaise arme");
            }
        }

        public AWeapon GetUsedWeapon()
        {
            return m_selectedWeapon;
        }

    }
}

