using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestText : MonoBehaviour
{
    [Header("���")]
    public Text textLabel;
    public Image image;

    
    private void Awake()
    {
        //ΪtextLabel����ֵ
        textLabel = this.GetComponentInChildren<Text>();
    }
    void Start()
    {
        textLabel.text = "apple";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
