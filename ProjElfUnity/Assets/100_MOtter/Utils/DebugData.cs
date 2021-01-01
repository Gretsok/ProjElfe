#if UNITY_EDITOR

using ProjElf.SceneData;
using UnityEngine;

[CreateAssetMenu(fileName = "DebugData", menuName = "ScriptableObject/DebugData")]
public class DebugData : ScriptableObject
{
    [SerializeField]
    private SceneData m_defaultSceneData = null;

    public SceneData DefaultSceneData => m_defaultSceneData;
}

#endif
