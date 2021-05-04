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
    public class DunjeonChest : MonoBehaviour, IInteractable
    {
        private DunjeonGameMode m_gamemode = null;

        [SerializeField]
        private bool m_canDropMeleeWeapon = false;
        [SerializeField]
        private bool m_canDropBow = false;
        [SerializeField]
        private bool m_canDropGrimoire = false;
        [SerializeField]
        private Animator m_animator = null;
        [SerializeField]
        private Light m_light = null;
        [SerializeField]
        private Color m_closedColor = default;
        [SerializeField]
        private Color m_openedColor = default;

        private bool m_hasBeenOpened = false;

        AWeaponData.AWeaponSaveData weaponSaveData = null;
        Interactor currentInteractor = null;

        private void Start()
        {
            m_gamemode = MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<DunjeonGameMode>();
            m_light.color = m_closedColor;
        }

        private void LoadWeaponsDataToGet()
        {
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

        private IEnumerator OpeningChestRoutine()
        {
            m_hasBeenOpened = true;
            weaponSaveData = null;
            LoadWeaponsDataToGet();
            float timeOfStart = Time.time;
            bool success = true;
            while(weaponSaveData == null)
            {
                if(Time.time - timeOfStart > 10f)
                {
                    Debug.LogError("COULDN'T FIND A WEAPON");
                    success = false;
                    m_hasBeenOpened = false;
                    break;
                }
                yield return 0;
            }
            if(success)
            {
                // Do stuff
                m_animator.SetTrigger("Open");
                m_light.color = m_openedColor;
                Debug.Log(weaponSaveData);
                if (currentInteractor != null)
                {
                    m_gamemode.Player.CombatController.CombatInventory.HoldedWeapons.Add(weaponSaveData);
                }
            }
        }

        public void DoInteraction(Interactor interactor)
        {
            if(!m_hasBeenOpened)
            {
                currentInteractor = interactor;
                StartCoroutine(OpeningChestRoutine());
            }
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