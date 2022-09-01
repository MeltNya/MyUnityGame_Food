using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//�ַ��¼�
//�����ʹ����¼�

public class EventManager : BaseManager<EventManager>
{
    //key:�¼�����,,IEventInfo��Ӧί��
    Dictionary<string, IEventInfo> eventDic = new Dictionary<string, IEventInfo>();
    public EventManager()
    {
        //Debug.Log("event mgr");
       // Dictionary<string, IEventInfo> eventDic = new Dictionary<string, IEventInfo>();
    }
    public void AddEventListener(string name, UnityAction action)
    {
        //1.�������ֵ2.û������Ӽ�:ֵ
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).actions += action;
        }
        else
        {
            eventDic.Add(name, new EventInfo(action));
        }
    }
    //���� ���ֵ���Ӷ���
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
    //���� �ȼ���ֵ���INVOKE
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
