using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.PlayerController
{
    public class PlayerCharacterModelSightBrain : MonoBehaviour
    {
        #region Delegate
        private delegate void Behaviour();
        private Behaviour m_currentBehaviour = null;
        #endregion
        [SerializeField]
        private Transform m_characterModelSightTarget = null;


        [SerializeField]
        private Player m_player = null;

        #region SpecificBehavioursAttributes
        private Transform m_lookAtTarget = null;
        #endregion

        internal void DoUpdate()
        {
            if(m_currentBehaviour != null)
            {
                m_currentBehaviour();
            }
        }

        #region Triggers
        internal void StartWatchingAlongPlayerSight()
        {
            m_currentBehaviour = WatchAlongPlayerSight;
        }

        internal void LookAt(Transform lookAtTarget)
        {
            m_lookAtTarget = lookAtTarget;
            m_currentBehaviour = LookAtTarget;
        }
        #endregion

        #region Behaviours
        private void WatchAlongPlayerSight()
        {
            m_characterModelSightTarget.position = m_player.Sight.origin + m_player.Sight.direction * 10f;
        }
        private void LookAtTarget()
        {
            m_characterModelSightTarget.position = m_lookAtTarget.position;
        }
        #endregion
    }
}