using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.PlayerController
{
    public class PlayerEventRelay : CharacterEventRelay
    {
        [SerializeField]
        private PlayerSoundHandler m_soundHandler = null;

        public override void StartSwordAttack()
        {
            base.StartSwordAttack();
            m_soundHandler.PlaySwordHitSound();
        }

        public override void Step()
        {
            m_soundHandler.PlayStepSound();
        }
    }
}