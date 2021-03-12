using MOtter;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjElf.MainMenu
{
    public class CharacterSelectionState : MainMenuNavigationState
    {

        private bool m_hasInflate = false;

        public override void EnterState()
        {
            base.EnterState();
            if(!m_hasInflate)
            {
                m_mainStateMachine.ProfileManager.Inflate(MOtterApplication.GetInstance().GAMEMANAGER.SaveDataManager.SaveDataList.ToArray());
                m_hasInflate = true;
            }

            m_mainStateMachine.CameraManager.SetCharacterCamera();
        }

       

        public void Confirm()
        {
            GameObject currSelection = EventSystem.current.currentSelectedGameObject;
            if(currSelection.TryGetComponent<SavedProfileModule>(out SavedProfileModule profile))
            {
                // Load Game with correct Save Data
                Debug.Log("TRYING TO LOAD A SAVE");
                m_mainStateMachine.LoadHub(profile.SaveData);
            }
        }

    }
}