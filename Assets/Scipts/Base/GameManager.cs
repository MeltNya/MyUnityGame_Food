using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum ItemType
{
    Apple,
    Wheat,
    Beef,
    Mint,
    other
}

public class GameManager : BaseManager<GameManager>
{
    public Dictionary<ItemType, int> itemDic = new Dictionary<ItemType, int>();
    public bool canCameraRotate = true;
    public List<ItemType> selectedItem = new List<ItemType>();
    public int ItemTypeCount=0;
    //public int appleCount, wheatCount,mintCount;
    //public int appleSelect, wheatSelect, mintSelect;


    //²ËÆ·²Ëµ¥ 
   public CookMenu mintApple = new CookMenu(new List<ItemType>() { ItemType.Mint,ItemType.Apple}, "MintAppleJuice");
   public CookMenu rostSteak = new CookMenu(new List<ItemType>() { ItemType.Beef }, "RostSteak ");

    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
    }

    public void LockRotate()
    {
       canCameraRotate= false;
    }
    public void StartRotate()
    {
        canCameraRotate = true;
    }
    public void loadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void  LoadCookScene()
    {
        SceneManager.LoadScene(1);

    }

}
