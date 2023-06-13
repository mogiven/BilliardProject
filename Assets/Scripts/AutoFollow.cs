using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum FollowType
{
    SetPosition,
    Lerp,
    MoveTowards,
    MoveTowardsAndLerp,
    SmoothDamp,
    RigibodyAddForce,
    Translate
}

public class AutoFollow : MonoBehaviour
{
    public Transform targetTansform;
    public FollowType myFollowType;
    public float lerpSpeed = 5f;
    public float moveSpeed = 5f;
    public float dampSpeed = 100f;
    private Vector3 velocity = Vector3.zero;
    public float forceSpeed = 50;
    public float bullet_move_speed = 10F; 

    //定义一个全局变量，存储鼠标上一帧的位置
    private Vector3 lastMousePosition;

    //定义一个常量，表示移动速度
    private const float mouseMoveSpeed = 0.2f;

    //在Start方法中，初始化鼠标位置和移动方向
    void Start()
    {
        //获取当前鼠标位置
        lastMousePosition = Input.mousePosition;
    }

    private void FixedUpdate()
    {

        if(global.is_hold==0){
            //Debug.Log("没有拿球杆");
            this.transform.position+= global.move_forward_direction * bullet_move_speed * Time.deltaTime;
            return;
        }

        //手动模式
        if(global.is_hold==-1){
            //获取当前鼠标位置
            Vector3 currentMousePosition = Input.mousePosition;
            //计算鼠标在垂直方向上的移动距离
            float mouseDeltaY = currentMousePosition.y - lastMousePosition.y;
            //根据移动距离和速度，计算物体在移动方向上的位移
            float moveDistance = mouseDeltaY * mouseMoveSpeed * Time.deltaTime;

            //Debug.Log("移动方向为"+global.move_forward_direction+"移动距离为"+moveDistance+"鼠标当前在"+currentMousePosition.y);

            //更新物体的位置，沿着移动方向移动一定的位移
            this.transform.position += global.move_forward_direction * moveDistance;
            //更新鼠标位置
            lastMousePosition = currentMousePosition;
            return;
        }

        // //球杆不动
        // if(global.is_hold==-2){
        //     return;
        // }
        //获取当前鼠标位置
        lastMousePosition = Input.mousePosition;

        Vector3 forward = targetTansform.TransformDirection(Vector3.forward) ;
        switch (myFollowType)
        {
            
            case FollowType.SetPosition:
                
                this.transform.position = targetTansform.position + forward *1F +new Vector3(0,-0.5F,0);
                this.transform.rotation=Quaternion.LookRotation( forward);
                break;
            case FollowType.Lerp:
                this.transform.position = Vector3.Lerp(this.transform.position,targetTansform.position, lerpSpeed * Time.fixedDeltaTime);
                break;
            case FollowType.MoveTowards:
                this.transform.position = Vector3.MoveTowards(this.transform.position,targetTansform.position, moveSpeed * Time.fixedDeltaTime);
                break;
            case FollowType.MoveTowardsAndLerp:
                this.transform.position = Vector3.MoveTowards(this.transform.position,Vector3.Lerp(this.transform.position,targetTansform.position, lerpSpeed * Time.fixedDeltaTime), moveSpeed * Time.fixedDeltaTime);
                break;
            case FollowType.SmoothDamp:
                this.transform.position = Vector3.SmoothDamp(this.transform.position,targetTansform.position, ref velocity,dampSpeed * Time.fixedDeltaTime);
                break;
            case FollowType.RigibodyAddForce:
                //Vector3 force = targetTansform.position - transform.position;
                Vector3 force = forward;
                force = force.normalized;
                force = force * forceSpeed;
                transform.GetComponent<Rigidbody>().AddForce(force);
                break;
            case FollowType.Translate:
                Vector3 moveDirection = targetTansform.position - transform.position;
                transform.Translate(moveDirection,Space.World);
                break;
            
        }
    }
}


