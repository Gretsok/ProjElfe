using MOtter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsLanguageManagementState : OptionsModuleState
{
    public void SelectNextLanguage()
    {
        MOtterApplication.GetInstance().LOCALIZATION.SwitchToNextLanguage();
    }

    public void SelectPreviousLanguage()
    {
        MOtterApplication.GetInstance().LOCALIZATION.SwitchToPreviousLanguage();
    }

    public override void GoLeft()
    {
        base.GoLeft();
        SelectPreviousLanguage();
    }

    public override void GoRight()
    {
        base.GoRight();
        SelectNextLanguage();
    }
}
