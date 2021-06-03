using MOtter.Localization;
using System.Collections;
using UnityEngine;

namespace ProjElf.HubForest
{
    public class InventoryNotification : MonoBehaviour
    {
        [SerializeField]
        private TextLocalizer m_notificationLocalizer = null;

        private Coroutine m_notificationRoutine = null;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void DisplayNotification(string notificationKey, System.Action<string, TextLocalizer> format, float notificationDuration = 1.5f)
        {
            gameObject.SetActive(true);

            if(m_notificationRoutine != null)
            {
                StopCoroutine(m_notificationRoutine);
            }

            m_notificationRoutine = StartCoroutine(NotificationRoutine(notificationKey, format, notificationDuration));
        }

        private IEnumerator NotificationRoutine(string notificationKey, System.Action<string, TextLocalizer> format, float notificationDuration = 1.5f)
        {
            m_notificationLocalizer.SetKey(notificationKey);
            m_notificationLocalizer.SetFormatter(format);
            yield return new WaitForSeconds(notificationDuration);
            gameObject.SetActive(false);
        }
    }
}