using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MOtter.PlayersManagement
{
    public class PlayerProfileManager : MonoBehaviour
    {
        [SerializeField]
        private PlayerProfile m_playerProfilePrefab = null;

        private List<PlayerProfile> m_instantiatedPlayerProfiles = new List<PlayerProfile>();

        public List<PlayerProfile> PlayerProfiles => m_instantiatedPlayerProfiles;

        private void Awake()
        {
            AddNewPlayer();
        }

        public PlayerProfile AddNewPlayer()
        {
            PlayerProfile newPlayer = Instantiate(m_playerProfilePrefab, transform);

            bool indexFree = false;
            int indexToSet = -1;

            do
            {
                indexToSet++;
                indexFree = true;
                for(int i = 0; i < PlayerProfiles.Count; ++i)
                {
                    if(PlayerProfiles[i].Index == indexToSet)
                    {
                        indexFree = false;
                        break;
                    }
                }
            } while (!indexFree);

            newPlayer.Init(indexToSet);
            m_instantiatedPlayerProfiles.Add(newPlayer);
            Debug.Log($"Created new player with Index {newPlayer.Index}");

            return newPlayer;
        }

        public InputActionAsset GetActions(int playerIndex)
        {
            return PlayerProfiles[playerIndex].Actions;
        }

        public void RemovePlayer(int playerIndex)
        {
            RemovePlayer(GetPlayerByIndex(playerIndex));
        }

        public void RemovePlayer(PlayerProfile playerProfile)
        {

        }

        public PlayerProfile GetPlayerByIndex(int index)
        {
            return PlayerProfiles.Find(x => x.Index == index);
        }



    }
}
