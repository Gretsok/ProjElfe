using MOtter;
using MOtter.StatesMachine;
using UnityEngine;

public class TestPlaySound : State
{
    [SerializeField] private AudioClip m_audioClip = null;
    private float timeOfLastPlay = 0;
    [SerializeField] float durationBetweenTwoPlays = 1f;
    //private float volume = 1;

    AudioSource musicAS = null;

    [SerializeField] private ObjectMakingSoundIn3DSpaceSoundDemo m_noisyObject = null;

    public override void EnterState()
    {
        base.EnterState();
        //musicAS = MOtterApplication.GetInstance().SOUND.Play(m_audioClip, true, 1);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(Time.time - timeOfLastPlay > durationBetweenTwoPlays)
        {
            //MOtterApplication.GetInstance().SOUND.Play(m_audioClip, false, volume);
            //volume *= 0.95f;
            MOtterApplication.GetInstance().SOUND.PlayInSpace(m_audioClip, m_noisyObject.transform.position);
            timeOfLastPlay = Time.time;
        }

        if(Time.time - timeOfLastPlay > durationBetweenTwoPlays)
        {
            MOtterApplication.GetInstance().SOUND.Stop(musicAS);
        }
    }
}
