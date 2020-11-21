using MOtter;
using MOtter.StatesMachine;
using System.Collections.Generic;
using UnityEngine;

public class TestDemoInputState : UIState
{
    private List<InputDemoPlayer> m_players = new List<InputDemoPlayer>();

    [SerializeField] private InputDemoPlayer m_playerPrefab = null;

    public override void EnterState()
    {
        base.EnterState();
        int nbOfPlayers = MOtterApplication.GetInstance().PLAYERPROFILES.PlayerProfiles.Length;
        for(int i = 0; i < nbOfPlayers; i++)
        {
            var player = Instantiate<InputDemoPlayer>(m_playerPrefab);
            player.Init(i);
            m_players.Add(player);
        }
    }

    public override void UpdateState()
    {
        base.UpdateState();
        for (int i = 0; i < m_players.Count; i++)
        {
            m_players[i].UpdatePlayer();
        }
    }

    public override void ExitState()
    {
        for(int i = 0; i < m_players.Count; i++)
        {
            m_players[i].CleanUpInputs();
        }
        base.ExitState();
    }
}
