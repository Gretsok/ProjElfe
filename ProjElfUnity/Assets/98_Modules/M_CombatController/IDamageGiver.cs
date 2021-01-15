﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    public interface IDamageGiver
    {
        CombatController Owner { get; }
        Damage Damage { get; }
        float Cooldown { get; }//Défini tout les combien de temps on peut prendre des dégâts.
        void OnCombatControllerHit(CombatController hitController);
    }
}
