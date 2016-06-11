using UnityEngine;
using System.Collections;

public class MsgCenter : MonoBehaviour {

    public static MsgCenter Instance = null;

    void Awake()
    {
        Instance = this;

        gameObject.AddComponent<UIManager>();
        gameObject.AddComponent<UIManager>();
        //等等
    }

	public void SendToMsg(MsgBase tmpMsg)
    {
        AnasysisMsg(tmpMsg);
    }

    private void AnasysisMsg(MsgBase tmpMsg)
    {
        ManagerID tmpId = tmpMsg.GetManager();

        switch(tmpId)
        {
            case ManagerID.AssetManager:
                break;
            case ManagerID.AudioManager:
                break;
            case ManagerID.CharactorManager:
                break;
            case ManagerID.GameManager:
                break;
            case ManagerID.NetManager:
                break;
            case ManagerID.NPCManager:
                break;
            case ManagerID.UIManager:
                break;
            default:
                break;

        }
    }
}
