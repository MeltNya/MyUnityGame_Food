using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVel = new Vector2(0, -1);

    }
    //��⵽��ʰȡ��,��ִ���Զ�����
   /* protected void DestroyItem()
    {
        Destroy(this.gameObject);
    }*/


    public virtual void  OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            EventManager.GetInstance().EventTrigger("ItemAway");
            InputMgr.GetInstance().CanbeGet = false;
            
        }
    }
}
