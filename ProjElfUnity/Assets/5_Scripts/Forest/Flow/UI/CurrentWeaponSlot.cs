using ProjElf.CombatController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CurrentWeaponSlot : MonoBehaviour
{
    [SerializeField]
    private RawImage m_rawImgSlot = null;
    [SerializeField]
    private RenderTexture m_renderTexture = null;
    private WeaponRenderTextureStudio m_renderTextureStudio = null;

    private void Awake()
    {
        m_rawImgSlot.texture = m_renderTexture;
    }

    public void Inflate(AWeaponData weaponData, WeaponRenderTextureStudio renderTextureStudio)
    {
        m_renderTextureStudio = renderTextureStudio;
        m_renderTextureStudio.Inflate(weaponData, m_renderTexture);
    }

    public void Clear()
    {
        if(m_renderTextureStudio != null)
        {
            Destroy(m_renderTextureStudio.gameObject);
        }
    }
}
