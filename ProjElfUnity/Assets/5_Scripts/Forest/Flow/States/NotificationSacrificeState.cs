using UnityEngine;
using ProjElf.AnimalManagement;
using MOtter.StatesMachine;

namespace ProjElf.HubForest
{
    public class NotificationSacrificeState : UIState
    {
        private HubForestGameMode m_gamemode = null;
        private SaveData m_saveData = null;
        private AnimalData m_RandomAnimal = null;

        private float m_timeOfStart = float.MaxValue;
        [SerializeField]
        private float m_stateDuration = 4f;
        public override void EnterState()
        {
            base.EnterState();

            m_gamemode = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<HubForestGameMode>(); ;
            m_saveData = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>();

            m_RandomAnimal = m_saveData.GetRandomAnimalData();
            GetPanel<SacrifyNotificationPanel>().InflateAnimalData(m_RandomAnimal);
            Debug.Log($"Randomly sacrifice {m_RandomAnimal.NameKey}");

            AnimalsManager.GetInstance().SacrificeRescuedAnimal(m_RandomAnimal);

            RemoveAnimalFromScene(m_RandomAnimal);

            m_gamemode.Player.GetComponent<PlayerController.PlayerStatsImprovementsManager>().ImprovePlayer(AnimalsManager.GetInstance().SavedAnimals);

            m_timeOfStart = Time.time;
        }

        public void RemoveAnimalFromScene(AnimalData animalData)
        {
            var animal = m_gamemode.Animals.Find(x => x.Animal.AnimalData == animalData);
            m_gamemode.Animals.Remove(animal);
            Destroy(animal.gameObject);
        }


        public override void UpdateState()
        {
            base.UpdateState();
            if(Time.time - m_timeOfStart > m_stateDuration)
            {
                MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<HubForestGameMode>().SwitchToDefaultState();

                m_timeOfStart = float.MaxValue;
            }
        }
    }
}
