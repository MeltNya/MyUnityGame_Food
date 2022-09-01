using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1.�������Ѳ��
//2.��������ʼ���й���

public class Cat : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed=5.0f;
    Vector3 moveDirec = Vector3.zero;
    float moveRange = 2.0f;
    float times = -0.1f;
    Rigidbody rig;
    Animator animator;
    Transform StartTrans;
    
    private void Awake()
    {
        rig = this.GetComponent<Rigidbody>();
        animator = this.GetComponent<Animator>();
        StartTrans = this.transform;
    }
    void Start()
    {
        EventManager.GetInstance().AddEventListener("CatDie", CatDie);
        Debug.Log(StartTrans.position);
    }

    // Update is called once per frame
    void Update()
    {
        //ÿ��5���һ�η���,ͣ��2��
        times -= Time.deltaTime;
        if (times < 0)
        {
            ChangeDirection();
            times = 5.0f;
        }
        if (times < 2 || times>=0)
        {
            animator.SetFloat("Speed", 0);
        }
        if (times >= 2)
        {
            moveRandom();
        }
        
    }
    //С��Χ������ƶ�
    void moveRandom()
    {
        //Debug.Log(transform.position);
        if(Vector3.Distance(transform.position,StartTrans.position) < moveRange)
        {
            moveSpeed = 1.0f;
            transform.rotation = Quaternion.LookRotation(moveDirec);
            rig.velocity = moveDirec * moveSpeed;
            Debug.Log("cat move");
            animator.SetFloat("Speed", moveSpeed);
        }
    }
    //���ת��
    void ChangeDirection()
    {
        float rX = Random.Range(-10, 10);
        float rZ = Random.Range(-10, 10);
        moveDirec = new Vector3(rX, 0, rZ).normalized;
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }

    void CatDie()
    {
        //��������
        Invoke("FallaItem", 0.5f);
        Invoke("DestroyMe", 1.0f);
        //EventManager.GetInstance().RemoveEventListener("CatDie", CatDie);
        
        
    }
    void FallaItem()
    {
        Vector3 temp = this.transform.position;
        ResMgr.GetInstance().LoadatPostion<GameObject>("Item/mint", temp);
    }
    void DestroyMe()
    {
        GameObject.Destroy(this.gameObject);
    }
}
