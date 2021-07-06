using ProjElf.AnimalManagement;
using ProjElf.CombatController;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public string SaveName = string.Empty;

    public bool IsChoosingAnAnimalToSacrify = false;

    [System.Serializable]
    public struct PlayerWeaponInventory
    {
        [SerializeField]
        public MeleeWeaponData.MeleeWeaponSaveData EquippedMeleeWeapon;
        [SerializeField]
        public GrimoireData.GrimoireSaveData EquippedGrimoire;
        [SerializeField]
        public BowData.BowSaveData EquippedBow;
    }

    [System.Serializable]
    public struct PlayerStats
    {
        public int TimePlayed;
        public int DunjeonFinished;
        public int MonsterKilled;
        public int NumberOfDeath;
    }

    public int FrancissousMoney = 0;

    public List<RescuedAnimalData> RescuedAnimalDatas = new List<RescuedAnimalData>();

    public PlayerWeaponInventory SavedPlayerWeaponInventory;
    public PlayerStats SavedPlayerStats;
    public List<BowData.BowSaveData> EarnedBows = new List<BowData.BowSaveData>();
    public List<GrimoireData.GrimoireSaveData> EarnedGrimoires = new List<GrimoireData.GrimoireSaveData>();
    public List<MeleeWeaponData.MeleeWeaponSaveData> EarnedMeleeWeapons = new List<MeleeWeaponData.MeleeWeaponSaveData>();

    public ProjElf.ProceduraleGeneration.EDunjeonDifficulty DifficultyToBeat = ProjElf.ProceduraleGeneration.EDunjeonDifficulty.RescuerI;

    #region HoldedWeaponsManagement
    public void EarnNewWeapon(AWeaponData.AWeaponSaveData weaponSaveData)
    {
        if(weaponSaveData is BowData.BowSaveData)
        {
            EarnedBows.Add(weaponSaveData as BowData.BowSaveData);
        }
        else if(weaponSaveData is GrimoireData.GrimoireSaveData)
        {
            EarnedGrimoires.Add(weaponSaveData as GrimoireData.GrimoireSaveData);
        }
        else if(weaponSaveData is MeleeWeaponData.MeleeWeaponSaveData)
        {
            EarnedMeleeWeapons.Add(weaponSaveData as MeleeWeaponData.MeleeWeaponSaveData);
        }
        else
        {
            Debug.LogError("Incorrect weapon SaveData !");
        }
    }

    public void RemoveWeaponFromHoldedWeapons(AWeaponData.AWeaponSaveData weaponSaveData)
    {
        if (weaponSaveData is BowData.BowSaveData)
        {
            EarnedBows.Remove(weaponSaveData as BowData.BowSaveData);
        }
        else if (weaponSaveData is GrimoireData.GrimoireSaveData)
        {
            EarnedGrimoires.Remove(weaponSaveData as GrimoireData.GrimoireSaveData);
        }
        else if (weaponSaveData is MeleeWeaponData.MeleeWeaponSaveData)
        {
            EarnedMeleeWeapons.Remove(weaponSaveData as MeleeWeaponData.MeleeWeaponSaveData);
        }
        else
        {
            Debug.LogError("Incorrect weapon SaveData !");
        }
    }

    public void RerollWeapon(AWeaponData.AWeaponSaveData weaponSaveData)
    {
        if (weaponSaveData is BowData.BowSaveData)
        {
            int index = EarnedBows.IndexOf(weaponSaveData as BowData.BowSaveData);
            EarnedBows.Insert(index, (weaponSaveData.WeaponData as BowData).GetWeaponSaveData<BowData.BowSaveData>());
            EarnedBows.Remove(weaponSaveData as BowData.BowSaveData);

        }
        else if (weaponSaveData is GrimoireData.GrimoireSaveData)
        {
            int index = EarnedGrimoires.IndexOf(weaponSaveData as GrimoireData.GrimoireSaveData);
            EarnedGrimoires.Insert(index, (weaponSaveData.WeaponData as GrimoireData).GetWeaponSaveData<GrimoireData.GrimoireSaveData>());
            EarnedGrimoires.Remove(weaponSaveData as GrimoireData.GrimoireSaveData);
        }
        else if (weaponSaveData is MeleeWeaponData.MeleeWeaponSaveData)
        {
            int index = EarnedMeleeWeapons.IndexOf(weaponSaveData as MeleeWeaponData.MeleeWeaponSaveData);
            EarnedMeleeWeapons.Insert(index, (weaponSaveData.WeaponData as MeleeWeaponData).GetWeaponSaveData<MeleeWeaponData.MeleeWeaponSaveData>());
            EarnedMeleeWeapons.Remove(weaponSaveData as MeleeWeaponData.MeleeWeaponSaveData);
        }
        else
        {
            Debug.LogError("Incorrect weapon SaveData !");
        }
    }
    #endregion

    public AnimalData GetRandomAnimalData()
    {
        int weight = 0;
        for(int i = 0; i < RescuedAnimalDatas.Count; i++)
        {
            weight += RescuedAnimalDatas[i].Amount;
        }

        int randomWeight = Random.Range(1, weight + 1);

        weight = 0;
        for (int i = 0; i < RescuedAnimalDatas.Count; i++)
        {
            weight += RescuedAnimalDatas[i].Amount;
            if(weight >= randomWeight)
            {
                return RescuedAnimalDatas[i].AnimalData;
            }
        }
        return null;
    }

    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public void LoadFromJson(string a_Json)
    {
        JsonUtility.FromJsonOverwrite(a_Json, this);

        SavedPlayerWeaponInventory.EquippedBow.Unserialize();
        SavedPlayerWeaponInventory.EquippedGrimoire.Unserialize();
        SavedPlayerWeaponInventory.EquippedMeleeWeapon.Unserialize();

        for(int i = 0; i < EarnedBows.Count; ++i)
        {
            EarnedBows[i].Unserialize();
        }
        for (int i = 0; i < EarnedGrimoires.Count; ++i)
        {
            EarnedGrimoires[i].Unserialize();
        }
        for (int i = 0; i < EarnedMeleeWeapons.Count; ++i)
        {
            EarnedMeleeWeapons[i].Unserialize();
        }

        for(int i = 0; i < RescuedAnimalDatas.Count; ++i)
        {
            RescuedAnimalDatas[i].Unserialize();
        }
    }
}
