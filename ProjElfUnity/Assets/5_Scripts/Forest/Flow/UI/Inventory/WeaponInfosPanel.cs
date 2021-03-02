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

            for(int i = 3; i < m_statsTextLines.Length; i++)
            {
                m_statsTextLines[i].gameObject.SetActive(false);
            }
        }

        public void InflateBow(BowData.BowSaveData weaponSaveData)
        {
            InflateBasicInfos(weaponSaveData);

            m_statsTextLines[3].text = $"Gravity applied to projectile: {weaponSaveData.ProjectileDivingRate} m/s²";
            m_statsTextLines[4].text = $"Projectile speed: {weaponSaveData.ProjectileSpeed} s";

            for (int i = 5; i < m_statsTextLines.Length; i++)
            {
                m_statsTextLines[i].gameObject.SetActive(false);
            }
        }

        public void InflateGrimoire(GrimoireData.GrimoireSaveData weaponSaveData)
        {
            InflateBasicInfos(weaponSaveData);
            m_statsTextLines[3].text = $"Projectile speed: {weaponSaveData.ProjectileSpeed} m/s";
            m_statsTextLines[4].text = $"Projectile life time: {weaponSaveData.ProjectileLifeTime} s";
            for (int i = 5; i < m_statsTextLines.Length; i++)
            {
                m_statsTextLines[i].gameObject.SetActive(false);
            }
        }

        private void InflateBasicInfos(AWeaponData.AWeaponSaveData weaponSaveData)
        {
            for(int i = 0; i < m_statsTextLines.Length; i++)
            {
                m_statsTextLines[i].gameObject.SetActive(true);
            }
            m_weaponNameText.text = weaponSaveData.WeaponName;
            m_statsTextLines[0].text = "Attack Speed: " + weaponSaveData.AttackSpeed;
            m_statsTextLines[1].text =  $"{weaponSaveData.HitDamage.HitDamage} of {weaponSaveData.HitDamage.DamageType.ToString()} Damage";
            m_statsTextLines[2].text = $"Allow continue firing :{(weaponSaveData.AllowContinueFiring ? "true" : "false")}";
        }
    }
}