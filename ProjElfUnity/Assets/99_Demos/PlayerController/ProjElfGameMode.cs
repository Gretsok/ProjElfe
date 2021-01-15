using MOtter;
using MOtter.StatesMachine;
using ProjElf.CombatController;
using ProjElf.PlayerController;
using UnityEngine;

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
        m_player = Instantiate<Player>(m_playerPrefab, m_playerPositionSpawnPoint.position, m_playerPositionSpawnPoint.rotation);
        m_player.CombatController.CombatInventory.ChangeBow(MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>().SavedPlayerWeaponInventory.EquippedBow);
        m_player.CombatController.CombatInventory.ChangeGrimoire(MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>().SavedPlayerWeaponInventory.EquippedGrimoire);
        m_player.CombatController.CombatInventory.ChangeMeleeWeapon(MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>().SavedPlayerWeaponInventory.EquippedMeleeWeapon);
    }

    internal override void ExitStateMachine()
    {
        float m_timePassed = Time.time - m_timeOfStart;
        if(m_player.CombatController.CombatInventory.Bow != null)
            MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>().SavedPlayerWeaponInventory.EquippedBow = (m_player.CombatController.CombatInventory.Bow.WeaponSaveData as BowData.BowSaveData);
        if (m_player.CombatController.CombatInventory.Grimoire != null)
            MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>().SavedPlayerWeaponInventory.EquippedGrimoire = (m_player.CombatController.CombatInventory.Grimoire.WeaponSaveData as GrimoireData.GrimoireSaveData);
        if (m_player.CombatController.CombatInventory.MeleeWeapon != null)
            MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>().SavedPlayerWeaponInventory.EquippedMeleeWeapon = (m_player.CombatController.CombatInventory.MeleeWeapon.WeaponSaveData as MeleeWeaponData.MeleeWeaponSaveData);

        MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>().SavedPlayerStats.TimePlayed += (int) m_timePassed;
        MOtterApplication.GetInstance().GAMEMANAGER.SaveDataManager.SaveSaveDataManager();
        base.ExitStateMachine();
    }


}
