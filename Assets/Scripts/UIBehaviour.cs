using UnityEngine;
using System.Collections;

public class UIBehaviour : MonoBehaviour {

    //把控件script注册到UIManager
    //可以直接查找 物体 把物体本身注册到UIManager

    void Awake()
    {
        UIManager.Instance.RegistGameObject(name, gameObject);
    }
}
