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
    public List<AWeaponData.AWeaponSaveData> EarnedWeapon = new List<AWeaponData.AWeaponSaveData>();

    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public void LoadFromJson(string a_Json)
    {
        JsonUtility.FromJsonOverwrite(a_Json, this);
    }
}
