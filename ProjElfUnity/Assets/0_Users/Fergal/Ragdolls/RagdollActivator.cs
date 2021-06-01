using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RagdollActivator : MonoBehaviour
{
    [SerializeField]
    private Transform m_gameplayModelRoot = null;
    [SerializeField]
    private Transform m_ragdollModelRoot = null;

    [SerializeField]
    private List<Collider> m_collidersToDisableOnRagdoll = new List<Collider>();

    private void Awake()
    {
        m_ragdollModelRoot.gameObject.SetActive(false);
    }

    public void ActivateRagdoll()
    {
        AlignChildren(m_ragdollModelRoot, m_gameplayModelRoot);
        m_ragdollModelRoot.gameObject.SetActive(true);
        m_collidersToDisableOnRagdoll.ForEach(x => x.enabled = false);
        m_gameplayModelRoot.gameObject.SetActive(false);
    }

   /* public void ActivateGameplay()
    {
        AlignChildren(m_gameplayModelRoot, m_ragdollModelRoot);
        
        m_gameplayModelRoot.gameObject.SetActive(true);
        m_collidersToDisableOnRagdoll.ForEach(x => x.enabled = true);
        m_ragdollModelRoot.gameObject.SetActive(false);
    }*/

    private void AlignChildren(Transform target, Transform model)
    {
        for(int i = 0; i < target.childCount; ++i)
        {
            if(model.childCount > i)
            {
                Transform currentTargetChild = target.GetChild(i);
                Transform currentModelChild = model.GetChild(i);
                if (currentModelChild != null && currentTargetChild != null)
                {
                    currentTargetChild.localPosition = currentModelChild.localPosition;
                    currentTargetChild.localScale = currentModelChild.localScale;
                    currentTargetChild.localRotation = currentModelChild.localRotation;
                    AlignChildren(currentTargetChild, currentModelChild);
                }
            }
        }
    }
}

[CustomEditor(typeof(RagdollActivator), true)]
public class RagdollActivatorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Activate Ragdoll"))
        {
            (target as RagdollActivator).ActivateRagdoll();
        }
        /*if (GUILayout.Button("Activate Gameplay"))
        {
            (target as RagdollActivator).ActivateGameplay();
        }*/
    }
}
