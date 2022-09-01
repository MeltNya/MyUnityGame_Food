using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestText : MonoBehaviour
{
    [Header("组件")]
    public Text textLabel;
    public Image image;

    
    private void Awake()
    {
        //为textLabel赋初值
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
