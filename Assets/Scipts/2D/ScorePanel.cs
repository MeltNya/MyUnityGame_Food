using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : BasePanel
{
    // Start is called before the first frame update
    private void Awake()
    {
        FindChildrenControl<TMP_Text>();
        FindChildrenControl<Button>();

        EventManager.GetInstance().AddEventListener("CheckCorrect", ScoreUpdate);
        EventManager.GetInstance().AddEventListener("CookSuccess", ()=> {
            if (controlDic.ContainsKey("successText"))
            {
                (controlDic["successText"][0] as TMP_Text).gameObject.SetActive(true);
                (controlDic["ExitButton"][0] as Button).gameObject.SetActive(true);
                SoundManager.GetInstance().PlaySuccClip();
            }
        });
    }
    void Start()
    {
        if (controlDic.ContainsKey("successText"))
        {
            (controlDic["successText"][0] as TMP_Text).gameObject.SetActive(false);
        }
        if (controlDic.ContainsKey("ExitButton"))
        {
            (controlDic["ExitButton"][0] as Button).onClick.AddListener(ExitGame);
            (controlDic["ExitButton"][0] as Button).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ExitGame()
    {
       // UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    void ScoreUpdate()
    {
        if (controlDic.ContainsKey("ScoreText"))
        {
            (controlDic["ScoreText"][0] as TMP_Text).text = CookManager.GetInstance().cookScore.ToString();
            Debug.Log("update score");
        }
    }
}
