using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public Vector3[] Position;
    public float Speed = 1.0f;

    private int m_currentIndex = 0 ;
    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = default;
        transform.position = Vector3.Lerp(transform.position, currentPos, Speed * Time.deltaTime);

    }
}
