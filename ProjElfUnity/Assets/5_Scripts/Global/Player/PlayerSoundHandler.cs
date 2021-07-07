using MOtter.SoundManagement;
using UnityEngine;

namespace ProjElf.PlayerController
{
    public class PlayerSoundHandler : MonoBehaviour
    {
        [SerializeField]
        private Player m_player = null;

        [SerializeField]
        private SoundData m_swordHitSoundData = null;
        [SerializeField]
        private SoundData m_jumpSoundData = null;

        public void PlaySwordHitSound()
        {
            MOtter.MOtterApplication.GetInstance().SOUND.Play3DSound(
                m_swordHitSoundData,
                m_player.transform.position,
                false,
                1,
                m_player.transform);
        }

        public void PlayJumpSound()
        {
            var jumpSound = MOtter.MOtterApplication.GetInstance().SOUND.Play3DSound(
                m_jumpSoundData,
                m_player.transform.position,
                false,
                1,
                m_player.transform);
            jumpSound.pitch = Random.Range(0.9f, 1.1f);
        }
    }
}