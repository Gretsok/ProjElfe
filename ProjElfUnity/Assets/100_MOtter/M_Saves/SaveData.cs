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
        public MeleeWeaponData EquippedMeleeWeapon;
        public GrimoireData EquippedGrimoire;
        public BowData EquippedBow;
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
    public List<AWeaponData> EarnedWeapon = new List<AWeaponData>();

    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public void LoadFromJson(string a_Json)
    {
        JsonUtility.FromJsonOverwrite(a_Json, this);
    }
}
