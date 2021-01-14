using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMainMenuPanel : Panel
{
    [SerializeField]
    private ButtonNavigationPosition m_continueButton = null;
    [SerializeField]
    private ButtonNavigationPosition m_quitGameButton = null;
    [SerializeField]
    private ButtonNavigationPosition m_backToMenuButton = null;
    [SerializeField]
    private ButtonNavigationPosition m_optionsButton = null;

    public ButtonNavigationPosition ContinueButton => m_continueButton;
    public ButtonNavigationPosition QuitGameButton => m_quitGameButton;
    public ButtonNavigationPosition BackToMenuButton => m_backToMenuButton;
    public ButtonNavigationPosition OptionsButton => m_optionsButton;
}
