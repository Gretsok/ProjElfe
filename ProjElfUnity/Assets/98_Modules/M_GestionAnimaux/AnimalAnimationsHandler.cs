using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAnimationsHandler : MonoBehaviour
{
    private int SPEED = Animator.StringToHash("Speed");
    private int PRISON = Animator.StringToHash("Prison");
    private int FREE = Animator.StringToHash("Free");

    [SerializeField]
    private Animator m_animator = null;
    [SerializeField]
    private float m_runningSpeed = 10f;

    public void SetSpeed(float speed)
    {
        m_animator.SetFloat(SPEED, speed / m_runningSpeed);
    }
}
