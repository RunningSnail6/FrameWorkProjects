using UnityEngine;
using System.Collections;


//收集面板下所有的控件的事件处理
//对外通信
public class Load : UIBase 
{
    public override void ProcessEvent(MsgBase tmpMsg)
    {
        //接收事件
        //base.ProcessEvent(tmpMsg);
        switch(tmpMsg.msgId)
        {
            case (ushort)UIEventZhao.Load:
                {
                    //处理逻辑
                }
                break;

            case (ushort)UIEventZhao.Regist:
                {
                    //处理逻辑
                }
                break;
        }
    }

    void Start()
    {
        msgIds = new ushort[]
        {
            (ushort)UIEventZhao.Load,
            (ushort)UIEventZhao.Regist,
        };

        RegistSelf(this, msgIds);


        //用空间换取方便
        //UIManager.Instance.GetGameObject("LightOn").GetComponent<UIBehaviour>().AddButtonListener(ButtonClick);
    }

    public void ButtonClick()
    {
        //SendMsg();
        //MsgBase tmpBase = new MsgBase((ushort)UIEventZhao.Load);
        //SendMsg(tmpBase);

        MsgTransform tmpTrans = new MsgTransform((ushort)UIEventZhao.Load, transform);
        SendMsg(tmpTrans);

    }
}
