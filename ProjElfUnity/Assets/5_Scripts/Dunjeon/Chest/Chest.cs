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
    public class Chest : MonoBehaviour, IInteractable
    {
        private DunjeonGameMode m_gamemode = null;

        [SerializeField]
        private bool m_canDropMeleeWeapon = false;
        [SerializeField]
        private bool m_canDropBow = false;
        [SerializeField]
        private bool m_canDropGrimoire = false;

        private void Start()
        {
            MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<DunjeonGameMode>();
        }

        private AWeaponData.AWeaponSaveData GetRandomWeapon()
        {
            AWeaponData.AWeaponSaveData weaponToReturn = null;

            List<AWeaponData> possibleWeaponsData = new List<AWeaponData>();

            #region Filling possibleWeaponsData
            Addressables.LoadAssetsAsync<AWeaponData>(
                ProjElfUtils.GetDifficultyLabel(m_gamemode.DunjeonManager.CurrentDunjeonData.DunjeonDifficulty),
                null).Completed += obj =>
            {
                foreach(AWeaponData weaponData in obj.Result)
                {
                    if ((m_canDropBow && weaponData is BowData)
                        || (m_canDropGrimoire && weaponData is GrimoireData)
                        || (m_canDropMeleeWeapon && weaponData is MeleeWeaponData))
                    {
                        possibleWeaponsData.Add(weaponData);
                    }
                }
            };
            #endregion

            #region Finding a random weapon in possibleWeaponsData
            UnityEngine.Random.InitState((new System.Random(Time.frameCount * this.GetHashCode()).Next()));
            int index = UnityEngine.Random.Range(0, possibleWeaponsData.Count);
            AWeaponData weaponDataToReturn = possibleWeaponsData[index];

            if(weaponDataToReturn is BowData)
            {
                weaponToReturn = weaponDataToReturn.GetWeaponSaveData<BowData.BowSaveData>();
            }
            else if(weaponDataToReturn is GrimoireData)
            {
                weaponToReturn = weaponDataToReturn.GetWeaponSaveData<GrimoireData.GrimoireSaveData>();
            }
            else if(weaponDataToReturn is MeleeWeaponData)
            {
                weaponToReturn = weaponDataToReturn.GetWeaponSaveData<MeleeWeaponData.MeleeWeaponSaveData>();
            }


            #endregion

            return weaponToReturn;
        }

        public void DoInteraction(Interactor interactor)
        {
            AWeaponData.AWeaponSaveData weaponToDrop = GetRandomWeapon();
        }

        public void StartBeingWatched()
        {
            // Starts shining ?
        }

        public void StopBeingWatched()
        {
            // Stop shining ?
        }
    }
}