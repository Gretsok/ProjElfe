using UnityEngine;

namespace ProjElf.CombatController
{
    public abstract class AWeapon : MonoBehaviour
    {
        //Var
        protected string m_weaponName;
        protected Damage m_damage;
        protected float m_attackSpeed;
        protected bool m_allowContinueFiring;
        protected AWeaponData.AWeaponSaveData m_weaponSaveData = null;
        public bool AllowContinueFiring => m_allowContinueFiring;// c un get
        public float AttackSpeed => m_attackSpeed;//c ossi un get
        public AWeaponData.AWeaponSaveData WeaponSaveData => m_weaponSaveData;

        //private CombatController m_owner;

        public Damage Damage => m_damage;

        [SerializeField]
        private GameObject m_fxContainer = null;
        [SerializeField]
        private bool m_hideFXWhenNotHolded = true;


        internal virtual void OnEquipped()
        {
            if(m_hideFXWhenNotHolded)
            {
                m_fxContainer?.SetActive(true);
            }
        }

        internal virtual void OnUnequipped()
        {
            if (m_hideFXWhenNotHolded)
            {
                m_fxContainer?.SetActive(false);
            }
        }

    }
}

