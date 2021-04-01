using ProjElf.AnimalManagement;
using UnityEngine;
using UnityEngine.UI;

namespace ProjElf.DunjeonGameplay
{
    public class AnimalToSacrificeWidget : MonoBehaviour
    {
        [SerializeField]
        private Image m_animalIcon = null;
        private AnimalData m_animalData = null;
        public AnimalData AnimalData => m_animalData;

        public void Inflate(AnimalData a_animalData)
        {
            m_animalData = a_animalData;
            m_animalIcon.sprite = m_animalData.AnimalIcon;
        }
    }
}