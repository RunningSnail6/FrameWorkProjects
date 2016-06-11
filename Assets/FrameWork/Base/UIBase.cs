using UnityEngine;
using System.Collections;

public class UIBase : MonoBase 
{
    public override void ProcessEvent(MsgBase tmpMsg)
    {
        //throw new System.NotImplementedException();
    }

	public void RegistSelf(MonoBase mono,params ushort[] msgs)
    {
        UIManager.Instance.RegistMsg(mono, msgs);
    }

    public void UnRegistSelf(MonoBase mono,params ushort[] msgs)
    {
        UIManager.Instance.UnRegistMsg(mono, msgs);
    }

    public void SendMsg(MsgBase msg)
    {
        UIManager.Instance.SendMsg(msg);
    }

    public ushort[] msgIds;

    void OnDestory()
    {
        if(msgIds != null)
        {
            UnRegistSelf(this, msgIds);
        }
    }
}
