using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, false);
        InputMgr.GetInstance().StartCheck();
        EventManager.GetInstance().AddEventListener<KeyCode>("aKeyDown", ExitKeyDown);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ExitKeyDown(KeyCode key)
    {
        if (KeyCode.Escape == key)
        {
            //UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
}
