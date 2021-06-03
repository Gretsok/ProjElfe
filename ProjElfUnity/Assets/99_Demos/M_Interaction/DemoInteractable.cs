using ProjElf.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoInteractable : MonoBehaviour, IInteractable
{
    bool isWatched = false;
    public void DoInteraction(Interactor iteractor = null)
    {
        Debug.Log("DoIneraction");
    }

    public void StartBeingWatched(Interactor iteractor)
    {
        isWatched = true;
        Debug.Log("isWatched = "+isWatched);
        Debug.Log("GameObject = " + gameObject.name);
        Debug.Log("Press E to open inventory");
        
    }

    public void StopBeingWatched(Interactor iteractor)
    {
        isWatched = false;
        Debug.Log("isWatched = " + isWatched);
    }
}
