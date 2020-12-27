using MOtter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsLanguageManagementState : NavigationState
{
    public void SelectNextLanguage()
    {
        MOtterApplication.GetInstance().LOCALIZATION.SwitchToNextLanguage();
    }

    public void SelectPreviousLanguage()
    {
        MOtterApplication.GetInstance().LOCALIZATION.SwitchToPreviousLanguage();
    }
}
