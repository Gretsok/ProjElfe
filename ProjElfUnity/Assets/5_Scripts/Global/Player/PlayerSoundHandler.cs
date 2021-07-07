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
        [SerializeField]
        private SoundData m_stepSoundData = null;

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


        private static float STEP_SOUND_DELAY = 0.1f;
        private float m_timeOfLastStepSound = float.MinValue;
        public void PlayStepSound()
        {
            if(Time.time - m_timeOfLastStepSound > STEP_SOUND_DELAY)
            {
                var stepSound = MOtter.MOtterApplication.GetInstance().SOUND.Play3DSound(
                m_stepSoundData,
                m_player.transform.position - Vector3.down * 1.5f,
                false,
                1,
                m_player.transform);
                stepSound.pitch = Random.Range(0.8f, 1.2f);
                m_timeOfLastStepSound = Time.time;
            }
            
        }
    }
}