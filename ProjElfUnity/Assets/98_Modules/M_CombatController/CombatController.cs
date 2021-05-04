using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    public class CombatController : MonoBehaviour
    {
        //Var
        [SerializeField] private CombatInventory m_combatInventory = null;
        private int m_lifePoints = 0;

        [SerializeField]
        protected int m_baseMaxLifePoints = 100;
        protected int m_maxLifePoints = 100;
        protected int m_physicalArmor = 0;
        protected int m_magicalArmor = 0;
        protected float m_attackSpeedBonus = 0;

        protected float m_magicalDamageMultiplierIncrement = 0f;
        protected float m_physicalDamageMultiplierIncrement = 0f;

        internal float MagicalDamageMultiplierIncrement => m_magicalDamageMultiplierIncrement;
        internal float PhysicalDamageMultiplierIncrement => m_physicalDamageMultiplierIncrement;


        public Action OnLifeReachedZero = null;

        /// <summary>
        /// Meant for AI
        /// </summary>
        public bool ForceContinueFiring = false;

        [SerializeField]
        private CombatControllerUIManager m_UIManager = null;
        public CombatControllerUIManager UIManager => m_UIManager;

        [SerializeField]
        private int m_teamIndex = 0;
        public int TeamIndex => m_teamIndex;

        public CombatInventory CombatInventory => m_combatInventory;

        internal AWeapon UsedWeapon {
            get
            {
                return m_combatInventory.GetUsedWeapon();
            }
        }

        private bool m_isShooting;
        private float m_timeLastShoot = float.MinValue;

        [SerializeField] private CharacterAnimatorHandler m_characterAnimatorHandler = null;

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
            m_maxLifePoints = m_baseMaxLifePoints;
            m_lifePoints = m_maxLifePoints;
            m_UIManager?.SetHealthRatio((float)m_lifePoints / (float)m_maxLifePoints);
        }

        #region DamageGiver
        protected void GetAttacked(DamageGiverData damageGiverData)
        {
            //Debug.Log("GetAttacked");
            if (damageGiverData.DamageGiver.Owner.TeamIndex != m_teamIndex)
            {

                if (damageGiverData.Colliding)
                {
                    Debug.Log(gameObject.name + " is attacked by " + damageGiverData.DamageGiver.Owner.gameObject.name);
                    #region Update other DamageGiversData
                    for (int i = m_damageGivers.Count - 1; i >= 0; i--)
                    {
                        if (!m_damageGivers[i].Colliding && Time.time - m_damageGivers[i].TimeOfLastDamage > m_damageGivers[i].DamageGiver.Cooldown)
                        {
                            m_damageGivers.RemoveAt(i);
                        }
                    }
                    #endregion
                    
                    if(damageGiverData.DamageGiver.CanDoDamage)
                    {
                        TakeDamage(damageGiverData.DamageGiver.Damage);
                    }
                    damageGiverData.DamageGiver.OnCombatControllerHit(this);

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
                    damageGiver.OnDisappear += UnregisterDamageGiver;
                }
                
            }
                    
        }


        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<IDamageGiver>(out IDamageGiver damageGiver))
            {
                UnregisterDamageGiver(damageGiver);
            }
        }

        private void UnregisterDamageGiver(IDamageGiver damageGiver)
        {
            DamageGiverData damageGiverData = m_damageGivers.Find(x => x.DamageGiver == damageGiver);
            if (damageGiverData != null)
            {
                damageGiverData.Colliding = false;
                damageGiver.OnDisappear -= UnregisterDamageGiver;
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

        public void TakeDamage(Damage damage, CombatController attacker = null)
        {
            Debug.Log("Dealing Damage");
            m_lifePoints -= (int) (damage.HitDamage * (attacker != null ? 
                1 + (damage.DamageType == EDamageType.Magical ? attacker.MagicalDamageMultiplierIncrement : attacker.PhysicalDamageMultiplierIncrement)
                : 1));
            m_UIManager?.SetHealthRatio((float) m_lifePoints / (float) m_maxLifePoints);
            if(m_lifePoints<=0)
            {
                OnLifeReachedZero?.Invoke();//Lance l'action si pas null
            }
        }

        public void Heal(int health)
        {
            m_lifePoints += health;
            m_lifePoints = Mathf.Clamp(m_lifePoints, 0, m_maxLifePoints);
            m_UIManager?.SetHealthRatio((float)m_lifePoints / (float)m_maxLifePoints);
        }
    }
}

