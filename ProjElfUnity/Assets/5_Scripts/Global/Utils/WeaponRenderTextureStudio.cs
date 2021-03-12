using ProjElf.CombatController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRenderTextureStudio : MonoBehaviour
{
    [SerializeField]
    private Transform m_spawnPoint = null;
    [SerializeField]
    private Camera m_camerea = null;

    [SerializeField]
    private float m_rotationSpeed = 90f;

    public void Inflate(AWeaponData weaponData, RenderTexture renderTexture)
    {
        m_camerea.targetTexture = renderTexture;
        Instantiate(weaponData.WeaponPrefab, m_spawnPoint.position, Quaternion.identity, m_spawnPoint);
    }

    private void Update()
    {
        m_spawnPoint.Rotate(Vector3.up, m_rotationSpeed * Time.deltaTime);
    }
}
