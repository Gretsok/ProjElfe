using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjElf.AnimalManagement;
using MOtter.StatesMachine;

namespace ProjElf.HubForest
{
    public class NotificationSacrificeState : UIState
    {
        private SaveData m_saveData = null;
        private AnimalData m_RandomAnimal = null;


        public override void EnterState()
        {
            base.EnterState();
            m_RandomAnimal = m_saveData.GetRandomAnimalData();
            GetPanel<SacrifyNotificationPanel>().InflateAnimalData(m_RandomAnimal);
        }
       
    }
}
