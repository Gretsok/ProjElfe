using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKAnimator : MonoBehaviour
{
    [SerializeField]
    private Transform m_leftFootTarget = null;
    [SerializeField]
    private Transform m_rightFootTarget = null;

    private Vector3 m_initLeftFootPos = Vector3.zero;
    private Vector3 m_initRightFootPos = Vector3.zero;

    private Vector3 m_lastLeftFootPos = Vector3.zero;
    private Vector3 m_lastRightFootPos = Vector3.zero;

    private Vector3 m_targetLeftFootPosition = Vector3.zero;
    private Vector3 m_targetRightFootPosition = Vector3.zero;

    private Vector3 m_controllerPositionOnGround = Vector3.zero;
    [SerializeField]
    private float m_minDistanceToStep = 0.35f;
    [SerializeField]
    private float m_stepMultiplier = 0.75f;

    [SerializeField]
    private float m_footMovementSmoothValue = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        m_initLeftFootPos = m_leftFootTarget.localPosition;
        m_initRightFootPos = m_rightFootTarget.localPosition;

        m_lastLeftFootPos = m_leftFootTarget.position;
        m_lastRightFootPos = m_rightFootTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        m_leftFootTarget.position = m_lastLeftFootPos;
        m_rightFootTarget.position = m_lastRightFootPos;


        MoveFoot();


        m_lastLeftFootPos = m_leftFootTarget.position;
        m_lastRightFootPos = m_rightFootTarget.position;
    }

    void MoveFoot()
    {
        m_controllerPositionOnGround = transform.position;
        if(Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfos, 2f))
        {
            m_controllerPositionOnGround = hitInfos.point;
        }
        Vector3 footCenterToPosition =
            m_controllerPositionOnGround - Vector3.Lerp(m_leftFootTarget.position, m_rightFootTarget.position, 0.5f);
        if (footCenterToPosition.magnitude > m_minDistanceToStep)
        {
            Vector3 rightFootToPos = (m_controllerPositionOnGround - m_rightFootTarget.position);
            Vector3 leftFootToPos = (m_controllerPositionOnGround - m_leftFootTarget.position);
            bool canMoveRightFoot = false, canMoveLeftFoot = false;

            if(Vector3.Angle(footCenterToPosition, rightFootToPos) < 90)
            {
                canMoveRightFoot = true;
            }
            if(Vector3.Angle(footCenterToPosition, leftFootToPos) < 90)
            {
                canMoveLeftFoot = true;
            }

            if(canMoveRightFoot && canMoveLeftFoot)
            {
                //canMoveLeftFoot = false;
                if(rightFootToPos.sqrMagnitude > leftFootToPos.sqrMagnitude)
                {
                    canMoveLeftFoot = false;
                }
                else
                {
                    canMoveRightFoot = false;
                }
            }


            if(canMoveRightFoot)
            {
                Vector3 newFootPosition = m_rightFootTarget.position +
                    footCenterToPosition.normalized * rightFootToPos.magnitude * m_stepMultiplier;
                while(!MoveRightFoot(newFootPosition))
                {
                    newFootPosition += (m_rightFootTarget.position - newFootPosition).normalized * 0.02f;
                }
            }
            if(canMoveLeftFoot)
            {
                Vector3 newFootPosition = m_leftFootTarget.position +
                    footCenterToPosition.normalized * leftFootToPos.magnitude * m_stepMultiplier;
                while(!MoveLeftFoot(newFootPosition))
                {
                    newFootPosition += (m_leftFootTarget.position - newFootPosition).normalized * 0.02f;
                }

            }

        }


        /*m_rightFootTarget.position = Vector3.Lerp(m_targetRightFootPosition,
                m_rightFootTarget.position,
                Time.deltaTime * m_footMovementSmoothValue);
        m_leftFootTarget.position = Vector3.Lerp(m_targetLeftFootPosition,
            m_leftFootTarget.position,
            Time.deltaTime * m_footMovementSmoothValue);*/
    }

    private void BalanceFeet()
    {

    }

    private bool MoveRightFoot(Vector3 newRightFootPosition)
    {
        Debug.Log("MOVE RIGHT");
        if (Physics.Raycast(newRightFootPosition + Vector3.up * 1.5f,
            Vector3.down,
            out RaycastHit hitInfo,
            2f))
        {
            m_rightFootTarget.position = hitInfo.point;
            return true;
        }
        return false;
    }
    private bool MoveLeftFoot(Vector3 newLeftFootPosition)
    {
        Debug.Log("MOVE RIGHT");
        if (Physics.Raycast(newLeftFootPosition + Vector3.up * 1.5f,
            Vector3.down,
            out RaycastHit hitInfo,
            2f))
        {
            m_leftFootTarget.position = hitInfo.point;
            return true;
        }
        return false;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(m_leftFootTarget.position, 0.2f);
        Gizmos.DrawWireSphere(m_rightFootTarget.position, 0.2f);
        Debug.DrawLine(transform.position, transform.position + transform.up * 2f);
    }
}
