﻿using ProjElf.CombatController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyAICombatInventory : CombatInventory
{
    [SerializeField]
    private GrimoireData m_grimoireData = null;
    [SerializeField]
    private BowData m_bowData = null;
    [SerializeField]
    private MeleeWeaponData m_meleeWeaponData = null;
    private void Awake()
    {
        ChangeGrimoire(m_grimoireData);
        ChangeBow(m_bowData);
        ChangeMeleeWeapon(m_meleeWeaponData);
        SelectNextWeapon();
    }
}
