using ProjElf.CombatController;
using System;
using UnityEngine;

public class LavaTest : MonoBehaviour, IDamageGiver
{
    public CombatController Owner => null;
    [SerializeField]
    private Damage m_damage = null;
    public Damage Damage => m_damage;

    [SerializeField]
    private float m_cooldown = 1f;
    public float Cooldown => m_cooldown;

    public bool CanDoDamage => true;

    public Action<IDamageGiver> OnDisappear { get; set; }

    public void OnCombatControllerHit(CombatController hitController)
    {
    }

    private void OnDestroy()
    {
        OnDisappear?.Invoke(this);
    }


}
