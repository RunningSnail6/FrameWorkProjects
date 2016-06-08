using UnityEngine;
using System.Collections;


//192.168.0
public enum ManagerID
{
    GameManager = 0,
    UIManager = FrameTools.MsgSpan,//3000
    AudioManager = FrameTools.MsgSpan * 2,//6000
    NPCManager = FrameTools.MsgSpan * 3,
    CharactorManager = FrameTools.MsgSpan * 4,
    AssetManager = FrameTools.MsgSpan * 5,
    NetManager = FrameTools.MsgSpan * 6,
}
public class FrameTools 
{
    public const int MsgSpan = 3000;

}
