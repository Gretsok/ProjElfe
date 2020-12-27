using MOtter.StatesMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigurationOptionsState : OptionsNavigationTabState
{
    [SerializeField]
    private OptionsSoundManagementState m_soundManagementState = null;
    [SerializeField]
    private OptionsLanguageManagementState m_languageManagementState = null;

    public OptionsSoundManagementState SoundManagementState => m_soundManagementState;
    public OptionsLanguageManagementState LanguageManagementState => m_languageManagementState;
}
