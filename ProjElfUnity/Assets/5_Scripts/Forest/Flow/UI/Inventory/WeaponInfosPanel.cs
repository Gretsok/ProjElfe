using ProjElf.CombatController;
using TMPro;
using UnityEngine;

namespace ProjElf.HubForest
{
    public class WeaponInfosPanel : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI m_weaponNameText = null;
        [SerializeField]
        private TextMeshProUGUI[] m_statsTextLines = null;

        public void InflateMeleeWeapon(MeleeWeaponData.MeleeWeaponSaveData weaponSaveData)
        {
            InflateBasicInfos(weaponSaveData);
        }

        public void InflateBow(BowData.BowSaveData weaponSaveData)
        {
            InflateBasicInfos(weaponSaveData);
        }

        public void InflateGrimoire(GrimoireData.GrimoireSaveData weaponSaveData)
        {
            InflateBasicInfos(weaponSaveData);
        }

        private void InflateBasicInfos(AWeaponData.AWeaponSaveData weaponSaveData)
        {
            m_weaponNameText.text = weaponSaveData.WeaponName;
            m_statsTextLines[0].text = "Attack Speed: " + weaponSaveData.AttackSpeed;
            m_statsTextLines[1].text =  $"{weaponSaveData.HitDamage.HitDamage} of {weaponSaveData.HitDamage.DamageType.ToString()} Damage";
            m_statsTextLines[2].text = $"Allow continue firing :{(weaponSaveData.AllowContinueFiring ? "true" : "false")}";
        }
    }
}