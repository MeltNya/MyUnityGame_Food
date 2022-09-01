using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject playerObj;
    Player player;
   // Animator animator;
    //CharacterController characterController;
    public float speed=2;
    public float JumpForce;
    public float gravity = 20;
    // Vector3 dir;
    // Start is called before the first frame update
    private void Awake()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<Player>();
    }
    void Start()
    {
        //animator = this.GetComponent<Animator>();
        //characterController = this.GetComponent<CharacterController>();
        //开始监听输入
        InputMgr.GetInstance().StartCheck();
        //监听按键
        EventManager.GetInstance().AddEventListener<KeyCode>("aKeyDown", PlayerKeyDown);
        EventManager.GetInstance().AddEventListener<KeyCode>("aKeyUp", PlayerKeyUp);
        

    }

    // Update is called once per frame
    void Update()
    {
        player.MoveTrans();
    }
    
   void PlayerKeyUp(KeyCode key)
    {

    }
    void PlayerKeyDown(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.Space:
                {
                    player.Jump();
                    break;
                }
                
            case KeyCode.F:
                Debug.Log("F down");
                //拾取物品
                break;
            case KeyCode.E:
                player.Attack();
                break;
        }
    }

}
