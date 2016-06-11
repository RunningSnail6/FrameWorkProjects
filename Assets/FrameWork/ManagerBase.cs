using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventNode
{
    //当前数据
    public MonoBase data;
    //下一个节点
    public EventNode next;

    public EventNode(MonoBase tmpMono)
    {
        this.data = tmpMono;

        this.next = null;
    }
}

public class ManagerBase : MonoBase 
{
    //存储注册消息 key  value
    public Dictionary<ushort, EventNode> enventTree = new Dictionary<ushort, EventNode>();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mono">要注册的脚本</param>
    /// <param name="msgs">脚本  可以注册多个msg</param>
    public void RegistMsg(MonoBase mono,params ushort[] msgs)
    {
        for (int i = 0; i<msgs.Length;i++)
        {
            EventNode tmp = new EventNode(mono);

            RegistMsg(msgs[i], tmp);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id">根据msgid</param>
    /// <param name="node">node 链表</param>
    public void RegistMsg(ushort id,EventNode node)
    {
        //数据链路里 没有这个消息id
        if (!enventTree.ContainsKey(id))
        {
            enventTree.Add(id, node);
        }
        else
        {
            EventNode tmp = enventTree[id];
            //找到最后一个节点
            while (tmp.next != null)
            {
                tmp = tmp.next;
            }
            //直接挂到最后一个节点
            tmp.next = node;

        }
    }

    /// <summary>
    /// 去掉一个脚本的若干个消息
    /// </summary>
    /// <param name="mon"></param>
    /// <param name="msgs"></param>
    public void UnRegistMsg(MonoBase mon,params ushort[] msgs)
    {
        for(int i = 0;i<msgs.Length;i++)
        {
            UnRegistMsg(msgs[i], mon);
        }
    }
    
    /// <summary>
    /// 去掉一个消息链
    /// </summary>
    /// <param name="id"></param>
    /// <param name="node"></param>
    public void UnRegistMsg(ushort id,MonoBase node)
    {
        if(!enventTree.ContainsKey(id))
        {
            Debug.LogWarning("not contain id ==" + id);
            return;
        }
        else
        {
            EventNode tmp = enventTree[id];
            if(tmp.data == node)//去掉头部  包含两种情况
            {
                EventNode header = tmp;
                //已经存在这个消息
                if(header.next != null)//后面多个节点
                {
                    enventTree[id] = tmp.next;
                    header.next = null;

                    //header.data = tmp.next.data;//把下一个节点赋值给当前头部
                    //header.next = tmp.next.next;
                }
                else //只有一个节点的情况
                {
                    enventTree.Remove(id);
                }
            }
            else//去掉尾部和中间的节点
            {
                while(tmp.next != null && tmp.next.data != node)//下一个不是我要找的node 就一直遍历下去
                {
                    tmp = tmp.next;
                }//表示已经找到了该节点

                //没有引用会自动释放
                if(tmp.next.next != null)//去掉中间的
                {
                    tmp.next = tmp.next.next;
                }
                else//去掉尾部的
                {
                    tmp.next = null;
                }
            }
        }
    }

    //来了消息 通知整个消息链表
    public override void ProcessEvent(MsgBase tmpMsg)
    {
        if(!enventTree.ContainsKey(tmpMsg.msgId))
        {
            Debug.LogError("msg not contain msgid == " + tmpMsg.msgId);
            Debug.LogError("msg manager == " + tmpMsg.GetManager());
            return;
        }
        else
        {
            EventNode tmp = enventTree[tmpMsg.msgId];

            do
            {
                tmp.data.ProcessEvent(tmpMsg);
            }
            while (tmp != null);
        }
    }
}







