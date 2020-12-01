using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjElf.SceneData;

public class SceneLoaderDemo : MonoBehaviour 
{
    [SerializeField]
    [Tooltip("scenData to load")]
    SceneData scene = null;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("scene :" + scene.LevelName);
            scene.LoadLevel();
        }
    }
}
