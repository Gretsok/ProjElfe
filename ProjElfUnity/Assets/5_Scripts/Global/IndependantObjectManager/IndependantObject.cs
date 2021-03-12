using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.IndependantObject
{
    public interface IndependantObject
    {
        void DoUpdate();
        void DoFixedUpdate();
        void DoLateUpdate();
    }
}