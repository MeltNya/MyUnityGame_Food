using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookMenu
{
    //��Ҫ�Ĳ���
    public List<ItemType> cookMenuList;
    string cookMenuName; //�˵�����
    public CookMenu(List<ItemType> itemTypesList,string name)
    {
        cookMenuList = itemTypesList;
        cookMenuName = name;
    }
    public List<ItemType>  GetList()
    {
        return cookMenuList;
    }
}
