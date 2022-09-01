using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPanel : BasePanel
{
    //Text textAsset;
    private void Awake()
    {
        //this.gameObject.SetActive(false);
        


    }
    // Start is called before the first frame update

    void Start()
    {   
        //实例化后设置初始位置
        RectTransform rect = this.GetComponent<RectTransform>();
        rect.localPosition = new Vector3(500, -300, 0);

        this.gameObject.SetActive(false);

        EventManager.GetInstance().AddEventListener("AppleBumped", Apple);
        EventManager.GetInstance().AddEventListener("WheatBumped", Wheat);
        EventManager.GetInstance().AddEventListener("MintBumped", Mint);
        EventManager.GetInstance().AddEventListener("ItemAway", HideMe);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Apple()
    {
        this.GetComponentInChildren<TMP_Text>().text = "apple";
    }
    void Wheat()
    {
        this.GetComponentInChildren<TMP_Text>().text = "wheat";
    }
    void Mint()
    {
        this.GetComponentInChildren<TMP_Text>().text = "mint";
    }
}
