using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//分发事件
//监听和触发事件

public class EventManager : BaseManager<EventManager>
{
    //key:事件名称,,IEventInfo对应委托
    Dictionary<string, IEventInfo> eventDic = new Dictionary<string, IEventInfo>();
    public EventManager()
    {
        //Debug.Log("event mgr");
       // Dictionary<string, IEventInfo> eventDic = new Dictionary<string, IEventInfo>();
    }
    public void AddEventListener(string name, UnityAction action)
    {
        //1.有则添加值2.没有则添加键:值
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).actions += action;
        }
        else
        {
            eventDic.Add(name, new EventInfo(action));
        }
    }
    //监听 往字典里加东西
    public void AddEventListener<T>(string name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).actions += action;
        }
        else
        {
            eventDic.Add(name, new EventInfo<T>(action));
        }
    }
        public void RemoveEventListener<T>(string name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
            (eventDic[name] as EventInfo<T>).actions -= action;
    }
    public void RemoveEventListener(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
            (eventDic[name] as EventInfo).actions -= action;
    }
    //触发 先检查字典再INVOKE
    public void EventTrigger(string name)
    {
        if (eventDic.ContainsKey(name))
        {
            if ((eventDic[name] as EventInfo).actions != null)
                (eventDic[name] as EventInfo).actions.Invoke();
        }
    }
    public void EventTrigger<T>(string name, T info)
    {
        if (eventDic.ContainsKey(name))
        {
            if ((eventDic[name] as EventInfo<T>).actions != null)
                (eventDic[name] as EventInfo<T>).actions.Invoke(info);
        }
    }
    public void Clear()
    {
        eventDic.Clear();
    }
}
