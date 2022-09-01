using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConctroller : MonoBehaviour
{
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY; //转动方式

    public float sensitivityX = 5f;                                    
    public float sensitivityY = 5f;

    public float minY = -60f;     
    public float maxY = 60f;

    float rotationY=0f;
    Transform player; //角色位置

    private Vector3 vector;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        vector = player.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position - vector;
        if (GameManager.GetInstance().canCameraRotate == true)
        {
            CameraRotate();
        }
    }


    //转动相机
    void CameraRotate()
    {
        switch (axes)
        {
            case RotationAxes.MouseXAndY:
                {
                    float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
                    rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                    rotationY = Mathf.Clamp(rotationY, minY, maxY);

                    transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
                    break;
                    
                }
            case RotationAxes.MouseX:
                {
                    transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
                    break;
                }
            case RotationAxes.MouseY:
                {
                    rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                    rotationY = Mathf.Clamp(rotationY, minY, maxY);

                    transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
                    break;
                }
        }
    }
}
