using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class InputMgr :BaseManager<InputMgr>
{
   
    private bool CanbeInputed = true;
    public bool CanbeGet = false;

    public InputMgr()
    {
        Debug.Log("input mgr");
        MonoManager.GetInstance().AddUpdateListner(InputUpdate);
    }
    void InputUpdate()
    {
        if (CanbeInputed == false)
        {
            return;
        }
        //1.键盘输入
        CheckKeyCode(KeyCode.Space);
       
        CheckKeyCode(KeyCode.B);
        //物品可以被拾取时检测f键输入
        if (CanbeGet) {
            CheckKeyCode(KeyCode.F); 
        }
        CheckKeyCode(KeyCode.A);
        CheckKeyCode(KeyCode.D);
        CheckKeyCode(KeyCode.E);
        CheckKeyCode(KeyCode.Escape);
    }
    void CheckKeyCode(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            Debug.Log("down the key");
            EventManager.GetInstance().EventTrigger("aKeyDown", key);
        }
        if (Input.GetKeyUp(key))
            EventManager.GetInstance().EventTrigger("aKeyUp", key);
    }
    void CheackMouse()
    {

    }
    public void StartCheck()
    {
        CanbeInputed = true;
    }
    public void EndCheck()
    {
        CanbeInputed = false;
    }
}
