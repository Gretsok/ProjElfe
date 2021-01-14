#if UNITY_EDITOR

using ProjElf.SceneData;
using UnityEngine;

[CreateAssetMenu(fileName = "DebugData", menuName = "ScriptableObject/DebugData")]
public class DebugData : ScriptableObject
{
    [SerializeField]
    private SceneData m_defaultSceneData = null;
    [SerializeField]
    private bool m_useDefaultSaveData = false;
    [SerializeField]
    private SaveData m_defaultSaveData = null;
    
    public SceneData DefaultSceneData => m_defaultSceneData;
    public bool UseDefaultSaveData => m_useDefaultSaveData;
    public SaveData DefaultSaveData => m_defaultSaveData;
}

#endif
