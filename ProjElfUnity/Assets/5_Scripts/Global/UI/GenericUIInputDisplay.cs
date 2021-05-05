using MOtter.PlayersManagement;
using UnityEngine;
using UnityEngine.UI;

namespace ProjElf
{
    public class GenericUIInputDisplay : MonoBehaviour
    {
        [SerializeField]
        private Sprite m_mouseAndKeyboardSprite = null;
        [SerializeField]
        private Sprite m_gamepadSprite = null;

        [SerializeField]
        private Image m_image = null;

        private void Start()
        {
            MOtter.PlayersManagement.PlayerProfile playerprofile = MOtter.MOtterApplication.GetInstance().PLAYERPROFILES.GetPlayerByIndex(0);
            playerprofile.OnDeviceTypeChanged += ChangeDeviceType;
            ChangeDeviceType(playerprofile.GetCurrentDeviceType());
        }

        private void ChangeDeviceType(EDeviceType obj)
        {
            switch(obj)
            {
                case EDeviceType.MouseAndKeyboard:
                    m_image.sprite = m_mouseAndKeyboardSprite;
                    break;
                case EDeviceType.Gamepad:
                    m_image.sprite = m_gamepadSprite;
                    break;
                default:
                    m_image.sprite = m_gamepadSprite;
                    break;
            }
        }

        private void OnDestroy()
        {
            MOtter.MOtterApplication.GetInstance().PLAYERPROFILES.GetPlayerByIndex(0).OnDeviceTypeChanged -= ChangeDeviceType;
        }
    }
}