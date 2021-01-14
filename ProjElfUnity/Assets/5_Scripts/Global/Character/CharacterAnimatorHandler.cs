using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorHandler : MonoBehaviour
{
    [SerializeField]
    private Animator m_characterAnimator = null;
    int anim_forwardRatioSpeed = Animator.StringToHash("ForwardSpeedRatio");
    int anim_rightRatioSpeed = Animator.StringToHash("RightSpeedRatio");
    int anim_inAir = Animator.StringToHash("InAir");
    int anim_startJump = Animator.StringToHash("StartJump");
    int anim_startSlide = Animator.StringToHash("StartSlide");
    int anim_stopSlide = Animator.StringToHash("StopSlide");
    int anim_attack = Animator.StringToHash("Attack");
    int anim_weaponEquipped = Animator.StringToHash("WeaponEquipped");
    
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

    public void SetInAir(bool inAir)
    {
        m_characterAnimator.SetBool(anim_inAir, inAir);
    }

    public void StartJump()
    {
        m_characterAnimator.SetTrigger(anim_startJump);
    }

    public void StartSlide()
    {
        m_characterAnimator.SetTrigger(anim_startSlide);
    }

    public void StopSlide()
    {
        m_characterAnimator.SetTrigger(anim_stopSlide);
    }

    public void AttackWithSword()
    {
        m_characterAnimator.SetFloat(anim_weaponEquipped, 0);
        m_characterAnimator.SetTrigger(anim_attack);
    }
}
