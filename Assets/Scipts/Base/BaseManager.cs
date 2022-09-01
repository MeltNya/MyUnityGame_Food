using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//所有单例的基类
public class BaseManager<T>  where T:new()
{

    public static T Instance;
    //如果没有单例则创建单例
    public static T GetInstance()
    {
        if (Instance == null)
        {
            Instance = new T();
        }
        return Instance;
    }
    
}
