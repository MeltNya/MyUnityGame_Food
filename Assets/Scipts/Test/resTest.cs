using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj =  ResMgr.GetInstance().Load<GameObject>("Test/Cube");
        obj.transform.position = new Vector3(1, 2, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
