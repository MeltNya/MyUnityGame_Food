using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookInput : MonoBehaviour
{
    public EfallObj inputFallType=EfallObj.other;
    GameObject lineObj;
    GameObject closetObj;
    FallingObject falling;
    bool keyCorrect=false;
    // Start is called before the first frame update
    private void Awake()
    {
        lineObj = GameObject.Find("Line");
    }
    void Start()
    {
        InputMgr.GetInstance().StartCheck();
        Debug.Log("start check cookInput");
        EventManager.GetInstance().AddEventListener<KeyCode>("aKeyDown", CookKeyDown);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CookKeyDown(KeyCode key)
    {
        Debug.Log("key down");
        if (key == KeyCode.A)
        {
            inputFallType = EfallObj.apple;
            Debug.Log(inputFallType);
        }
        if(key == KeyCode.D)
        {
            inputFallType = EfallObj.mint;
        }
        //----判定 ---
       if (CheckObj())
        {
            Debug.Log("key correct");
            return;
        }
        Debug.Log("error key");
    }
    bool CheckObj()
    {
        closetObj = FindObj();
        //先检查是否有相应物体,再检查物体类别和状态
        if (closetObj == null)
        {
            return false;
        }
       falling = closetObj.GetComponent<FallingObject>();
        //检测正确后销毁物体
        
       if(falling.fallType ==inputFallType && falling.beCollided == true)
        {
            falling.DestroyMe();
            CookManager.GetInstance().cookScore += 100;
            EventManager.GetInstance().EventTrigger("CheckCorrect");
            SoundManager.GetInstance().PlayHitClip();
            return true;
        }
        else
        {
            return false;
        }
    }
    GameObject FindObj()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("FallObj");

        GameObject closestObj = null;
        float minDistance = 10f;
        for (int i = 0; i < objs.Length; i++)
        {
            float distanceY = Mathf.Abs(lineObj.transform.position.y - objs[i].transform.position.y);
            if (distanceY < minDistance)
            {
                minDistance = distanceY;
                closestObj = objs[i];
            }
        }
        return closestObj;
    }
}
