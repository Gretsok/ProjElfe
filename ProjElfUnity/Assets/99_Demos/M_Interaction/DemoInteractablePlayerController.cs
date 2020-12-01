using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjElf.Interaction;

public class DemoInteractablePlayerController : MonoBehaviour
{
    [SerializeField] Interactor m_interactor = null;
    private void Update()
    {
        m_interactor.ManageSight();
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
    
