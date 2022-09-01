using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUi : MonoBehaviour
{
    //public RectTransform canvas;
    private void Start()
    {
        UIManager.GetInstance().ClearPanel();
        UIManager.GetInstance().ShowPanel<ItemPanel>("ItemPanel");
    }
}
