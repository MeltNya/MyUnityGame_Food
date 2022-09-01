using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    //������������UI��ʾ
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
        //����B���ر���UI
        if (key == KeyCode.B)
        {
            SoundManager.GetInstance().PlayBagClip();
            UIManager.GetInstance().ShowPanel<BagPanel>("BagPanel");
        }
    }
}
