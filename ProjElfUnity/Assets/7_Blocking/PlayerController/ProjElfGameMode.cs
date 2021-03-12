using MOtter;
using MOtter.StatesMachine;
using ProjElf.CombatController;
using ProjElf.PlayerController;
using UnityEngine;
using UnityEngine.InputSystem.Users;

public class ProjElfGameMode : PauseableStateMachine, IProjElfMainStateMachine
{
    [SerializeField]
    protected Player m_playerPrefab = null;
    protected Player m_player = null;
    public Player Player => m_player;

    [SerializeField]
    private Transform m_playerPositionSpawnPoint = null;

    public PlayerInputsActions Actions => m_player.Actions;

    #region Passing Time
    private float m_timeOfStart = 0;
    #endregion

    internal override void EnterStateMachine()
    {
        base.EnterStateMachine();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        m_timeOfStart = Time.time;
    }

    public override void DoUpdate()
    {
        base.DoUpdate();
    }

    public override void DoFixedUpdate()
    {
        base.DoFixedUpdate();
    }

    public override void DoLateUpdate()
    {
        base.DoLateUpdate();
    }

    public override void Pause()
    {
        base.Pause();
    }

    public override void Unpause()
    {
        base.Unpause();
    }

    protected virtual void InstantiatePlayer()
    {
        m_player = Instantiate<Player>(m_playerPrefab, m_playerPositionSpawnPoint.position, m_playerPositionSpawnPoint.rotation, m_playerPositionSpawnPoint);
        m_player.CombatController.CombatInventory.ChangeBow(MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>().SavedPlayerWeaponInventory.EquippedBow);
        m_player.CombatController.CombatInventory.ChangeGrimoire(MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>().SavedPlayerWeaponInventory.EquippedGrimoire);
        m_player.CombatController.CombatInventory.ChangeMeleeWeapon(MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>().SavedPlayerWeaponInventory.EquippedMeleeWeapon);
    }

    internal override void ExitStateMachine()
    {
        SaveData();
        base.ExitStateMachine();
    }

    public void SaveData()
    {
        var saveData = MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>();
        float m_timePassed = Time.time - m_timeOfStart;
        if (m_player.CombatController.CombatInventory.Bow != null)
            saveData.SavedPlayerWeaponInventory.EquippedBow = (m_player.CombatController.CombatInventory.Bow.WeaponSaveData as BowData.BowSaveData);
        if (m_player.CombatController.CombatInventory.Grimoire != null)
            saveData.SavedPlayerWeaponInventory.EquippedGrimoire = (m_player.CombatController.CombatInventory.Grimoire.WeaponSaveData as GrimoireData.GrimoireSaveData);
        if (m_player.CombatController.CombatInventory.MeleeWeapon != null)
            saveData.SavedPlayerWeaponInventory.EquippedMeleeWeapon = (m_player.CombatController.CombatInventory.MeleeWeapon.WeaponSaveData as MeleeWeaponData.MeleeWeaponSaveData);

        saveData.SavedPlayerStats.TimePlayed += (int)m_timePassed;
        MOtter.MOtterApplication.GetInstance().GAMEMANAGER.SaveCurrentData();
        MOtterApplication.GetInstance().GAMEMANAGER.SaveDataManager.SaveSaveDataManager();
        m_timeOfStart = Time.time;
    }

    public void SavePlayerWeapons()
    {
        var saveData = MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>();
        for (int i = 0; i < m_player.CombatController.CombatInventory.HoldedWeapons.Count; i++)
        {
            saveData.EarnNewWeapon(m_player.CombatController.CombatInventory.HoldedWeapons[i]);
        }
        m_player.CombatController.CombatInventory.HoldedWeapons.Clear();
    }

}
