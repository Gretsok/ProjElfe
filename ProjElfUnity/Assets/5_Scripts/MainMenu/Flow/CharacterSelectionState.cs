using MOtter;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjElf.MainMenu
{
    public class CharacterSelectionState : MainMenuNavigationState
    {

        private bool m_hasInflate = false;
        private bool m_isDeletingCharacter = false;
        private float m_timeOfStartDeleting = float.MinValue;
        [SerializeField]
        private float m_deleteCharacterDuration = 2f;
        private SavedProfileModule m_currentProfileGettingDeleted = null;

        public override void EnterState()
        {
            base.EnterState();
            if(!m_hasInflate)
            {
                m_mainStateMachine.ProfileManager.Inflate(MOtterApplication.GetInstance().GAMEMANAGER.SaveDataManager.SaveDataList.ToArray());
                m_hasInflate = true;
            }

            m_mainStateMachine.CameraManager.SetCharacterCamera();

            m_mainStateMachine.Actions.FindActionMap("UI").FindAction("DeleteCharacter").started += DeleteCharacterStarted;
            m_mainStateMachine.Actions.FindActionMap("UI").FindAction("DeleteCharacter").canceled += DeleteCharacterCanceled;
        }

        private void DeleteCharacterCanceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {      
            if(m_isDeletingCharacter)
            {
                m_isDeletingCharacter = false;
                Debug.Log("Cancel current character deletion");
                m_currentProfileGettingDeleted.SetDeletionAdvancement(0);
                m_currentProfileGettingDeleted = null;
            }
        }


        private void DeleteSelectedCharacter()
        {
            if(EventSystem.current.currentSelectedGameObject.TryGetComponent<SavedProfileModule>(out SavedProfileModule profileModule))
            {
                SaveData currentCharacterSaveData = profileModule.SaveData;
                MOtterApplication.GetInstance().GAMEMANAGER.SaveDataManager.RemoveSaveData(currentCharacterSaveData);
                m_mainStateMachine.ProfileManager.Inflate(MOtterApplication.GetInstance().GAMEMANAGER.SaveDataManager.SaveDataList.ToArray());
                EventSystem.current.SetSelectedGameObject(m_mainStateMachine.ProfileManager.PlayButton.gameObject);

            }
            else
            {
                Debug.LogError("Current Selected GO is not a SavedProfileModule");
            }
            m_currentProfileGettingDeleted = null;
        }


        private void DeleteCharacterStarted(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if(!m_isDeletingCharacter && EventSystem.current.currentSelectedGameObject.TryGetComponent<SavedProfileModule>(out SavedProfileModule profileModule))
            {
                Debug.Log("Starting to delete current character");
                m_timeOfStartDeleting = Time.time;
                m_isDeletingCharacter = true;
                m_currentProfileGettingDeleted = profileModule;
            }

            
        }

        public override void LateUpdateState()
        {
            base.LateUpdateState();
            if(m_isDeletingCharacter)
            {
                m_currentProfileGettingDeleted.SetDeletionAdvancement((Time.time - m_timeOfStartDeleting) / m_deleteCharacterDuration);
                if (Time.time - m_timeOfStartDeleting > m_deleteCharacterDuration)
                {
                    m_currentProfileGettingDeleted.SetDeletionAdvancement(0);
                    DeleteSelectedCharacter();
                    m_isDeletingCharacter = false;
                    
                }
            }
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


        public override void ExitState()
        {
            m_mainStateMachine.Actions.FindActionMap("UI").FindAction("DeleteCharacter").started -= DeleteCharacterStarted;
            m_mainStateMachine.Actions.FindActionMap("UI").FindAction("DeleteCharacter").canceled -= DeleteCharacterCanceled;
            base.ExitState();
        }
    }
}