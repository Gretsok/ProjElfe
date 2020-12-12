using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjElf.Interaction;

public class DemoInteractablePlayerController : MonoBehaviour
{
    [SerializeField] Interactor m_interactor = null;
    private void Update()
    {
        Ray rayToUse = new Ray(transform.position, transform.forward);
        m_interactor.ManageSight(rayToUse);
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Inventaire ouvert");
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            Debug.Log("Inventaire fermé");
        }
    }
}
    
