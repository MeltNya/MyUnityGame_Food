using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//保存 分数等信息
public class CookManager : BaseManager<CookManager>
{
    public int cookScore = 0;
    bool isSuccess = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
   public  void Resume()
    {
        Time.timeScale = 1.0f;
    }
}
