using MOtter.Localization;
using ProjElf.CombatController;
using TMPro;
using UnityEngine;

namespace ProjElf.HubForest
{
    public class WeaponInfosPanel : MonoBehaviour
    {
        [SerializeField]
        private TextLocalizer m_weaponNameText = null;
        [SerializeField]
        private TextLocalizer[] m_statsTextLines = null;

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
            m_statsTextLines[3].SetKey("WEAPON_STATS_PROJECTILE_GRAVITY");
            m_statsTextLines[3].SetFormatter((text, localizer) =>
            {
                localizer.TextTarget.text = $"{text}: {weaponSaveData.ProjectileDivingRate} m/s²";
            });
            m_statsTextLines[4].SetKey("WEAPON_STATS_PROJECTILE_SPEED");
            m_statsTextLines[4].SetFormatter((text, localizer) =>
            {
                localizer.TextTarget.text = $"{text}:  {weaponSaveData.ProjectileSpeed.ToString("0.0")} m/s";
            });

            for (int i = 5; i < m_statsTextLines.Length; i++)
            {
                m_statsTextLines[i].gameObject.SetActive(false);
            }
        }

        public void InflateGrimoire(GrimoireData.GrimoireSaveData weaponSaveData)
        {
            InflateBasicInfos(weaponSaveData);
            m_statsTextLines[3].SetKey("WEAPON_STATS_PROJECTILE_SPEED");
            m_statsTextLines[3].SetFormatter((text, localizer) =>
            {
                localizer.TextTarget.text = $"{text}:  {weaponSaveData.ProjectileSpeed.ToString("0.0")} m/s";
            });
            m_statsTextLines[4].SetKey("WEAPON_STATS_PROJECTILE_LIFETIME");
            m_statsTextLines[4].SetFormatter((text, localizer) =>
            {
                localizer.TextTarget.text = $"{text}:  {weaponSaveData.ProjectileLifeTime} s";
            });
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
            m_weaponNameText.SetKey(weaponSaveData.WeaponName);
            m_statsTextLines[0].SetKey("WEAPON_STATS_ATTACK_SPEED");
            m_statsTextLines[0].SetFormatter((text, localizer) =>
            {
                localizer.TextTarget.text = $"{text}: {weaponSaveData.AttackSpeed.ToString("0.0")}";
            });
            m_statsTextLines[1].SetKey("WEAPON_STATS_OF_DAMAGE_TYPE");
            m_statsTextLines[1].SetFormatter((text, localizer) =>
            {
                string damageKey = ProjElfUtils.GetDamageTypeKey(weaponSaveData.HitDamage.DamageType);
                string formattedString = string.Format(text, MOtter.MOtterApplication.GetInstance().LOCALIZATION.Localize(damageKey));
                localizer.TextTarget.text = $"{weaponSaveData.HitDamage.HitDamage} {formattedString}";
            });
            m_statsTextLines[2].SetKey("WEAPON_STATS_ALLOW_CONTINUE_FIRING");
            m_statsTextLines[2].SetFormatter((text, localizer) =>
            {
                string translated = MOtter.MOtterApplication.GetInstance().LOCALIZATION.Localize(ProjElfUtils.GetYesOrNoKey(weaponSaveData.AllowContinueFiring));
                localizer.TextTarget.text = $"{text}: {translated}";
            });
        }
    }
}