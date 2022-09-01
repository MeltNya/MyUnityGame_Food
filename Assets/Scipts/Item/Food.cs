using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Item
{
    public ItemType foodType;
    bool CanbeDestroy=false;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.GetInstance().AddEventListener<KeyCode>("aKeyDown", FoodKeyDown);
       // foodType = this.GetComponent<EFoodType>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            UIManager.GetInstance().ShowPanel<ItemPanel>("ItemPanel");
            InputMgr.GetInstance().CanbeGet = true;
            CanbeDestroy = true;
            switch (foodType)
            {
                case ItemType.Apple:
                    EventManager.GetInstance().EventTrigger("AppleBumped");
                    break;
                case ItemType.Mint:
                    EventManager.GetInstance().EventTrigger("MintBumped");
                    break;
                case ItemType.Wheat:
                    EventManager.GetInstance().EventTrigger("WheatBumped");
                    break;
            }
            
        }
    }

    public override void OnCollisionExit(Collision collision)
    {
        base.OnCollisionExit(collision);
       // EventManager.GetInstance().RemoveEventListener<KeyCode>("aKeyDown", FoodKeyDown);
    }
    //¼ì²â°´ÏÂ¼üÅÌ
    protected void FoodKeyDown(KeyCode key )
    {
        if (key == KeyCode.F)
        {
            if(CanbeDestroy == true)
            {
                CanbeDestroy = false;
                SoundManager.GetInstance().PlayGetClip();
                GameObject.Destroy(this.gameObject);
                EventManager.GetInstance().EventTrigger("ItemAway");

                 if (GameManager.GetInstance().itemDic.ContainsKey(foodType))
                  {
                    GameManager.GetInstance().itemDic[foodType] += 1;
                    GameManager.GetInstance().ItemTypeCount += 1;
                  }
                 else { 
                    GameManager.GetInstance().itemDic.Add(foodType, 1); 
                }
             
            }
        }
    }
}
