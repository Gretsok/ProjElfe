using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.Interaction
{
    
    
    public class Interactor : MonoBehaviour // component qui va etre dans player controller 
    {
        // Implementation of IInterractable<T> interface
        //private m_currentInteractableInSight: IInteractable;
       [SerializeField] private float m_maxDistance = 100f;
        private IInteractable m_currentInteractableInSight = null; // objet en vue 
        public void Interact()
        {
            m_currentInteractableInSight?.DoInteraction();
        }
       /// <summary>
       /// Cette methode va gerer les ray cast et peut etre l'affichage d'un billboard au dessus du cube 
       /// </summary>
       public void ManageSight()
        {
            RaycastHit hit; // on envoie un rayon 

            if (Physics.Raycast(transform.position, transform.forward, out hit,m_maxDistance)) // <- On 
            {
                IInteractable currentInteractableCollider = hit.collider.GetComponent<IInteractable>(); // on recupere l'interectable -> soit null / soit Interactable
                if (m_currentInteractableInSight != currentInteractableCollider)
                {
                    currentInteractableCollider?.StartBeingWatched();
                    m_currentInteractableInSight?.StopBeingWatched(); //on passe au suivant 
                    m_currentInteractableInSight = currentInteractableCollider;
                }
            }
            else
            {
                m_currentInteractableInSight?.StopBeingWatched();
                m_currentInteractableInSight = null;
            }             
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * m_maxDistance);
        }
    }
}

