using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePanel : BasePanel
{
    private void Awake()
    {
        FindChildrenControl<Button>();
    }
    void Start()
    {
        ClickButtons(saveData, "SaveButton");
       // ClickButtons(SaveManager.GetInstance().LoadItemData, "SaveButton");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void saveData()
    {
        SaveManager.GetInstance().SavaItems();
    }
}
