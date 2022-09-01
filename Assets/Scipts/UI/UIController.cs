using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    //监听按键控制UI显示
    private bool hasOpenBag = false;
    private void Awake()
    {
        UIManager.GetInstance().ShowPanel<DiaLoguePanel>("DialoguePanel");
        UIManager.GetInstance().ShowPanel<SavePanel>("SavePanel");
    }
    void Start()
    {
        
        EventManager.GetInstance().AddEventListener<KeyCode>("aKeyDown", UIkeyDown);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CloseDia()
    {

        UIManager.GetInstance().ShowPanel<DiaLoguePanel>("DialoguePanel");
    }
    void UIkeyDown(KeyCode key)
    {
        //按下B加载背包UI
        if (key == KeyCode.B)
        {
            SoundManager.GetInstance().PlayBagClip();
            UIManager.GetInstance().ShowPanel<BagPanel>("BagPanel");
        }
    }
}
