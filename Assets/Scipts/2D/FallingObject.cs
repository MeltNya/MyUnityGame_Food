using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EfallObj
{
    apple,
    mint,
    other
}
public class FallingObject : MonoBehaviour
{
    public EfallObj fallType = EfallObj.apple;
    public float fallSpeed = 1.0f; //下落速度
    [HideInInspector]
    public bool beCollided = false;
    GameObject lineObj;
    // Start is called before the first frame update
    private void Awake()
    {
        lineObj = GameObject.Find("Line");
    }
    void Start()
    {
     /*  EventManager.GetInstance().AddEventListener("CheckCorrect", () =>
        {
            Invoke("DestroyMe", 0.2f);
        });*/
    }
    
    // Update is called once per frame
    void Update()
    {
        fall();
        myCollsion();
    }
    public void fall()
    {
        Vector2 fallVel = new Vector2(0, -1);
        transform.position = new Vector3(transform.position.x, transform.position.y + fallSpeed *fallVel.y *Time.deltaTime,  transform.position.z);
    }
    void myCollsion()
    {
        //通过Y距离判断是否碰到判定线
        float distanceY =Mathf.Abs( (this.transform.position.y - lineObj.transform.position.y) ) ;
        if(distanceY <0.3f )
        {
            beCollided = true;
            Debug.Log("im collide");
            Invoke("DestroyMe", 1.2f);
        }
        /*else
        {
            beCollided = false;
            Debug.Log("im not collide");
        }*/

    }
    public void DestroyMe()
    {
        GameObject.Destroy(this.gameObject);
    }
}
