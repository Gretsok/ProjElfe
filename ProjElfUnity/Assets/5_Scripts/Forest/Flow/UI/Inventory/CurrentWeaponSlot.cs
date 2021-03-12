using ProjElf.CombatController;
using UnityEngine;
using UnityEngine.UI;

namespace ProjElf.HubForest
{
    public class CurrentWeaponSlot : MonoBehaviour
    {
        [SerializeField]
        private RawImage m_rawImgSlot = null;
        [SerializeField]
        private RenderTexture m_renderTexture = null;
        private WeaponRenderTextureStudio m_renderTextureStudio = null;

        [SerializeField]
        private Image m_selectedCover = null;

        private void Awake()
        {
            m_rawImgSlot.texture = m_renderTexture;
            Unselect();
        }

        public void Inflate(AWeaponData weaponData, WeaponRenderTextureStudio renderTextureStudio)
        {
            m_renderTextureStudio = renderTextureStudio;
            m_renderTextureStudio.Inflate(weaponData, m_renderTexture);
        }

        public void Select()
        {
            m_selectedCover.gameObject.SetActive(true);
        }

        public void Unselect()
        {
            m_selectedCover.gameObject.SetActive(false);
        }

        public void Clear()
        {
            if (m_renderTextureStudio != null)
            {
                Destroy(m_renderTextureStudio.gameObject);
            }
        }
    }
}