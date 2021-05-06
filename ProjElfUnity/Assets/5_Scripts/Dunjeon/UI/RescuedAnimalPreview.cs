using ProjElf.AnimalManagement;
using UnityEngine;
using UnityEngine.UI;

namespace ProjElf.DunjeonGameplay
{
    public class RescuedAnimalPreview : MonoBehaviour
    {
        [SerializeField]
        private RawImage m_rawImgSlot = null;
        [SerializeField]
        private RenderTexture m_renderTexture = null;
        [SerializeField]
        private RenderTextureStudio m_renderStudioPrefab = null;
        private RenderTextureStudio m_renderStudioObject = null;

        private void Awake()
        {
            m_rawImgSlot.texture = m_renderTexture;
        }

        public void Inflate(AnimalData animalData)
        {
            if(m_renderStudioObject != null)
            {
                Destroy(m_renderStudioObject.gameObject);
            }
            m_renderStudioObject = Instantiate(m_renderStudioPrefab, new Vector3(200, -200, -200), Quaternion.identity);
            m_renderStudioObject.Inflate(animalData.AnimalPrefab.gameObject, m_renderTexture);
        }
    }
}