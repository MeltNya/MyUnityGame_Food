using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BagPanel : BasePanel
{
    //public bool isOpen=false;
    public Transform startImage;
    public Transform textAreaImg;
    public Transform textArea;


    private void Awake()
    {
        //controlDic.Clear();
        FindChildrenControl<Button>();
        FindChildrenControl<Image>();
        FindChildrenControl<TMP_Text>();
        startImage = this.transform.Find("StartImage");
        textAreaImg = this.transform.Find("ImageTextArea");
        textArea = textAreaImg.Find("TextAreaTMP");
        

    }
    void Start()
    {

        startImage.gameObject.SetActive(false);
        //��onclik�¼�
        ClickButtons(ConfirmClick, "ConfirmButton");
        ClickButtons(CloseClick, "CloseButton");

    }
    public override void ShowMe()
    {
        base.ShowMe();
        GameManager.GetInstance().Pause();
        GameManager.GetInstance().LockRotate();
        InputMgr.GetInstance().EndCheck();
    }
    public override void DestroyMe()
    {
        base.DestroyMe();
        GameManager.GetInstance().Resume();
        GameManager.GetInstance().StartRotate();
        InputMgr.GetInstance().StartCheck();
    }
    public override void HideMe()
    {
        base.HideMe();
        GameManager.GetInstance().Resume();
        GameManager.GetInstance().StartRotate();
        InputMgr.GetInstance().StartCheck();
    }
    void CloseClick()
    {
        UIManager.GetInstance().DestroyPanel("BagPanel");

    }
    //ȷ�ϰ�ť
    void ConfirmClick()
    {
        bool canCook = checkMenu();
        SoundManager.GetInstance().PlayClickClip();
        //3.����ȷ�Ϻ�����Ʒ�Ƿ���ϵ�ǰ����Ҫ��
        if (canCook)
        {
            //����UI,������л�����
            textArea.GetComponent<TMP_Text>().text = "Success";
            startImage.gameObject.SetActive(true);
            SoundManager.GetInstance().PlaySuccClip();
            GameManager.GetInstance().LoadCookScene();
            UIManager.GetInstance().DestroyPanel("BagPanel");
            //�����¼� ��ʼ����
           // EventManager.GetInstance().EventTrigger("CookStart");
        }
        else
        {
            textArea.GetComponent<TMP_Text>().text = "The ingredients are not ready yet";
            //Debug.Log("The ingredients are not ready yet");
        }
    }

    bool checkMenu()
    {
        bool res = false;
        List<ItemType> taskList = Task.GetInstance().taskList;
        List<ItemType> selectedList = GameManager.GetInstance().selectedItem;

        if (taskList.Count != selectedList.Count)
        {
            return false;
        }
        for (int i = 0; i < taskList.Count; i++)
        {
            if (!selectedList.Contains(taskList[i]))
            {
                return false;
            }
        }
        res = true;

        return res;
    }
}

    


