using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAttri : MonoBehaviour
{
    float HP = 5f;
    float ATF = 2f;


    private void beAttcked(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            EventManager.GetInstance().EventTrigger("CatDie"); 
            //EventManager.GetInstance().EventTrigger<GameObject>("CatDieG",this.gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
