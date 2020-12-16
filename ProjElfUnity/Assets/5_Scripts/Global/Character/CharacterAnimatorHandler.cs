using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorHandler : MonoBehaviour
{
    [SerializeField]
    private Animator m_characterAnimator = null;
    int anim_forwardRatioSpeed = Animator.StringToHash("ForwardSpeedRatio");
    int anim_rightRatioSpeed = Animator.StringToHash("RightSpeedRatio");
    
    /// <summary>
    /// Send the actual forward speed ratio to the animator
    /// </summary>
    /// <param name="speedRatio">Normalize this value, it will be clamped between -1 and 1</param>
    public void SetForwardSpeed(float speedRatio)
    {
        speedRatio = Mathf.Clamp(speedRatio, -1, 1);
        m_characterAnimator.SetFloat(anim_forwardRatioSpeed, speedRatio);
    }

    /// <summary>
    /// Send the actual right speed ratio to the animator
    /// </summary>
    /// <param name="speedRatio">Normalize this value, it will be clamped between -1 and 1</param>
    public void SetRightSpeed(float speedRatio)
    {
        speedRatio = Mathf.Clamp(speedRatio, -1, 1);
        m_characterAnimator.SetFloat(anim_rightRatioSpeed, speedRatio);
    }
}
