using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaLoguePanel : BasePanel
{
    public Text diaText;

    //文本文件
    public TextAsset diaFile;
    public int index;
    List<string> textList = new List<string>();
    private void Awake()
    {
        controlDic.Clear();
        FindChildrenControl<Text>();
        diaText = controlDic["DiaText"][0] as Text;
        diaFile = ResMgr.GetInstance().Load<TextAsset>("Texts/dia");
    }
    void Start()
    {
        GetDiaText(diaFile);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && index == textList.Count)
        {
            CloseDia();
        }
        if (Input.GetMouseButtonDown(0) )
        {
            diaText.text = textList[index];
            index += 1;
            SoundManager.GetInstance().PlayClickClip();
        }
    }
    public override void ShowMe()
    {
        base.ShowMe();
        GameManager.GetInstance().Pause();
        GameManager.GetInstance().LockRotate();
        InputMgr.GetInstance().EndCheck();
    }
    void CloseDia()
    {
        SoundManager.GetInstance().PlayStartClip();
        GameManager.GetInstance().Resume();
        GameManager.GetInstance().StartRotate();
        InputMgr.GetInstance().StartCheck();
        index = 0;
         UIManager.GetInstance().DestroyPanel("DialoguePanel");
    }
    void GetDiaText(TextAsset textFile)
    {
        textList.Clear();
        index = 0;
        string[] s =  textFile.text.Split('\n');
        foreach(var i in s)
        {
            textList.Add(i);
        }
    }
}
