using MOtter;
using MOtter.StatesMachine;
using UnityEngine;

public class DemoLocaState : State
{
    public override void UpdateState()
    {
        base.UpdateState();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            MOtterApplication.GetInstance().LOCALIZATION.SwitchToNextLanguage();
            Debug.Log("prout");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            MOtterApplication.GetInstance().LOCALIZATION.SwitchToPreviousLanguage();
            Debug.Log("prout");
        }
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }*/
    }
}
