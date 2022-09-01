using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//canvas��eventSystem�����������Ƴ�
//����UI����ʾ/����
public class UIManager : BaseManager<UIManager>
{
    //panel�Ļ����
    public Dictionary<string, BasePanel> panelDic = new Dictionary<string, BasePanel>();

    public RectTransform canvas;
    private Transform system;
    
    public UIManager()
    {
        InputMgr.GetInstance().StartCheck();
        GameObject canvasObj = ResMgr.GetInstance().Load<GameObject>("UI/Canvas");
        canvas = canvasObj.transform as RectTransform;
        GameObject.DontDestroyOnLoad(canvasObj);
        GameObject eventObj = ResMgr.GetInstance().Load<GameObject>("UI/EventSystem");
        GameObject.DontDestroyOnLoad(eventObj);
    }
    //����panel
    public void LoadPanel<T>(string panelName,UnityAction<T> callback=null) where T:BasePanel
    {
        
        ResMgr.GetInstance().LoadAsync<GameObject>("UI/Panels/" + panelName, (obj) =>
           {
               
               Transform father = canvas;
               obj.transform.SetParent(father,false);

              (obj.transform as RectTransform).offsetMax = Vector2.zero;
               (obj.transform as RectTransform).offsetMin = Vector2.zero;

               T panel = obj.GetComponent<T>();
               if (panelDic.ContainsKey(panelName)==false)
               {
                   panelDic.Add(panelName, panel);
               }
               panel.ShowMe();
               if (callback != null)
               {
                   callback(panel);
               }
               
           });
       
    }

    //��ʾpanel
    public void ShowPanel<T>(string panelName, UnityAction<T> callBack = null)  where T:BasePanel
    {
        //dic���������dic,û�����ȼ���panel,�����ֵ�
        if (panelDic.ContainsKey(panelName))
        {
            panelDic[panelName].ShowMe();
            if (callBack != null)
            {
                callBack(panelDic[panelName] as T);
            }
        }
        else
        {
            LoadPanel(panelName,callBack);
        }
    }

    //����panel
    public void  HidePanel(string name) 
    {
        if (panelDic.ContainsKey(name))
        {
            panelDic[name].HideMe();
        }
    }
    public void DestroyPanel(string name)
    {
        if (panelDic.ContainsKey(name))
        {
            panelDic[name].DestroyMe();
            panelDic.Remove(name);
        }
    }
    public T GetPanel<T>(string name) where T : BasePanel
    {
        if (panelDic.ContainsKey(name))
            return panelDic[name] as T;
        return null;
    }
    public void ClearPanel()
    {
        panelDic.Clear();
    }

    public void IniUI()
    {
        //��ʼ��UImanager
    }
}
