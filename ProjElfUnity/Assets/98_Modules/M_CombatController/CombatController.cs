using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    public class CombatController : MonoBehaviour
    {
        //Var
        [SerializeField] private CombatInventory m_combatInventory;
        private int m_lifePoints = 0;
        private int m_maxLifePoints = 100;
        private int m_armor = 0;
        private int m_magicResist = 0;
        private int m_attackSpeed = 0;
        private int m_moveSpeed = 0;

        public Action OnLifeReachedZero = null;

        /// <summary>
        /// Meant for AI
        /// </summary>
        public bool ForceContinueFiring = false;


        public CombatInventory CombatInventory => m_combatInventory;

        internal AWeapon UsedWeapon {
            get
            {
                return m_combatInventory.GetUsedWeapon();
            }
        }

        private bool m_isShooting;
        private float m_timeLastShoot = float.MinValue;

        [SerializeField] private CharacterAnimatorHandler m_characterAnimatorHandler;

        protected class DamageGiverData
        {
            public IDamageGiver DamageGiver;
            public float TimeOfLastDamage;
            public bool Colliding;
        }
        private List<DamageGiverData> m_damageGivers = new List<DamageGiverData>();

        // Start is called before the first frame update
        private void Start()
        {
            m_lifePoints = m_maxLifePoints;
            CombatInventory.RegisterCombatController(this);
        }

        #region DamageGiver
        protected void GetAttacked(DamageGiverData damageGiverData)
        {
            Debug.Log("GetAttacked");
            if (damageGiverData.DamageGiver.Owner != this)
            {

                if (damageGiverData.Colliding)
                {
                    #region Update other DamageGiversData
                    for (int i = m_damageGivers.Count - 1; i >= 0; i--)
                    {
                        if (!m_damageGivers[0].Colliding && Time.time - m_damageGivers[0].TimeOfLastDamage > m_damageGivers[0].DamageGiver.Cooldown)
                        {
                            m_damageGivers.RemoveAt(i);
                        }
                    }
                    #endregion
                    Debug.Log("Dealing Damage");
                    // Use TakeDamage() instead
                    m_lifePoints -= damageGiverData.DamageGiver.Damage.HitDamage;
                    damageGiverData.DamageGiver.OnCombatControllerHit(this);
                    // Remove this when TakeDamage() will be used
                    if (m_lifePoints <= 0)
                    {
                        OnLifeReachedZero?.Invoke();
                    }
                    damageGiverData.TimeOfLastDamage = Time.time;
                    StartCoroutine(TriggerNextAttackRoutine(damageGiverData));
                }
                else if (!damageGiverData.Colliding)
                {
                    m_damageGivers.Remove(damageGiverData);
                }
            }
        }

        IEnumerator TriggerNextAttackRoutine(DamageGiverData damageGiverData)
        {
            Debug.Log("TriggerNextAttackRoutine");
            yield return new WaitForSeconds(damageGiverData.DamageGiver.Cooldown);
            GetAttacked(damageGiverData);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnTriggerEnter");
            if (other.TryGetComponent<IDamageGiver>(out IDamageGiver damageGiver))
            {
                DamageGiverData damageGiverData = m_damageGivers.Find(x => x.DamageGiver == damageGiver);
                #region Manage DamageGiversData
                if (damageGiverData == null)
                {
                    damageGiverData = new DamageGiverData();
                    damageGiverData.DamageGiver = damageGiver;
                    m_damageGivers.Add(damageGiverData);
                    damageGiverData.TimeOfLastDamage = float.MinValue;
                }
                if (damageGiverData.DamageGiver.Owner != this)
                {
                    damageGiverData.Colliding = true;
                    #endregion
                    if (Time.time - damageGiverData.TimeOfLastDamage > damageGiver.Cooldown)
                    {
                        GetAttacked(damageGiverData);
                    }
                }
                
            }
                    
        }


        private void OnTriggerExit(Collider other)
        {
            Debug.Log("OnTriggerExit");
            if (other.TryGetComponent<IDamageGiver>(out IDamageGiver damageGiver))
            {
                DamageGiverData damageGiverData = m_damageGivers.Find(x => x.DamageGiver == damageGiver);
                if (damageGiverData != null)
                {
                    damageGiverData.Colliding = false;
                }
            }
        }
        #endregion
        public void DoUpdate(Vector3 direction = default(Vector3))//appelé depuis le player ou l'ia pour maj combatcontroller
        {
            if (UsedWeapon != null)
            {
                if (m_isShooting && (UsedWeapon.AllowContinueFiring || ForceContinueFiring) && (Time.time - m_timeLastShoot > (1 / UsedWeapon.AttackSpeed)))
                {
                    if (UsedWeapon is MeleeWeapon)
                    {
                        m_combatInventory.UseMeleeWeapon();
                        m_characterAnimatorHandler.AttackWithSword();
                    }
                    else if (UsedWeapon is Grimoire)
                    {
                        m_combatInventory.UseGrimoireWeapon(direction);
                        m_characterAnimatorHandler.AttackWithMagic();
                    }
                    else if (UsedWeapon is Bow)
                    {
                        m_combatInventory.UseBowWeapon(direction);
                        m_characterAnimatorHandler.AttackWithBow();
                    }
                    m_timeLastShoot = Time.time;
                    
                }
            }
        }

        public void ChangeWeapon(AWeaponData newWeaponData)
        {
            if(newWeaponData is MeleeWeaponData)
            {
                m_combatInventory.ChangeMeleeWeapon((newWeaponData as MeleeWeaponData).GetWeaponSaveData<MeleeWeaponData.MeleeWeaponSaveData>());
            }
            else if(newWeaponData is GrimoireData)
            {
                m_combatInventory.ChangeGrimoire((newWeaponData as GrimoireData).GetWeaponSaveData<GrimoireData.GrimoireSaveData>());
            }
            else if(newWeaponData is BowData)
            {
                m_combatInventory.ChangeBow((newWeaponData as BowData).GetWeaponSaveData<BowData.BowSaveData>());
            }
        }

        public void SelectNextWeapon()
        {
            m_combatInventory.SelectNextWeapon();
        }

        public void SelectPreviousWeapon()
        {
            m_combatInventory.SelectPreviousWeapon();
        }

        public void StartUseWeapon(Vector3 direction = default(Vector3)) //default(Vector3) car argument optionnel
        {
            m_isShooting = true;
            if(UsedWeapon != null)
            {
                if (Time.time - m_timeLastShoot > (1 / UsedWeapon.AttackSpeed))
                {
                    if (UsedWeapon is MeleeWeapon)
                    {
                        m_combatInventory.UseMeleeWeapon();
                        m_characterAnimatorHandler.AttackWithSword();
                    }
                    else if (UsedWeapon is Grimoire)
                    {
                        m_combatInventory.UseGrimoireWeapon(direction);
                        m_characterAnimatorHandler.AttackWithMagic();
                    }
                    else if (UsedWeapon is Bow)
                    {
                        m_combatInventory.UseBowWeapon(direction);
                        m_characterAnimatorHandler.AttackWithBow();
                    }
                    m_timeLastShoot = Time.time;
                }
            }
            
        }

        public void StopUseWeapon()
        {
            m_isShooting = false;
        }

        public void TakeDamage(int damage)
        {
            m_lifePoints -= damage;
            if(m_lifePoints<=0)
            {
                OnLifeReachedZero?.Invoke();//Lance l'action si pas null
            }
        }
    }
}

