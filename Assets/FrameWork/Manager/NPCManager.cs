using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCManager : ManagerBase
{

    public static NPCManager Instance = null;

    void Awake()
    {
        Instance = this;
    }

    public void SendMsg(MsgBase msg)
    {
        if (msg.GetManager() == ManagerID.NPCManager)
        {
            //Manager Base 本模块自己处理
            ProcessEvent(msg);
        }
        else
        {
            MsgCenter.Instance.SendToMsg(msg);
        }

    }

    public GameObject GetGameObject(string name)
    {
        if (sonMembers.ContainsKey(name))
        {
            return sonMembers[name];
        }

        return null;
    }

    public void RegistGameObject(string name, GameObject obj)
    {
        if (!sonMembers.ContainsKey(name))
        {
            sonMembers.Add(name, obj);
        }
    }

    public void UnRegistGameObject(string name)
    {
        if (!sonMembers.ContainsKey(name))
        {
            sonMembers.Remove(name);
        }
    }

    //规定了开发方式   消耗内存换取速度  和方便
    private Dictionary<string, GameObject> sonMembers = new Dictionary<string, GameObject>();
}
