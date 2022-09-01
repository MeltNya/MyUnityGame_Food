using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonoControl : MonoBehaviour
{
    public event UnityAction updateEvent;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    
    void Update()
    {
        if (updateEvent != null)
        {
            updateEvent();
        }
    }

    public void AddUpdateListner(UnityAction func)
    {
        updateEvent += func;
    }
    public void RemoveUpdateListner(UnityAction func)
    {
        updateEvent -= func;
    }
    
}
