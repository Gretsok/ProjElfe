using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LanguageModule : Selectable
{
    public void GoRight()
    {
        Debug.Log("Go right");
        MOtter.MOtterApplication.GetInstance().LOCALIZATION.SwitchToNextLanguage();
    }

    public void GoLeft()
    {
        Debug.Log("Go left");
        MOtter.MOtterApplication.GetInstance().LOCALIZATION.SwitchToPreviousLanguage();
    }

    public override void OnMove(AxisEventData eventData)
    {
        base.OnMove(eventData);
        if(eventData.moveDir == MoveDirection.Left)
        {
            GoLeft();
        }
        else if(eventData.moveDir == MoveDirection.Right)
        {
            GoRight();
        }
    }
}
