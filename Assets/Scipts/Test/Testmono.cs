using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testmono :BaseManager<Testmono>
{
    public Testmono()
    {
        MonoManager.GetInstance().AddUpdateListner(TestUpdate);
    }
 
   void TestUpdate()
    {
        Debug.Log("123456");
    }
}

