using System;

public enum UIEventZhao
{
    Load = ManagerID.UIManager,
    Regist,

    MaxValue
}


public enum UIEventZhou
{
    NPCAttack = UIEventZhao.MaxValue,
    NPCBlood,

    MaxValue
}