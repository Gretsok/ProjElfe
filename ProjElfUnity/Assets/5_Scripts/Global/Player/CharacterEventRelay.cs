using ProjElf.CombatController;

using UnityEngine;

namespace ProjElf.PlayerController
{
    public class CharacterEventRelay : MonoBehaviour
    {
        [SerializeField]
        private PlayerSoundHandler m_soundHandler = null;
        [SerializeField]
        private CombatInventory m_combatInventory = null;

        public void StartSwordAttack()
        {
            m_combatInventory.MeleeWeapon.StartDamaging();
            m_soundHandler.PlaySwordHitSound();
        }

        public void StopSwordAttack()
        {
            m_combatInventory.MeleeWeapon.StopDamaging();
        }


    }
}