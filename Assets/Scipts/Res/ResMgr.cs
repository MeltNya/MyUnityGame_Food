using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResMgr : BaseManager<ResMgr>
{
    //同步加载
    //gameobject进行实例化,其他文本文件直接返回为该类型
    public T Load<T>(string name) where T : Object
    {
        T res = Resources.Load<T>(name);
        if (res is GameObject)
            return GameObject.Instantiate(res);
        else
            return res;
    }
    public T LoadatPostion<T>(string name,Vector3 vector) where T : Object
    {
        T res = Resources.Load<T>(name);
        if (res is GameObject)
            return GameObject.Instantiate(res,vector,Quaternion.identity);
        else
            return res;
    }
    //异步加载,需要使用协程
    //用来加载文本场景等
    public void LoadAsync<T>(string name,UnityAction<T> callback=null ) where T:Object
    {
        MonoManager.GetInstance().startCoroutine(ReallyLoadAsync(name, callback));
    }
    private IEnumerator ReallyLoadAsync<T>(string name, UnityAction<T> callback)  where T:Object
    {
        ResourceRequest r = Resources.LoadAsync<T>(name);
        yield return r;

        if(r.asset is GameObject)
        {
           T obj =  (GameObject.Instantiate(r.asset)) as T;
           if(callback!=null)
                callback(obj);
        }
        else
        {
            if (callback != null)
                callback(r.asset as T);
        }
        
    }

 }
