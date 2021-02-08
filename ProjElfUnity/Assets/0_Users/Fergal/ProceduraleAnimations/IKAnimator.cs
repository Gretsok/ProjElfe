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
    private float m_stepDistance = 0.75f;

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
        if(Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfos, 5f))
        {
            m_controllerPositionOnGround = hitInfos.point;
        }
        Vector3 relativeFootCenterToPosition = transform.InverseTransformDirection(
            (m_controllerPositionOnGround - Vector3.Lerp(m_leftFootTarget.position, m_rightFootTarget.position, 0.5f)));
        if (relativeFootCenterToPosition.magnitude > m_minDistanceToStep)
        {
            Vector3 rightFootToPos = (m_controllerPositionOnGround - m_rightFootTarget.position);
            Vector3 leftFootToPos = (m_controllerPositionOnGround - m_leftFootTarget.position);

            if (Mathf.Abs(relativeFootCenterToPosition.z) > Mathf.Abs(relativeFootCenterToPosition.x))
            {
                if (Mathf.Sign(relativeFootCenterToPosition.z) * transform.InverseTransformPoint(m_rightFootTarget.position).z >
                Mathf.Sign(relativeFootCenterToPosition.z) * transform.InverseTransformPoint(m_leftFootTarget.position).z)
                {
                    Debug.Log("MOVE LEFT");
                    /*Vector3 newFootPosDirection = new Vector3(rightFootToPos.x,
                        leftFootToPos.y,
                        leftFootToPos.z).normalized * m_stepDistance;*/
                    Vector3 newFootPosDirection = transform.InverseTransformDirection(
                        new Vector3(-0.2f,
                        0,
                        m_stepDistance * Mathf.Sign(relativeFootCenterToPosition.z))
                        );
                    if (Physics.Raycast(m_controllerPositionOnGround + newFootPosDirection + Vector3.up * 1.5f,
                        Vector3.down,
                        out RaycastHit hitInfo,
                        10f))
                    {
                        m_targetLeftFootPosition = hitInfo.point;
                    }
                }
                else
                {
                    Debug.Log("MOVE RIGHT");
                    /*Vector3 newFootPosDirection = new Vector3(leftFootToPos.x,
                        rightFootToPos.y,
                        rightFootToPos.z).normalized * m_stepDistance;*/
                    Vector3 newFootPosDirection = transform.InverseTransformDirection(
                        new Vector3(0.2f,
                        0,
                        m_stepDistance * Mathf.Sign(relativeFootCenterToPosition.z))
                        );
                    if (Physics.Raycast(m_controllerPositionOnGround + newFootPosDirection + Vector3.up * 1.5f,
                        Vector3.down,
                        out RaycastHit hitInfo,
                        10f))
                    {
                        m_targetRightFootPosition = hitInfo.point;
                    }
                }
            }
            else
            {

            }            
        }

        m_rightFootTarget.position = m_targetRightFootPosition;
        m_leftFootTarget.position = m_targetLeftFootPosition;
        /*m_rightFootTarget.position = Vector3.Lerp(m_targetRightFootPosition,
                m_rightFootTarget.position,
                Time.deltaTime * m_footMovementSmoothValue);
        m_leftFootTarget.position = Vector3.Lerp(m_targetLeftFootPosition,
            m_leftFootTarget.position,
            Time.deltaTime * m_footMovementSmoothValue);*/
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(m_leftFootTarget.position, 0.2f);
        Gizmos.DrawWireSphere(m_rightFootTarget.position, 0.2f);
        Debug.DrawLine(transform.position, transform.position + transform.up * 2f);
    }
}
