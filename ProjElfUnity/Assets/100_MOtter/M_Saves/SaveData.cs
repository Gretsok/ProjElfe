using ProjElf.CombatController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public string SaveName = string.Empty;

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

    public List<SavedAnimalData> SavedAnimalDatas = new List<SavedAnimalData>();

    public PlayerWeaponInventory SavedPlayerWeaponInventory;
    public PlayerStats SavedPlayerStats;
    public List<BowData.BowSaveData> EarnedBows = new List<BowData.BowSaveData>();
    public List<GrimoireData.GrimoireSaveData> EarnedGrimoires = new List<GrimoireData.GrimoireSaveData>();
    public List<MeleeWeaponData.MeleeWeaponSaveData> EarnedMeleeWeapons = new List<MeleeWeaponData.MeleeWeaponSaveData>();

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
    }
}
