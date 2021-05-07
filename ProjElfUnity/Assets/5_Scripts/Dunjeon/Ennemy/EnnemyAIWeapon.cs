using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjElf.CombatController;
using UnityEngine.AddressableAssets;
using MOtter;
using ProjElf.ProceduraleGeneration;
using ProjElf.Interaction;

namespace ProjElf.DunjeonGameplay
{
    public class EnnemyAIWeapon : MonoBehaviour
    {
        private DunjeonGameMode m_gamemode = null;

        [SerializeField]
        private bool m_canHaveMeleeWeapon = false;
        [SerializeField]
        private bool m_canHaveBow = false;
        [SerializeField]
        private bool m_canHaveGrimoire = false;
        [SerializeField]
        private EnnemyAICombatInventory m_ennemyCombatInventory = null;

        AWeaponData.AWeaponSaveData weaponSaveData = null;

        private void Start()
        {
            m_gamemode = MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<DunjeonGameMode>();
            StartCoroutine(EquipOneWeaponRoutine());
        }

        private void LoadWeaponsDataToGet()
        {
            List<AWeaponData> possibleWeaponsData = new List<AWeaponData>();

            #region Filling possibleWeaponsData
            Addressables.LoadAssetsAsync<AWeaponData>(
                ProjElfUtils.GetDifficultyLabel(m_gamemode.DunjeonManager.CurrentDunjeonData.DunjeonDifficulty),
                null).Completed += obj =>
                {
                    foreach (AWeaponData weaponData in obj.Result)
                    {
                        if ((m_canHaveBow && weaponData is BowData)
                                || (m_canHaveGrimoire && weaponData is GrimoireData)
                                || (m_canHaveMeleeWeapon && weaponData is MeleeWeaponData))
                        {
                            possibleWeaponsData.Add(weaponData);
                        }
                    }

                    weaponSaveData = GetRandomWeapon(possibleWeaponsData.ToArray());
                };
            #endregion

        }

        private AWeaponData.AWeaponSaveData GetRandomWeapon(AWeaponData[] weaponsData)
        {
            AWeaponData.AWeaponSaveData weaponToReturn = null;

            #region Finding a random weapon in possibleWeaponsData
            UnityEngine.Random.InitState((new System.Random().Next()));
            int index = UnityEngine.Random.Range(0, weaponsData.Length);
            AWeaponData weaponDataToReturn = weaponsData[index];

            if (weaponDataToReturn is BowData)
            {
                weaponToReturn = weaponDataToReturn.GetWeaponSaveData<BowData.BowSaveData>();
            }
            else if (weaponDataToReturn is GrimoireData)
            {
                weaponToReturn = weaponDataToReturn.GetWeaponSaveData<GrimoireData.GrimoireSaveData>();
            }
            else if (weaponDataToReturn is MeleeWeaponData)
            {
                weaponToReturn = weaponDataToReturn.GetWeaponSaveData<MeleeWeaponData.MeleeWeaponSaveData>();
            }
            #endregion
            return weaponToReturn;
        }

        private IEnumerator EquipOneWeaponRoutine()
        {
            weaponSaveData = null;
            LoadWeaponsDataToGet();
            float timeOfStart = Time.time;
            bool success = true;
            while (weaponSaveData == null)
            {
                if (Time.time - timeOfStart > 10f)
                {
                    Debug.LogError("COULDN'T FIND A WEAPON");
                    success = false;
                    break;
                }
                yield return null;
            }
            if (success)
            {
                // Do stuff
                Debug.Log(weaponSaveData);
                m_ennemyCombatInventory.ChangeWeapon(weaponSaveData);
                m_ennemyCombatInventory.SelectNextWeapon();

            }
        }
    }
}

