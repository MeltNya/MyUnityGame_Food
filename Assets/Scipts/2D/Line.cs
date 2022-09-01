using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
   // Vector2 origi;
    
    // Start is called before the first frame update
    private void Awake()
    {
        //origi = new Vector2(this.transform.position.x, this.transform.position.y);
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    GameObject FindObj()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("FallObj");
        
        GameObject closestObj = null;
        float minDistance = 10f;
        for(int i =0; i< objs.Length; i++)
        {
            float distanceY = Mathf.Abs(transform.position.y - objs[i].transform.position.y);
            if (distanceY < minDistance)
            {
                minDistance = distanceY;
                closestObj = objs[i];
            }
        }
        return closestObj;
    }
}
