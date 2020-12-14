using MOtter.StatesMachine;
using UnityEngine;

namespace ProjElf.AI
{
    public class GenericAIState : State
    {
        [SerializeField]
        protected GenericAI m_owner = null;
        [SerializeField]
        protected float m_walkingSpeed = 5f;
    }
}