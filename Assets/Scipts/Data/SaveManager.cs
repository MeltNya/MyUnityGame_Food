using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : BaseManager<SaveManager>
{
    
    public void SavaItems()
    {
        SaveItem si = new SaveItem();
        Dictionary<ItemType,int> itemDic = GameManager.GetInstance().itemDic;
        if (itemDic.ContainsKey(ItemType.Apple))
        {
            si.appleCount = itemDic[ItemType.Apple];
        }
        if (itemDic.ContainsKey(ItemType.Wheat))
        {
            si.appleCount = itemDic[ItemType.Wheat];
        }
        if (itemDic.ContainsKey(ItemType.Mint))
        {
            si.appleCount = itemDic[ItemType.Mint];
        }
        string jsonString = JsonUtility.ToJson(si);
        StreamWriter sw = new StreamWriter(Application.dataPath + "itemData.text");
        sw.Write(jsonString);
        sw.Close();
        Debug.Log("have saved item data");
    }
    public void LoadItemData()
    {
        if(File.Exists(Application.dataPath + "itemData.text"))
        {
            Debug.Log("have load item data");
            //读取文件内容，string字符串转json
            StreamReader sr = new StreamReader(Application.dataPath + "itemData.text");
            string jsonString = sr.ReadToEnd();
            sr.Close();
            SaveItem si =  JsonUtility.FromJson<SaveItem>(jsonString);
            LoadItemtoGameManager(si);
        }
        else
        {
            Debug.Log("there is no itemData");
        }
    }
    void LoadItemtoGameManager(SaveItem si)
    {
        if (si.appleCount != 0)
        {
            if (GameManager.GetInstance().itemDic.ContainsKey(ItemType.Apple))
            {
                GameManager.GetInstance().itemDic[ItemType.Apple] = si.appleCount;
            }
            else
            {
                GameManager.GetInstance().itemDic.Add(ItemType.Apple, si.appleCount);
            }
        }
        if (si.mintCount != 0)
        {
            if (GameManager.GetInstance().itemDic.ContainsKey(ItemType.Mint))
            {
                GameManager.GetInstance().itemDic[ItemType.Apple] = si.mintCount;
            }
            else
            {
                GameManager.GetInstance().itemDic.Add(ItemType.Apple, si.mintCount);
            }
        }
        if(si.wheatCount != 0)
        {
            if (GameManager.GetInstance().itemDic.ContainsKey(ItemType.Wheat))
            {
                GameManager.GetInstance().itemDic[ItemType.Apple] = si.wheatCount;
            }
            else
            {
                GameManager.GetInstance().itemDic.Add(ItemType.Apple, si.wheatCount);
            }
        }
    }
}
