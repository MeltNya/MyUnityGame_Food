using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPanel : BagPanel
{
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        CookManager.GetInstance().Pause();
        //EventManager.GetInstance().AddEventListener<KeyCode>("aKeyDown", StartKeyDown);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGame();
        }
    }
    void StartGame()
    {
        CookManager.GetInstance().Resume();
        SoundManager.GetInstance().PlayStartClip();

        UIManager.GetInstance().DestroyPanel("TutorialPanel");
    }
}
