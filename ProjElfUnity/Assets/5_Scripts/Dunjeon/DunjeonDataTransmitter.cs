using UnityEngine;
using ProjElf.ProceduraleGeneration;

public class DunjeonDataTransmitter : MonoBehaviour
{
    private static DunjeonDataTransmitter s_instance = null;

    private DunjeonData m_dunjeonData = null;
    public static DunjeonData DunjeonData => s_instance.m_dunjeonData;


    public static DunjeonDataTransmitter CreateInstance(DunjeonData dunjeonData)
    {
        DestroyCurrentInstance();
        var transmitter_GO = new GameObject();
        transmitter_GO.name = "DunjeonDataTransmitter";
        DontDestroyOnLoad(transmitter_GO);
        s_instance = transmitter_GO.AddComponent<DunjeonDataTransmitter>();
        s_instance.m_dunjeonData = dunjeonData;
        return s_instance;
    }

    public static void DestroyCurrentInstance()
    {
        if(s_instance != null)
            Destroy(s_instance.gameObject);
        s_instance = null;
    }
}
