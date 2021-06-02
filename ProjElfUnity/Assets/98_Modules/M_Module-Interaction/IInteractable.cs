using UnityEngine;

namespace ProjElf.Interaction
{
    
    public interface IInteractable 
    {
        GameObject gameObject { get; } // on ne peut pas mettre d'attribut dans une interface. du coup on doit la get 
        void DoInteraction(Interactor interactor);
        void StartBeingWatched(Interactor interactor);
        void StopBeingWatched(Interactor interactor);
    }
    
}