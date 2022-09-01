using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class test1 : MonoBehaviour
{
    // 脚本挂在一个Canvas上，其子物体上有两个Button:Button 喝 Button（1）
    delegate void argument(string str);
    void Start()
    {
        argument arg = new argument(test);
        arg = arg + test2;
        for (int i = 0; i < gameObject.GetComponentsInChildren<Button>().Length; i++)
        {
            Button btn = gameObject.GetComponentsInChildren<Button>()[i];
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() =>
            {
                if (arg != null)
                {
                    arg(btn.name);
                }
            });
        }
    }

    void onclicked()
    {

    }
    public void test(string str)
    {
        switch (str)
        {
            case "Button":
                print("button");
                break;
            case "Button(1)":
                print("button");
                break;
            default:
                print("nothing");
                break;
        }
    }
    public void test2(string str)
    {
        print(str);
    }
}
