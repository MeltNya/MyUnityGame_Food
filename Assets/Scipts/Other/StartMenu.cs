using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartMenu : MonoBehaviour
{
    Transform startTrans;
    Button startButton;
    void Start()
    {
        startTrans= transform.Find("startButton");
        startButton = startTrans.GetComponent<Button>();
        startButton.onClick.AddListener(StartClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void StartClick()
    {
        SoundManager.GetInstance().PlayStartClip();
        GameManager.GetInstance().loadScene(1);
    }
}
