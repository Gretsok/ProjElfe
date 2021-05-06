using UnityEngine;

namespace Tween
{
    public class RotationTween : ATween
    {
        [SerializeField]
        private Quaternion m_initialLocalRotation = Quaternion.identity;
        [SerializeField]
        private Quaternion m_finalLocalRotation = Quaternion.identity;

        protected override void SetStartingValues()
        {
            base.SetStartingValues();
            m_target.localRotation = m_initialLocalRotation;
        }

        protected override void SetFinalValues()
        {
            m_target.localRotation = m_finalLocalRotation;
            base.SetFinalValues();
        }

        protected override void ManageTween(float interpolationValue)
        {
            base.ManageTween(interpolationValue);
            m_target.localRotation = Quaternion.Lerp(m_initialLocalRotation, m_finalLocalRotation, interpolationValue);
        }
    }
}