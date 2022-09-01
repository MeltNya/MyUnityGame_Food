using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class GridPanel : BasePanel
{
    delegate void SelectDel(ItemType it, int i);
    
    SelectDel se;
    // Start is called before the first frame update

    private void Awake()
    {
       //����������
       FindChildrenControl<Button>();
       FindChildrenControl<Image>();
       FindChildrenControl<TMP_Text>();
        
        se = new SelectDel(SelectedFood);
        HideItemImages();
        HideCheckImages();

    }
    void Start()
    {
        
        ShowItems();
        //���˶���,����±���
        //EventManager.GetInstance().AddEventListener("GetItem", ShowItems);
        //Debug.Log(controlDic["checkImage"].Count);

    }

    // Update is called once per frame
    void Update()
    {
        //�����Ʒ���ݷ����仯,��ʵʱ����panel����
        
    }
    void HideItemImages()
    {
        if (controlDic.ContainsKey("ItemImage"))
         {
        foreach (var i in controlDic["ItemImage"])
            {
                (i as Image).gameObject.SetActive(false);
            }
        }
    }
    void HideCheckImages()
    {
        if (controlDic.ContainsKey("checkImage"))
        {
            foreach(var i in controlDic["checkImage"])
            {
                (i as Image).gameObject.SetActive(false);
            }
        }
    }
    public void ShowItems()
    {
        /*1.��gameManager��ȡ��Ʒ����
         * 2.������Ʒ���ͺ���������ͼƬ
         * */
        int index = 0;
        Sprite sprite;
        if (GameManager.GetInstance().itemDic.ContainsKey(ItemType.Apple))
        {
            //�첽д��
            /*ResMgr.GetInstance().LoadAsync<Sprite>("UI/Sprites/apple", (objs) =>
            {
                sprite = objs;
                (controlDic["ItemImage"][index] as Image).gameObject.SetActive(true);
                (controlDic["ItemImage"][index] as Image).sprite = sprite;
            });*/
            sprite = ResMgr.GetInstance().Load<Sprite>("UI/Sprites/apple");
            (controlDic["ItemImage"][index] as Image).gameObject.SetActive(true);
            (controlDic["ItemImage"][index] as Image).sprite = sprite;
            
            string s = GameManager.GetInstance().itemDic[ItemType.Apple].ToString();
            (controlDic["itemTextTmp"][index] as TMP_Text).text = s;
            //Debug.Log(se.ToString());
            ClickAButton("ItemBtn", index, ItemType.Apple);
            
            index += 1;
        }
        if (GameManager.GetInstance().itemDic.ContainsKey(ItemType.Wheat))
        {
            sprite = ResMgr.GetInstance().Load<Sprite>("UI/Sprites/wheat");
            (controlDic["ItemImage"][index] as Image).gameObject.SetActive(true);
            (controlDic["ItemImage"][index] as Image).sprite = sprite;

            string s = GameManager.GetInstance().itemDic[ItemType.Wheat].ToString();
            (controlDic["itemTextTmp"][index] as TMP_Text).text = s;

            ClickAButton("ItemBtn", index, ItemType.Wheat);
            
            index += 1;
        }
        if (GameManager.GetInstance().itemDic.ContainsKey(ItemType.Mint))
        {
            sprite = ResMgr.GetInstance().Load<Sprite>("UI/Sprites/mint");
            (controlDic["ItemImage"][index] as Image).gameObject.SetActive(true);
            (controlDic["ItemImage"][index] as Image).sprite = sprite;

            string s = GameManager.GetInstance().itemDic[ItemType.Mint].ToString();
            (controlDic["itemTextTmp"][index] as TMP_Text).text = s;
            ClickAButton("ItemBtn", index, ItemType.Mint);

            index += 1;
        }

    }
    

    void ClickAButton( string controlName,int index,ItemType it ) 
    {
        //��button��ӵ���¼�,�������ʾcheckImage,����gamemanager���б�
        if (controlDic.ContainsKey(controlName) && index < controlDic[controlName].Count && controlDic[controlName][index]!=null)
        {
           (controlDic[controlName][index] as Button).onClick.AddListener( ()=> {
               SoundManager.GetInstance().PlayClickClip();
               if (se != null)
               {
                   se(it, index);
               }
           });
        }
    }

    void func()
    {
        Debug.Log("im func");
    }

    public  void  SelectedFood(ItemType it,int index)
    {
        //�����������
        if (GameManager.GetInstance().selectedItem.Contains(it)==false)
        {
            GameManager.GetInstance().selectedItem.Add(it);
            (controlDic["checkImage"][index] as Image).gameObject.SetActive(true);
        }
        else 
        {
            GameManager.GetInstance().selectedItem.Remove(it);
            (controlDic["checkImage"][index] as Image).gameObject.SetActive(false);
        }
       
    }

}
