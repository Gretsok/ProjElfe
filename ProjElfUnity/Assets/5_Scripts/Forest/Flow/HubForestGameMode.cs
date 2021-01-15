using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubForestGameMode : ProjElfGameMode
{
    public override IEnumerator LoadAsync()
    {
        yield return 0;
        InstantiatePlayer();
        yield return base.LoadAsync();
        
    }
}
