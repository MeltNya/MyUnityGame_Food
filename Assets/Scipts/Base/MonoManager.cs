using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonoManager : BaseManager<MonoManager>
{
    private MonoControl monoController;
    public MonoManager()
    {
        GameObject obj = new GameObject("MonoController");
        monoController = obj.AddComponent<MonoControl>();
    }
    public void AddUpdateListner(UnityAction func)
    {
        monoController.AddUpdateListner(func);
    }
    public void RemoveUpdateListner(UnityAction func)
    {
        monoController.RemoveUpdateListner(func);
    }
    public Coroutine startCoroutine(IEnumerator routine)
    {
        return monoController.StartCoroutine(routine);
    }
}
