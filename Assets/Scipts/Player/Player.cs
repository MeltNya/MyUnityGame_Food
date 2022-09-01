using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private Animator animator;
    private PlayerAttriButes attri;
    public float DirectionDamoTime = 0.25f;
    public float moveSpeed = 5;
    Vector3 moveVel;
    public float jumpForce = 10;
    public bool canJump= true;
    private Rigidbody rigid;

    GameObject[] enemyObj;
    List<GameObject> enemyBeAtk = new List<GameObject>();

    // private Transform playerTransform;
    // Start is called before the first frame update
    private void Awake()
    {
        
        rigid = this.GetComponent<Rigidbody>();
        animator = this.GetComponent<Animator>();
        attri = this.GetComponent<PlayerAttriButes>();
    }
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        /*MoveTrans();
        Attack();
        Jump();*/
    }

    public void MoveTrans()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        if (h != 0 || v != 0)
        {
            moveVel = new Vector3(h, 0, v);
            
            transform.rotation = Quaternion.LookRotation(moveVel);
            
            transform.position += moveVel * moveSpeed * Time.deltaTime;
        }
        animator.SetFloat("Speed", moveVel.magnitude);
    }
    public void Attack()
    {
       animator.SetTrigger("attack");
       SelectMonster();
       PlayerAttack();
        
    }
    public void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Debug.Log("H=" + h.ToString());
        Debug.Log("V=" + v.ToString());
        Vector3 moveVel = new Vector3(h, 0, v);
        rigid.velocity = moveVel * moveSpeed;

        
    }
   public  void Jump()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.down, Color.red);
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
            {
                if (hit.distance <= 1.0f)
                {
                    rigid.AddForce(Vector3.up * 1 * jumpForce);
                    animator.SetTrigger("Jump");
                }
            }
        
    }
    //添加gameobject进入怪物列表中
    void SelectMonster()
    {
        enemyObj = GameObject.FindGameObjectsWithTag("Monster");
        enemyBeAtk.Clear();
        for (int i = 0; i < enemyObj.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, enemyObj[i].transform.position);
            float angle = Vector3.Angle(transform.forward, enemyObj[i].transform.position - transform.position);
            if(distance<2.5f && angle < 60)
            {
                enemyBeAtk.Add(enemyObj[i]);
            }
        }
    }
     void RemoveMonster(GameObject obj)
    {
        enemyBeAtk.Remove(obj);
    }
    void PlayerAttack()
    {
        //对能攻击到的怪物执行以下逻辑
        for(int i = 0; i < enemyBeAtk.Count; i++)
        {
            GameObject ene = enemyBeAtk[i];
            ene.GetComponent<MonsterAttributes>().beAttcked(attri.playerAtk);            
        }
        SoundManager.GetInstance().PlayAtckClip();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Monster")
        {

        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
       
    }
}
