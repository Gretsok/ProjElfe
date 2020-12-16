using ProjElf.SceneData;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Root : MonoBehaviour
{
    [SerializeField]
    private SceneData m_firstSceneData = null;

    private void Awake()
    {
        m_firstSceneData.LoadLevel();
    }

    private void Start()
    {
        SceneManager.UnloadSceneAsync(0);
    }
}
