using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//����panel�Ļ���
/*
    �ؼ�button image
 
 */
public class BasePanel : MonoBehaviour
{
   public Dictionary<string, List<UIBehaviour>> controlDic = new Dictionary<string, List<UIBehaviour>>();
    // Start is called before the first frame update
    private void Awake()
    {
        FindChildrenControl<Button>();
        FindChildrenControl<Image>();
        FindChildrenControl<Text>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*��ʾ���ص�ǰpanel*/
    public virtual void ShowMe()
    {
        this.gameObject.SetActive(true);
    }
    public virtual void HideMe()
    {
       this.gameObject.SetActive(false);
        
    }
    public virtual void DestroyMe()
    {
        GameObject.Destroy(this.gameObject);
    }
    protected void FindChildrenControl<T>() where T : UIBehaviour
    {
        T[] controls = this.GetComponentsInChildren<T>();
        for (int i = 0; i < controls.Length; ++i)
        {
            string objName = controls[i].gameObject.name;
            if (controlDic.ContainsKey(objName))
                controlDic[objName].Add(controls[i]);
            else
                controlDic.Add(objName, new List<UIBehaviour>() { controls[i] });
        }
    }
    //��button�ȿؼ���ӵ���¼�
    protected virtual void  ClickButtons(UnityAction action,string controlName)
    {
        if (controlDic.ContainsKey(controlName))
        {
            if (controlDic[controlName][0] is Button)
            {
                (controlDic[controlName][0] as Button).onClick.AddListener(action);
            }
        }
    }
    
}
