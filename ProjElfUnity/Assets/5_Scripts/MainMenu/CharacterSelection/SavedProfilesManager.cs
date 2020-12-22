using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedProfilesManager : MonoBehaviour
{
    [SerializeField]
    private SavedProfileModule m_savedProfileModulePrefab = null;
    [SerializeField]
    private ButtonNavigationPosition m_createNewCharacterButtonPrefab = null;

    private List<INavigationPosition> m_instantiatedNavigationPositions = new List<INavigationPosition>();
    public INavigationPosition m_selectedPosition;

    public int NumberOfNavigationPositions => m_instantiatedNavigationPositions.Count;

    private const int MAX_PROFILES = 5;
    [SerializeField]
    private SaveData m_testSaveData = null;

    public void Inflate()
    {
        for(int i = 0; i < MAX_PROFILES; ++i)
        {
            AddSavedProfileModule(m_testSaveData);
        }

        CreateCreateNewCharacterButton();

        m_instantiatedNavigationPositions[0].OnSelected();
    }

    public void SelectPosition(int index)
    {
        if(m_selectedPosition != null)
        {
            m_selectedPosition.OnUnselected();
        }
        m_selectedPosition =  m_instantiatedNavigationPositions[index];
        m_selectedPosition.OnSelected();
    }

    private void AddSavedProfileModule(SaveData saveData)
    {
        SavedProfileModule newSaveProfileModule = Instantiate(m_savedProfileModulePrefab, transform);
        newSaveProfileModule.Inflate(saveData);
        newSaveProfileModule.OnUnselected();
        m_instantiatedNavigationPositions.Add(newSaveProfileModule);
    }

    private void CreateCreateNewCharacterButton()
    {
        ButtonNavigationPosition createNewCharacterButton = Instantiate(m_createNewCharacterButtonPrefab, transform);
        m_instantiatedNavigationPositions.Add(createNewCharacterButton);
    }
}
