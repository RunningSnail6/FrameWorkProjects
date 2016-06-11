using UnityEngine;
using System.Collections;

public class MsgBase 
{

    //表示 65535 个消息 占两个字节 ip
    public ushort msgId;

    public ManagerID GetManager()
    {
        int tmpId = msgId / FrameTools.MsgSpan;
        return (ManagerID)(tmpId * FrameTools.MsgSpan);
    }

    public MsgBase(ushort tmpMsg)
    {
        msgId = tmpMsg;
    }

}

public class MsgTransform:MsgBase
{
    public Transform value;

    public MsgTransform():base(0)
    {

    }

    public MsgTransform(ushort tmpId,Transform tmpTrans):base(tmpId)
    {
        this.msgId = tmpId;
        this.value = tmpTrans;
    }
}
