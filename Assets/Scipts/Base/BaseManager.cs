using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//���е����Ļ���
public class BaseManager<T>  where T:new()
{

    public static T Instance;
    //���û�е����򴴽�����
    public static T GetInstance()
    {
        if (Instance == null)
        {
            Instance = new T();
        }
        return Instance;
    }
    
}
