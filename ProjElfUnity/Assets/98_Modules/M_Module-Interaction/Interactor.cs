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
            m_currentInteractableInSight?.DoInteraction(this);
        }
        /// <summary>
        /// Cette methode va gerer les ray cast et peut etre l'affichage d'un billboard au dessus du cube 
        /// </summary>
        public void ManageSight(Ray ray)
        {
#if UNITY_EDITOR
            rayToDisplay = ray;
#endif

            RaycastHit hit; // on envoie un rayon 

            if (Physics.Raycast(ray, out hit, m_maxDistance)) // <- On 
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

#if UNITY_EDITOR
        private Ray rayToDisplay;
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(rayToDisplay.origin, rayToDisplay.origin + rayToDisplay.direction * m_maxDistance);
        }

#endif
    }
}

