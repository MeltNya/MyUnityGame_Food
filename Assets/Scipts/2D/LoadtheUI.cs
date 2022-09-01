using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadtheUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIManager.GetInstance().ShowPanel<ScorePanel>("ScorePanel");
        UIManager.GetInstance().ShowPanel<TutorialPanel>("TutorialPanel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
