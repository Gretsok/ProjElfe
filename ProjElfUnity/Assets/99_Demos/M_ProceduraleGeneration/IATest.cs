using UnityEngine;
using UnityEngine.AI;

public class IATest : MonoBehaviour
{
    public float speed = 5f;
    public NavMeshAgent agent = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;
        if(Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction -= Vector3.forward;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector3.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector3.left;
        }
        agent.SetDestination((transform.position + direction));
    }
}
