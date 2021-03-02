using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using static ProjElf.CombatController.AWeaponData;

namespace ProjElf.HubForest
{
    public class StockedWeaponSlot : MonoBehaviour, ISelectHandler
    {
        private AWeaponSaveData m_weaponSaveData = null;

        [SerializeField]
        private Image m_weaponIconImage = null;
        private InventoryPanel m_inventoryPanel = null;

        public void Inflate(AWeaponSaveData weaponSaveData, InventoryPanel inventoryPanel)
        {
            m_weaponSaveData = weaponSaveData;
            m_weaponIconImage.sprite = m_weaponSaveData.WeaponData.WeaponSprite;
            m_inventoryPanel = inventoryPanel;
        }

        public void OnSelect(BaseEventData eventData)
        {
            m_inventoryPanel.SetSelectedWeaponSaveData(m_weaponSaveData);
        }

    }
}