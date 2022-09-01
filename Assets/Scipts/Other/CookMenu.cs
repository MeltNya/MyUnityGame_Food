using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookMenu
{
    //需要的材料
    public List<ItemType> cookMenuList;
    string cookMenuName; //菜单名字
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
