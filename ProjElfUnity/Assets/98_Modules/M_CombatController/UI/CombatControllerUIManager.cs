using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    public class CombatControllerUIManager : MonoBehaviour
    {
        internal virtual void InitWithGamemode(ProjElfGameMode a_gamemode)
        {

        }

        internal virtual void SetHealthRatio(float healthRatio)
        {

        }

        internal virtual void SetHealthRemaining(float healthRemaining)
        {

        }

        internal virtual void DisplayFloatingDamage(int damage)
        {

        }

        internal void Hide()
        {
            gameObject.SetActive(false);
        }

        internal void Show()
        {
            gameObject.SetActive(true);
        }
    }
}