using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 根据时间加载gameObject


public class fallMode : MonoBehaviour
{
    float xRandom;
    GameObject frontObj;
    public float timeCur =1f;
    //public float[] loadtime = new float[6] { 11.3f, 9.5f, 7.0f, 6.0f, 3.5f ,2.9f};
    public int fallCount = 8;
    private void Awake()
    {
        frontObj = GameObject.Find("front");
        
        
    }
    void Start()
    {
        //CreateFallObj(EfallObj.mint);
    }

    // Update is called once per frame
    void Update()
    {
        if (fallCount <= 0 && CookManager.GetInstance().cookScore >500)
        {
            Invoke("TriggerSuccess", 3f);
        }
        //随机时间加载fallobj
        timeCur -= Time.deltaTime;
        if (timeCur < 0 && fallCount >0)
        {
            CreateFallObj(Random.Range(0f, 2f));
            fallCount -= 1;
            timeCur = Random.Range(0.8f, 2.0f );
        }
        

    }
    void TriggerSuccess()
    {
        EventManager.GetInstance().EventTrigger("CookSuccess");
    }
    void CreateFallObj(float r)
    {
        Vector3 iniVec = new Vector3(Random.Range(-3.0f, 3.0f) ,4f , -6.2f);
        if (r < 1.0f)
        {
            ResMgr.GetInstance().LoadatPostion<GameObject>("2D/apple", iniVec);
        }
        else
        {
            ResMgr.GetInstance().LoadatPostion<GameObject>("2D/mint", iniVec);
        }
    }
}
