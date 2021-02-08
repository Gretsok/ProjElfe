using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Controller : MonoBehaviour
{
    [SerializeField]
    private float m_speed = 5f;
    private Rigidbody m_rigidbody = null;
    private PlayerInputsActions m_actions = null;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_actions = new PlayerInputsActions();
        m_actions.Enable();
    }

    void FixedUpdate()
    {
        if(m_rigidbody.velocity.magnitude < m_speed)
        {
            float value = -m_actions.Generic.Move.ReadValue<Vector2>().x;
            if(value != 0)
            {
                m_rigidbody.AddForce(0, 0, value * Time.fixedDeltaTime * 3000f);
            }
        }
    }
}
