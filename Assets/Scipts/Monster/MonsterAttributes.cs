using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum MonsterType
{
    cat,
    cow,
    other
}
public class MonsterAttributes : MonoBehaviour
{
    float HP = 5f;
    float ATF = 2f;
    MonsterType monsType=MonsterType.cat;

    public void beAttcked(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            if (monsType == MonsterType.cat)
            {
                EventManager.GetInstance().EventTrigger("CatDie");
            }
           
        }
        
    }
    private void Update()
    {
        
    }

}
